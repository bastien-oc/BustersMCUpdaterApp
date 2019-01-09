using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

/*
 * This is the code that handles all non-mod-updater functionality, including any and all programme file updates, app configurations, handling of controls, etc.
 * 
 */
namespace BustersMCUpdaterApp {
    public partial class frmMain {
        private void frmMain_Load( object sender, EventArgs e ) {
            // INIT STUFF
            #region Init variables
            {
                this.Text = String.Format( "BustersMC Updater APP v {0}-{1} ({2})", VERSION, BUILD, DATE );
                lVersionThis.Text = BUILD.ToString();

                logThis( String.Format( "Launched in \"{0}\".", pathApp ) );

                // Create folder structure
                try {
                    if ( !Directory.Exists( pathAppTemp ) ) { Directory.CreateDirectory( pathAppTemp ); }
                    if ( !Directory.Exists( pathAppRepository ) ) { Directory.CreateDirectory( pathAppRepository ); }
                }
                catch { }

                // DEFINE HTTP CONNECTION ROOT, must be here for the updater to catch up!
                if ( Properties.Settings.Default.HTTP_DocumentRoot != "" ) {
                    Connection.HTTP.DocumentRoot = Properties.Settings.Default.HTTP_DocumentRoot;
                    eConnectionHTTPUri.Text = Properties.Settings.Default.HTTP_DocumentRoot;
                    eConnectionHTTPUri.ForeColor = Color.LawnGreen;
                } else {
                    Connection.HTTP.DocumentRoot = eConnectionHTTPUri.Text;
                }

                UPDATER_WEB_ROOT = forwardSlashPath(Connection.HTTP.DocumentRoot + UPDATER_PATH);
                
            }
            #endregion

            // Run without IFs, to just get the version.
            if ( upToDate() == false ) { tsbAppUpdate.Enabled = true; }

            // FETCH THE MISSING FILES
            #region Fetch application files
            {
                if ( !File.Exists( backSlashPath( pathApp ) + "changelog.txt" ) ) {
                    DownloadFile( UPDATER_WEB_ROOT + "changelog.txt", backSlashPath( pathApp ) + "changelog.txt" );
                }
                // temporarily force the updating of blacklist file
                //if ( !File.Exists( backSlashPath( pathApp ) + "blacklist" ) ) {
                DownloadFile( UPDATER_WEB_ROOT + "blacklist", backSlashPath( pathApp ) + "blacklist" );
                //}
            }
            #endregion

            // READ THE BLACKLIST FROM FILE
            #region Read the Blacklist and Changelog
            StreamReader f;
            try {
                f = File.OpenText( backSlashPath( pathApp ) + "blacklist" );
                while ( !f.EndOfStream ) { fileBlacklist.Add( f.ReadLine() ); }
                f.Close();
                tbBlacklist.Text = String.Join( "\r\n", fileBlacklist );
                tbBlacklist.ForeColor = Color.FromArgb( 216, 216, 216 );

            }
            catch ( FileNotFoundException exception ) {
                // File not Found. Create and close (the file).
                logThis( "File 'blacklist' is not found. Attempting to create." );
                FileStream f2 = File.Create( backSlashPath( pathApp ) + "blacklist" );
                f2.Close();
            }
            // Read the Changelog
            try {
                f = File.OpenText( backSlashPath( pathApp ) + "changelog.txt" );
                tbChangelog.Text = f.ReadToEnd();
                f.Close();
            }
            catch { }
            #endregion

            /* 
             * Load selection related settings from registry
             * */
            #region Load selection choice from registry
            {
                /**
                 * LOAD VARIABLES FROM REGISTRY
                 **/
                // If we have saved path for MultiMC Path...
                if ( Properties.Settings.Default.MultiMCPath != "" ) { setMultiMCPath( Properties.Settings.Default.MultiMCPath ); }
                // And for Repository
                if ( Properties.Settings.Default.RepositoryPath != "" ) { setRepoPath( Properties.Settings.Default.RepositoryPath ); }
                else { setRepoPath( pathAppRepository ); }

                // Load default HTTP Document Root
                if ( Properties.Settings.Default.HTTP_DocumentRoot != "" ) {
                    Connection.HTTP.DocumentRoot = Properties.Settings.Default.HTTP_DocumentRoot;
                }

                // Selected instance...
                if ( Properties.Settings.Default.SelectedInstance != "" ) { selectInstance( Properties.Settings.Default.SelectedInstance ); }
                // ... and selected branch
                if ( Properties.Settings.Default.SelectedBranch != "" ) {
                    refreshModpackList();
                    logThis(String.Format("THIS IS DEBUG YADDA YADDA, {0}",Properties.Settings.Default.SelectedBranch));
                    selectRemoteBranch( Properties.Settings.Default.SelectedBranch );
                    cbModpacks.Text = Properties.Settings.Default.SelectedBranch;
                }
            }
            #endregion


            refreshModpackList();
        }

        private void toggleUserControls( Boolean state ) {
            if ( state == false ) {
                btnUpdateSelected.Enabled = false;
                tsbCheckForUpdates.Enabled = false;

                cbInstances.Enabled = false;
                cbModpacks.Enabled = false;

                cbRemotePackVersion.Enabled = false;
                bRefreshInstance.Enabled = false;
                bRefreshRepository.Enabled = false;
            }
            if ( state == true ) {
                btnUpdateSelected.Enabled = true;
                tsbCheckForUpdates.Enabled = true;

                cbInstances.Enabled = true;
                cbModpacks.Enabled = true;

                cbRemotePackVersion.Enabled = true;
                bRefreshInstance.Enabled = true;
                bRefreshRepository.Enabled = true;
            }
        }
    }
}