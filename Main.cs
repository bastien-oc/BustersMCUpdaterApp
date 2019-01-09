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

namespace BustersMCUpdaterApp
{
    
    public partial class frmMain : Form
    {
        // OTHER
        public static String VERSION = "1.2";
        public static String DATE = "23/01/2016";
        public static Int16 BUILD = 24;
        
        // TYPE DEFINITIONS
        enum LogLevel { INFO, WARN, ERROR, DEBUG };
        enum EDownloadType { HTTP, FTP, LOCAL };            // 1.2

        // GLOBAL SWITCHES
        Boolean RemoteRepository = false;
        Boolean DummyBranch = false;
        Boolean Compared = false;
            // Default to one download method
        EDownloadType DownloadType = EDownloadType.HTTP;    // 1.2

        // HARD CODED PATHS AND SUFFIXES
        #region Path Variables
        static String pathApp = getFilePath(Application.ExecutablePath);
        static String pathAppTemp = pathApp + "tmp\\";
        static String pathAppRepository = pathApp + "repository\\";

        // UPDATER SPECIFIC SETTINGS
        // static String UPDATER_WEB_ROOT = "http://gaming.iggys-designs.com/projects/bustersmc-manager/";
        static String APP_EXENAME = "BMCUpdater.exe";
        static String UPDATER_PATH = "updaterfiles/";
        static String UPDATER_WEB_ROOT = "";
        static String UPDATER_VERSION_FILE = "version";
        static String[] UPDATER_WEB_FILES = new String[]    {   
                                                                APP_EXENAME,
                                                                "changelog.txt",
                                                                "blacklist",
                                                            };

        // CONNECTION DETAILS
        static String REPOSITORY_HTTP_URI = "";

        // REPO LOCATIONS
        static String MODS_FOLDER = "mods";

        public struct Connection {
             public struct HTTP {
                public static String DocumentRoot;
            }
             public struct FTP {
                public static String    Hostname;
                public static int       Port;
                public static String    Username;
                public static String    Password;
                public static String    DocumentRoot;
            }
             public struct LOCAL {
                public static String    DocumentRoot;
            }
        }

        String pathMultiMC = "";
        String pathRepository = "";
        #endregion

        // Instance settings
        String selectedInstance = "";       // Name of the selected local instance
        String selectedLocalBranch = "";    // Name of the selected local branch
        String selectedRemoteBranch = "";   // Name of the selected remote branch

        String pathToInstance = "";         // A local path to the instance
        String pathToBranch = "";           // A local path to the branch
        String pathToRemoteBranch = "";     // A web URL to the remote branch

        // Group lists
        List<string> listInstances = new List<string>();
        List<string> listBranches = new List<string>();

        /*
         * The application uses two fields for comparing and displaying files:
         *  Selected Instance Lists     - Lists referring to files in a selected instance only.
         *  Selected Branch Lists       - Lists referring to files in a selected branch only.
         *  
         * All other instances and branches are simply not relevant. However, these fields are only lists of FILES.
         * Should I perhaps do a seperate class with static methods for comparison purposes?... maybe. Cba right now.
         */

        // File lists
        List<string> filelistInstanceMods = new List<string>();
        List<string> filelistInstanceModsMD5 = new List<string>();
        List<string> filelistInstanceConf = new List<string>();
        List<string> filelistInstanceConfMD5 = new List<string>();

        List<string> filelistBranchMods = new List<string>();
        List<string> filelistBranchModsMD5 = new List<string>();
        List<string> filelistBranchConf = new List<string>();
        List<string> filelistBranchConfMD5 = new List<string>();

        // Lists for pending file operations
        List<string> filelistInstanceModsProcess = new List<string>(); // Files to be REMOVED from instance
        List<string> filelistBranchModsProcess = new List<string>(); // Files to be COPIED from repository
        List<string> filelistBranchConfProcess = new List<string>(); // Configs to be COPIED from repo. MIND THIS: Instance has no local process list, because all differences are handled in regard to Branch config. There is no need to remove a file that does not exist.

        // BLACKLIST of config/mod
            //List<string> fileBlacklistMods = new List<string>();
        List<string> filelistProcessIgnore = new List<string>();
        List<string> fileBlacklist = new List<string>();
        List<string> filelistFailedDownload = new List<string>();

        // Update settings
        //Boolean updateConfigs = false;
        Boolean updateMakeBackups = false;

        protected string GetMD5HashFromFile(string fileName) { using (var md5 = MD5.Create()) { using (var stream = File.OpenRead(fileName)) { return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", string.Empty); } } }

        /// <summary>
        /// Returns the path to the directory within which the file is located. 
        /// </summary>
        /// <param name="fullPath"></param>
        /// <returns></returns>
        public static string getFilePath(string fullPath)
        {
            // if there are no slashes, return the variable in full;
            //if ( fullPath.IndexOf("\\") == -1) { return fullPath; }

            // Get the position of the last occurence of a slash and delete anything AFTER that. Keeps the last path
            if (fullPath.LastIndexOf("\\") == fullPath.Length - 1) { return fullPath; }
            else { return fullPath.Remove(fullPath.LastIndexOf("\\") + 1); }
        }


        /// <summary>
        /// Removes PATH from FULLNAME
        /// </summary>
        /// <param name="fullName"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public String truncPath(String fullName, String path)
        {
            return fullName.Replace(path, "");
        }

        /// <summary>
        /// Logs stuff.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="level"></param>
        private void logThis(String message, LogLevel level)
        {
            String time = DateTime.Now.ToShortTimeString();
            tbLog.AppendText(String.Format("[{0}] [{1}] {2}\r\n", time, level.ToString(), message));
        }

        /// <summary>
        /// "Adds file entry to a List<string> AND ListView"
        /// </summary>
        /// <param name="fileName">The short name of a file, i.e modfile.jar or 1.7.10\\modname.jar</param>
        /// <param name="listViewObject"></param>
        /// <param name="fileList"></param>
        private void addFileToList(String fileName, String filePath, ListView listViewObject, List<string> fileList, String fileChecksum)
        {
            String localFileName = truncPath(fileName, filePath);

            ListViewItem item = new ListViewItem(localFileName);
            item.SubItems.Add("");

            // Add checksum to the list. If "C", then calculate it, if not, add as-is.
            if (fileChecksum == "C")
            {
                string MD5 = GetMD5HashFromFile(fileName);
                filelistInstanceModsMD5.Add(MD5);

                item.SubItems.Add(MD5);
            }
            else { item.SubItems.Add(fileChecksum); }
            // NEXT

            if (fileName.IndexOf(".disabled") < 0)
            {
                item.Checked = true;
            }

            listViewObject.Items.Add(item);
            fileList.Add(localFileName);
        }

        /// <summary>
        /// Logs stuff.
        /// </summary>
        /// <param name="message"></param>
        private void logThis(String message)
        {
            String time = DateTime.Now.ToShortTimeString();
            tbLog.AppendText(String.Format("[{0}] [{1}] {2}\r\n", time, LogLevel.INFO.ToString(), message));
        }

        /// <summary>
        /// Adds forward slash ('/') at the end of the path if not present. Usual for WEB URLs
        /// </summary>
        /// <param name="path"></param>
        private string forwardSlashPath(string path)
        {
            int pos = path.LastIndexOf( "/" );
            if ( pos != path.Length - 1 ) { return path + "/"; } else
                return path;
        }

        /// <summary>
        /// Adds forward slash ('\')
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private string backSlashPath( string path ) {
            // Check if path ends in "\". If not, append it.
            int pos = path.LastIndexOf( "\\" );
            if ( pos != path.Length - 1 ) {
                return path + "\\";
            }
            else
                return path;
        }

        /// <summary>
        /// Validates and sets the instance path
        /// </summary>
        private void setMultiMCPath(String path)
        {
            // Check if the path exists
            if (!Directory.Exists(path))
            {
                logThis("Path doesn't exist!");
                return;
            }

            // Check if path ends in "\". If not, append it.
            path = backSlashPath(path);

            // Check whether the path is valid, by checking existence of "instgroups.json" file
            if (!File.Exists(path + "MultiMC.exe"))
            {
                MessageBox.Show("This not a valid MultiMC directory!", "Invalid path", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logThis("Not a valid MultiMC instances directory!", LogLevel.ERROR);
                return;
            }

            // All seems ok, UPDATE
            pathMultiMC = path;
            //lPathToInstance.Text = path;
            tbPathInstance.Text = path;

            Properties.Settings.Default.MultiMCPath = pathMultiMC;
            Properties.Settings.Default.Save();

            // Refresh list of instances
            refreshInstancesList();
        }

        /// <summary>
        /// Refreshes the list of instances
        /// </summary>
        void refreshInstancesList()
        {
            // If the pathInstances is empty, abort;
            if (pathMultiMC == null || pathMultiMC == "")
            {
                logThis("Path cannot be empty.", LogLevel.ERROR);
                return;
            }

            // Clear lists first
            listInstances.Clear();
            cbInstances.Items.Clear();

            // List all directories
            DirectoryInfo dir = new DirectoryInfo(pathMultiMC + "instances\\");
            foreach (DirectoryInfo sub in dir.GetDirectories())
            {
                // Add them both to list of instances and the ComboBox
                listInstances.Add(sub.Name);
                cbInstances.Items.Add(sub.Name);
            }
        }

        /// <summary>
        /// Sets the instance.
        /// </summary>
        /// <param name="instance"></param>
        void selectInstance(String instance)
        {
            if (listInstances.Count == 0)
            {
                logThis("There are no instances!");
                return;
            }

            if (listInstances.IndexOf(instance) < 0)
            {
                logThis("Instance does not exist.");
                return;
            }

            // Select the instance
            selectedInstance = instance;
            pathToInstance = pathMultiMC + "instances\\" + instance + "\\minecraft\\";
            cbInstances.Text = instance;

            logThis(String.Format("Selected instance \"{0}\" in \"{1}\"!", instance, pathToInstance));

            Properties.Settings.Default.SelectedInstance = instance;
            Properties.Settings.Default.Save();

            // TODO: ReadInstanceFiles();
            readInstanceFiles();
        }

        // Creates the file manifests
        private void readInstanceFiles()
        {

            // Validate selections and paths before proceeding
            if (selectedInstance == "")
            {
                logThis("No instance selected!");
                return;
            }
            if (Directory.Exists(pathToInstance) == false)
            {
                logThis(String.Format("Path to instance \"{0}\" does not exist!", pathToInstance));
                return;
            }

            // Clear the lists
            filelistInstanceMods.Clear();
            filelistInstanceModsMD5.Clear();
            filelistInstanceConf.Clear();
            filelistInstanceConfMD5.Clear();

            lvInstanceMods.Items.Clear();
            lvInstanceConfigs.Items.Clear();

            String pathToMods = pathToInstance + "mods\\";
            String pathToConfig = pathToInstance + "config\\";

            if (!Directory.Exists(pathToMods)) { Directory.CreateDirectory(pathToMods); }
            if (!Directory.Exists(pathToConfig)) { Directory.CreateDirectory(pathToConfig); }

            //logThis(String.Format("Path to mods: {0}", pathToMods));
            //logThis(String.Format("Path to conf: {0}", pathToConfig));

            // SCAN FOR MODS
            {
                DirectoryInfo dir = new DirectoryInfo(pathToMods);
                // Scan for files in subdirs first, for the sake of appearances in lists
                foreach (DirectoryInfo sub in dir.GetDirectories())
                {
                    foreach (FileInfo file in sub.GetFiles("*.jar")) { addFileToList(file.FullName, pathToMods, lvInstanceMods, filelistInstanceMods, "C"); }
                    foreach (FileInfo file in sub.GetFiles("*.zip")) { addFileToList(file.FullName, pathToMods, lvInstanceMods, filelistInstanceMods, "C"); }
                }
                // Now scan main directory for files
                foreach (FileInfo file in dir.GetFiles("*.jar")) { addFileToList(file.FullName, pathToMods, lvInstanceMods, filelistInstanceMods, "C"); }
                foreach (FileInfo file in dir.GetFiles("*.zip")) { addFileToList(file.FullName, pathToMods, lvInstanceMods, filelistInstanceMods, "C"); }

            }

            // SCAN FOR CONFS
            {
                DirectoryInfo dir = new DirectoryInfo(pathToConfig);
                foreach (FileInfo file in dir.GetFiles("*", SearchOption.AllDirectories))
                {
                    string shortPath = truncPath(file.FullName, pathToConfig);
                    string checksum = GetMD5HashFromFile(file.FullName);

                    ListViewItem item = new ListViewItem(shortPath);
                    item.SubItems.Add(checksum);

                    filelistInstanceConf.Add(shortPath);
                    filelistInstanceConfMD5.Add(checksum);

                    lvInstanceConfigs.Items.Add(item);
                    //    addFileToList(truncPath(file.FullName, pathToConfig), lvInstanceConfigs, filelistInstanceConf); filelistInstanceConfMD5.Add(GetMD5HashFromFile(file.FullName));
                }
            }

            lLocalModFiles.Text = filelistInstanceMods.Count.ToString();

            compareLists();
        }

        /// <summary>
        /// Sets the path to the repository.
        /// </summary>
        /// <param name="path"></param>
        private void setRepoPath(String path)
        {
            // Check if path even exists
            if (Directory.Exists(path) == false)
            {
                logThis(String.Format("Sorry, but \"{0}\" does not exist!", path));
                return;
            }
            saveDialog.FileName = path;

            // ALL OK
            pathRepository = backSlashPath(path);
            tbPathLocalRepo.Text = pathRepository;

            Properties.Settings.Default.RepositoryPath = pathRepository;
            Properties.Settings.Default.Save();

            //
            RefreshBranchesList();
        }

        /// <summary>
        /// (Re)populates the list of repositories in main repository.
        /// </summary>
        private void RefreshBranchesList()
        {
            if (pathRepository == "")
            {
                logThis("Path to repository has not been set.");
                return;
            }

            listBranches.Clear();
            cbModpacks.Items.Clear();

            DirectoryInfo dir = new DirectoryInfo(pathRepository);
            foreach (DirectoryInfo sub in dir.GetDirectories())
            {
                listBranches.Add(sub.Name);
                cbModpacks.Items.Add(sub.Name);
            }
        }

        private void selectBranch(string branch)
        {
            // Double (triple?) check if the repo is set
            if (pathRepository == "")
            {
                logThis("Path to repository has not been set.");
                return;
            }

            if (branch == "")
            {
                return;
            }

            // Check if path directory even exists
            if (Directory.Exists(pathRepository + branch) == false)
            {
                logThis(String.Format("Specified branch \"{0}\" does not exist.", branch));
                return;
            }

            // All OK, select. Disable dummy branch, seth paths and stuff
            DummyBranch = false;
            selectedLocalBranch = branch;
            pathToBranch = pathRepository + branch + "\\";

            tbPathLocalRepo.Text = pathRepository;
            cbModpacks.SelectedIndex = cbModpacks.Items.IndexOf(branch);

            logThis(string.Format("Selected branch \"{0}\" in \"{1}\"!", branch, pathToBranch));

            // Save application settings
            Properties.Settings.Default.SelectedBranch = branch;
            Properties.Settings.Default.Save();

            // And finally read the files.
            readBranchFiles();
        }

        private void readRemoteBranchFiles() {
            if ( selectedRemoteBranch == "" ) { logThis( "Cannot read branch: none selected." ); return; }

            string modpackManifestFile = selectedRemoteBranch + ".md5";

            DownloadFile( Connection.HTTP.DocumentRoot + modpackManifestFile, pathAppTemp + modpackManifestFile );
            logThis( String.Format( "Saving file {0} to {1}", Connection.HTTP.DocumentRoot + modpackManifestFile, pathAppTemp + modpackManifestFile ) );
            makeDummyBranch( pathAppTemp + modpackManifestFile );

            compareLists();
        }

        //
        private void readBranchFiles()
        {
            // Double (triple?) check if the repo is set
            if (pathRepository == "")
            {
                logThis("Path to repository has not been set.");
                return;
            }

            // Check if path directory even exists
            if (Directory.Exists(pathToBranch) == false)
            {
                logThis(String.Format("Specified branch \"{0}\" does not exist.", pathToBranch));
                return;
            }

            // All OK, read files

            // Clear the lists
            filelistBranchMods.Clear();
            filelistBranchConf.Clear();

            lvBranchMods.Items.Clear();
            lvBranchConfigs.Items.Clear();

            String pathToMods = pathToBranch + "mods\\";
            String pathToConfig = pathToBranch + "config\\";

            if (!Directory.Exists(pathToMods)) { Directory.CreateDirectory(pathToMods); }
            if (!Directory.Exists(pathToConfig)) { Directory.CreateDirectory(pathToConfig); }

            logThis(String.Format("Path to mods: {0}", pathToMods));
            logThis(String.Format("Path to conf: {0}", pathToConfig));

            // SCAN FOR MODS
            {
                DirectoryInfo dir = new DirectoryInfo(pathToMods);
                // Scan for files in subdirs first, for the sake of appearances in lists
                foreach (DirectoryInfo sub in dir.GetDirectories())
                {
                    foreach (FileInfo file in sub.GetFiles("*.jar")) { addFileToList(file.FullName, pathToMods, lvInstanceMods, filelistInstanceMods, "C"); }
                    foreach (FileInfo file in sub.GetFiles("*.zip")) { addFileToList(file.FullName, pathToMods, lvInstanceMods, filelistInstanceMods, "C"); }
                }
                // Now scan main directory for files
                foreach (FileInfo file in dir.GetFiles("*.jar")) { addFileToList(file.FullName, pathToMods, lvInstanceMods, filelistInstanceMods, "C"); }
                foreach (FileInfo file in dir.GetFiles("*.zip")) { addFileToList(file.FullName, pathToMods, lvInstanceMods, filelistInstanceMods, "C"); }
            }

            /*
            // SCAN FOR CONFS
            {
                DirectoryInfo dir = new DirectoryInfo(pathToConfig);
                foreach (FileInfo file in dir.GetFiles("*", SearchOption.AllDirectories)) { addFileToList(truncPath(file.FullName, pathToConfig), lvBranchConfigs, filelistBranchConf); }
            } */

            // SCAN FOR CONFS
            {
                DirectoryInfo dir = new DirectoryInfo(pathToConfig);
                foreach (FileInfo file in dir.GetFiles("*", SearchOption.AllDirectories))
                {
                    string shortPath = truncPath(file.FullName, pathToConfig);
                    string checksum = GetMD5HashFromFile(file.FullName);

                    ListViewItem item = new ListViewItem(shortPath);
                    item.SubItems.Add(checksum);

                    filelistBranchConf.Add(shortPath);
                    filelistBranchConfMD5.Add(checksum);

                    lvBranchConfigs.Items.Add(item);
                    //    addFileToList(truncPath(file.FullName, pathToConfig), lvInstanceConfigs, filelistInstanceConf); filelistInstanceConfMD5.Add(GetMD5HashFromFile(file.FullName));
                }
            }

            compareLists();
        }

        /// <summary>
        /// Checks fileEntry against the fileBlacklist. Returns true if the file is blacklisted.
        /// </summary>
        /// <param name="fileEntry">Filename</param>
        /// <returns></returns>
        private Boolean isBlackListed( string fileEntry ) {
            if ( fileBlacklist.Contains( fileEntry.ToLower() ) ) { return true; } else { return false; }
        }

        /// <summary>
        /// For COMPARING function only.  Edits the 'item' ListView entry and adds the file to the Ignore filelist.
        /// </summary>
        /// <param name="fileEntry"></param>
        /// <param name="item"></param>
        private void addProcessIgnore( string fileEntry, ListViewItem item ) {
            if ( item != null ) {
                item.SubItems[1].Text = "IGNORE";
                item.ForeColor = System.Drawing.Color.LightGray;
                item.BackColor = System.Drawing.Color.White;
            }
            // Only add to the ignore queue if it isn't there already.
            if ( !filelistProcessIgnore.Contains( fileEntry ) ) { filelistProcessIgnore.Add( fileEntry ); }
        }

        /// <summary>
        /// Compares LOCAL lists with the REPO lists and figures out what's missing our out of date. Or stuff.
        /// </summary>
        private void compareLists()
        {
            // If instance is not set, return;
            if (selectedInstance == "")
            {
                logThis("Cannot compare yet: No instance selected");
                return;
            }

            if (selectedRemoteBranch == "")
            {
                logThis("Cannot compare yet: No branch selected.");
                return;
            }

            // Check if the lists of files are done yet.
            // if (filelistInstanceMods.Count == 0) { logThis("List of files in Instance has not been made. Cannot compare yet!");return; }
            if (filelistBranchMods.Count == 0) { logThis("List of files in Branch has not been made. Cannot compare yet!"); return; }

            clearPendingOperations();
            filelistProcessIgnore.Clear();

            // COMPARE MODS
            {
                // REMOVE? First check if mods in Instance are absent in Branch - if so, REMOVE
                foreach (String s in filelistInstanceMods)
                {
                    // Quick reference, reflects the same entry but in ListView
                    ListViewItem item = lvInstanceMods.Items[filelistInstanceMods.IndexOf(s)];

                    // If item is blacklisted, ignore (such as optifine and whatnot, preferential mods)
                    if ( isBlackListed( s ) ) {
                        addProcessIgnore( s, item );
                    } else
                    // If not present in Branch, flag REMOVE
                    if (filelistBranchMods.IndexOf(s) == -1)
                    {
                        // Add the mod entry to items to be removed
                        filelistInstanceModsProcess.Add(s);

                        item.SubItems[1].Text = "REMOVE";
                        item.ForeColor = System.Drawing.Color.Gray;
                        item.BackColor = System.Drawing.Color.LightYellow;
                    }
                    // If exists, all is OK
                    else
                    {
                        item.ForeColor = System.Drawing.Color.Green;
                        item.SubItems[1].Text = "OK";
                    }
                }
                // PULL? Check if you need to pull some mods from the Branch.
                foreach (String s in filelistBranchMods)
                {
                    
                    // ListView link
                    ListViewItem item = lvBranchMods.Items[filelistBranchMods.IndexOf(s)];

                    // If item is blacklisted, ignore
                    if ( isBlackListed( s ) ) {
                        addProcessIgnore( s, item );
                    } else
                    // If item is absent in instance, pull it
                    if (filelistInstanceMods.IndexOf(s) == -1)
                    {
                        // Add to be copied
                        filelistBranchModsProcess.Add(s);

                        item.SubItems[1].Text = "PULL";
                        item.ForeColor = System.Drawing.Color.Navy;
                        item.BackColor = System.Drawing.Color.LightYellow;
                    }
                    // If it exists in list, everything is OK
                    else
                    {
                        item.ForeColor = System.Drawing.Color.Green;
                        item.BackColor = System.Drawing.Color.White;
                        item.SubItems[1].Text = "OK";
                    }
                }
                // CHECKSUM MISMATCH?

                foreach (String s in filelistBranchMods)
                {
                    // Verify checksums!
                    // Check if the file is in the instance already. If so, compare checksum with the RIGHT
                    if (filelistInstanceMods.IndexOf(s) >= 0)
                    {
                        String MD5Local = filelistInstanceModsMD5[filelistInstanceMods.IndexOf(s)];
                        String MD5Remot = filelistBranchModsMD5[filelistBranchMods.IndexOf(s)];

                        ListViewItem item = lvInstanceMods.Items[filelistInstanceMods.IndexOf( s )];

                        // If item is blacklisted, ignore
                        if ( isBlackListed( s ) ) {
                            addProcessIgnore( s, item );
                        } else
                        if (MD5Local != MD5Remot)
                        {
                            filelistInstanceModsProcess.Add(s);
                            filelistBranchModsProcess.Add(s);

                            item.SubItems[1].Text = "REMOVE";
                            item.ForeColor = System.Drawing.Color.Red;
                            item.BackColor = System.Drawing.Color.LightYellow;

                            item = lvBranchMods.Items[filelistBranchMods.IndexOf(s)];
                            item.SubItems[1].Text = "PULL";
                            item.ForeColor = System.Drawing.Color.Navy;
                            item.BackColor = System.Drawing.Color.LightYellow;
                        }
                    }
                }
            }
            // END OF MODS

            // COMPARE CONFIGS
            {
                // MD5 MISMATCH? First, check if every config in instance matches the Branch
                foreach (string s in filelistInstanceConf)
                {
                    // Iterator, gets index of current item.
                    int i = filelistInstanceConf.IndexOf(s);

                    // If the Instance config exists in Branch list, check for checksum differences. If different, MARK.
                    if (filelistBranchConf.IndexOf(s) >= 0)
                    {
                        string MD5Instance = filelistInstanceConfMD5[i];
                        string MD5Branch = filelistBranchConfMD5[filelistBranchConf.IndexOf(s)];

                        ListViewItem itemL = lvInstanceConfigs.Items[i];
                        ListViewItem itemR = lvBranchConfigs.Items[filelistBranchConf.IndexOf(s)];


                        // If item is blacklisted, ignore
                        if ( isBlackListed( s ) ) {
                            addProcessIgnore( s, itemR );
                        } else
                        if (MD5Instance != MD5Branch)
                        {
                            // MARK
                            filelistBranchConfProcess.Add(s);
                            // Visuals
                            itemL.ForeColor = System.Drawing.Color.Red;
                            itemL.BackColor = System.Drawing.Color.LightYellow;
                            itemR.ForeColor = System.Drawing.Color.Navy;
                            itemR.BackColor = System.Drawing.Color.LightYellow;
                        }
                        else
                        {
                            // Visuals
                            itemL.ForeColor = System.Drawing.Color.Black;
                            itemL.BackColor = System.Drawing.Color.White;
                            itemR.ForeColor = System.Drawing.Color.Black;
                            itemR.BackColor = System.Drawing.Color.White;
                        }
                    }
                }

                // PULL? Pull the file from Branch if it does not exist in Instance
                foreach (string s in filelistBranchConf)
                {
                    // Index in list
                    int i = filelistBranchConf.IndexOf(s);
                    ListViewItem itemR = lvBranchConfigs.Items[filelistBranchConf.IndexOf( s )];

                    // If item is blacklisted, ignore
                    if ( isBlackListed( s ) ) {
                        addProcessIgnore( s, itemR );
                    } else
                    // If the file does not exist in instance, but is in repo, flag it!
                    if (filelistInstanceConf.IndexOf(s) == -1)
                    {
                        // FLAG
                        filelistBranchConfProcess.Add(s);
                        // Visuals
                        itemR.ForeColor = System.Drawing.Color.Navy;
                        itemR.BackColor = System.Drawing.Color.LightYellow;
                    }
                }
            }
            // END OF CONFIGS

            // Summarize changes to be made, using lvChangesPending ListView...
            lvChangesPending.Items.Clear();
            foreach (string s in filelistInstanceModsProcess)
            {
                ListViewItem item = new ListViewItem(s);
                item.SubItems.Add("Remove mod");
                item.ForeColor = System.Drawing.Color.Red;

                lvChangesPending.Items.Add(item);
            }
            foreach (string s in filelistBranchModsProcess)
            {
                ListViewItem item = new ListViewItem(s);
                item.SubItems.Add("Download mod");
                item.ForeColor = System.Drawing.Color.LimeGreen;
                lvChangesPending.Items.Add(item);
            }
            foreach (string s in filelistBranchConfProcess)
            {
                ListViewItem item = new ListViewItem(s);
                item.SubItems.Add("Update config");
                item.ForeColor = System.Drawing.Color.LightGreen;
                lvChangesPending.Items.Add(item);
            }
            foreach ( string s in filelistProcessIgnore ) {
                ListViewItem item = new ListViewItem();
                item.Text = s;
                item.SubItems.Add( "Ignore entry" );
                item.ForeColor = Color.LightGray;

                lvChangesPending.Items.Add( item );
            }

            lRemoteModFiles.Text = filelistBranchMods.Count.ToString();
            lFilesToDownload.Text = filelistBranchModsProcess.Count.ToString();
            lFilesToRemove.Text = filelistInstanceModsProcess.Count.ToString();
        }

        public frmMain()
        {
            InitializeComponent();
            // See Main.ApplicationFunctions.cs
        }

        private void bBrowseInstancePath_Click(object sender, EventArgs e)
        {
            // Browse for the MultiMC folder
            if (fdBrowse.ShowDialog() == DialogResult.OK)
            {
                setMultiMCPath(fdBrowse.SelectedPath);
            }
            //fdBrowse.ShowDialog();
        }

        private void tabsInstance_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabsInstance.SelectedIndex != 3)
            {
                tabsRepository.SelectedIndex = tabsInstance.SelectedIndex;
            }
        }

        private void tabsRepository_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabsInstance.SelectedIndex = tabsRepository.SelectedIndex;
        }

        private void cbInstances_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectInstance(cbInstances.Text);
        }

        private void bRefreshInstance_Click(object sender, EventArgs e)
        {
            // Refresh the SELECTED instance
            string tmp = selectedInstance;
            refreshInstancesList();
            selectInstance(tmp);
        }

        private void selectRemoteBranch( String branch ) {
            selectedRemoteBranch = branch;
            

            Properties.Settings.Default.SelectedBranch = branch;
            Properties.Settings.Default.Save();

            cbModpacks.Text = branch;
            readRemoteBranchFiles();
        }

        private void cbModpacks_SelectedIndexChanged(object sender, EventArgs e)
        {
            //selectBranch(cbModpacks.Text);
            selectRemoteBranch( cbModpacks.Text );
        }

        private void lvInstanceMods_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            lvBranchMods.Columns[0].Width = lvInstanceMods.Columns[0].Width;
            lvBranchMods.Columns[1].Width = lvInstanceMods.Columns[1].Width;
            lvBranchMods.Columns[2].Width = lvInstanceMods.Columns[2].Width;
        }

        private void lvInstanceMods_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            lvBranchMods.Columns[0].Width = lvInstanceMods.Columns[0].Width;
            lvBranchMods.Columns[1].Width = lvInstanceMods.Columns[1].Width;
            lvBranchMods.Columns[2].Width = lvInstanceMods.Columns[2].Width;
        }

        private void lvBranchMods_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            lvInstanceMods.Columns[0].Width = lvBranchMods.Columns[0].Width;
            lvInstanceMods.Columns[1].Width = lvBranchMods.Columns[1].Width;
            lvInstanceMods.Columns[2].Width = lvBranchMods.Columns[2].Width;
        }

        private void lvInstanceConfigs_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            lvBranchConfigs.Columns[0].Width = lvInstanceConfigs.Columns[0].Width;
            lvBranchConfigs.Columns[1].Width = lvInstanceConfigs.Columns[1].Width;
        }

        private void lvBranchConfigs_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            lvInstanceConfigs.Columns[0].Width = lvBranchConfigs.Columns[0].Width;
            lvInstanceConfigs.Columns[1].Width = lvBranchConfigs.Columns[1].Width;
        }

        /// <summary>
        /// Copy mod files from a temporary or a branch folder into the instance
        /// </summary>
        private void updateMods()
        {
            // LOG THINGS TO CHANGE
            // DOES NOT LOG A THING. WHY?
            // BECAUSE IT IS NOT CALLED -_-
            foreach (String s in filelistInstanceModsProcess) { logThis(String.Format("REMOVE: {0}", s)); }
            foreach (String s in filelistBranchModsProcess) { logThis(String.Format("PULL: {0}", s)); }

            // Proceed with MODS update
            #region Delete obsolete mod files (the ones that are no longer in the pack)
            foreach (String s in filelistInstanceModsProcess)
            {
                string fullPath = pathToInstance + "mods\\" + s;
                logThis(String.Format("Removing instance mod \"{0}\" at path \"{1}\"...", s, fullPath));
                File.Delete(fullPath);
            }
            #endregion

            #region Copy files from branch to the instance
            foreach (String s in filelistBranchModsProcess)
            {
                string sourceFile = pathToBranch + "mods\\" + s;
                string destinationFile = pathToInstance + "mods\\" + s;

                // CREATE PATH IF DOESN'T EXIST
                string newDir = pathToInstance + "mods\\" + getFilePath(s);
                if (!Directory.Exists(newDir)) { Directory.CreateDirectory(newDir); logThis(String.Format("Creating required directory: {0}", newDir)); }

                logThis(String.Format("Copying branch mod \"{0}\" as an instance mod \"{1}\"...", sourceFile, destinationFile));
                try
                {
                    File.Copy(sourceFile, destinationFile);
                }
                catch
                {
                    logThis(String.Format("Exception upon copying file \"{0}\" to \"{1}\"!", sourceFile, destinationFile));
                }
            }
            #endregion
        }

        /// <summary>
        /// Copy configs from temporary or branch folder into instance
        /// </summary>
        private void updateConfigs()
        {
            // Proceed with CONFIGS update
            foreach (String s in filelistBranchConfProcess)
            {
                string sourceFile = pathToBranch + "config\\" + s;
                string destinationFile = pathToInstance + "config\\" + s;

                // CREATE PATH IF DOESN'T EXIST
                string newDir = pathToInstance + "config\\" + getFilePath(s);
                if (!Directory.Exists(newDir)) { Directory.CreateDirectory(newDir); logThis(String.Format("Creating required directory: {0}", newDir)); }

                logThis(String.Format("Copying branch config {0} as an instance config {1}...", sourceFile, destinationFile));
                if (File.Exists(destinationFile)) { File.Delete(destinationFile); }
                File.Copy(sourceFile, destinationFile);

                //readInstanceFiles();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (selectedInstance == "" || selectedLocalBranch == "" || pathToBranch == "" || pathToInstance == "")
            {
                MessageBox.Show("You must first select both an instance and a branch to continue!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (filelistInstanceModsProcess.Count == 0 && filelistBranchModsProcess.Count == 0 && filelistBranchConfProcess.Count == 0)
            {
                MessageBox.Show("Nothing to update! Yey! ... I hope?", "No action necessary", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (filelistInstanceModsProcess.Count == 0 && filelistBranchModsProcess.Count == 0 && filelistBranchConfProcess.Count > 0)
            {
                DialogResult r = MessageBox.Show("There are no mods to be outdated, however your config files are out of date. Do you want to update them?", "Configs out of date", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    updateConfigs();
                    MessageBox.Show("Sucessfully updated! ... I hope.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    readInstanceFiles();
                    return;
                }
            }

            DialogResult result = MessageBox.Show("Do you really want to proceed with the update? If you're not sure, please consult the Pending Changes list!", "Are you absolutely sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                updateMods();
                if (filelistBranchConfProcess.Count > 0)
                {
                    DialogResult result2 = MessageBox.Show("Do you also want to update your config files?", "Update configs?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result2 == DialogResult.Yes)
                    {
                        updateConfigs();
                    }
                }
                MessageBox.Show("Sucessfully updated! ... I hope.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                readInstanceFiles();
            }
        }

        public class ModInfo {
            public string FileName;            
        }

        private void tsbSaveLocalManifest_Click(object sender, EventArgs e)
        {
            if (pathToInstance == "")
            {
                MessageBox.Show("No instance selected. Please select an instance before proceeding!", "No instance selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (saveDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string pathToMods = pathToInstance + "mods\\";
            string pathToConfig = pathToInstance + "config\\";

            List<string> MD5Manifest = new List<string>();

            foreach (String s in filelistInstanceMods)
            {
                String filename = pathToMods + s;
                MD5Manifest.Add(String.Format("{0} *{1}", GetMD5HashFromFile(filename), "mods\\" + s));
            }

            foreach (String s in filelistInstanceConf)
            {
                String filename = pathToConfig + s;
                MD5Manifest.Add(String.Format("{0} *{1}", GetMD5HashFromFile(filename), "config\\" + s));
            }
            File.WriteAllLines(saveDialog.FileName, MD5Manifest);
        }

        private void btnBrowseRepositoryPath_Click(object sender, EventArgs e)
        {
            if (fdBrowse.ShowDialog() == DialogResult.OK)
            {
                if (!Directory.Exists(fdBrowse.SelectedPath)) { return; }

                setRepoPath(fdBrowse.SelectedPath);
            }
        }

        private void lvBranchMods_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {

        }

        private void lvInstanceConfigs_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {

        }

        private void lvBranchConfigs_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {

        }

        /// <summary>
        /// Clears all comparison results and the formatting of the lists
        /// </summary>
        private void clearPendingOperations()
        {
            lvChangesPending.Items.Clear();

            filelistInstanceModsProcess.Clear();
            filelistBranchConfProcess.Clear();
            filelistBranchModsProcess.Clear();

            Compared = false;

            foreach (ListViewItem item in lvInstanceMods.Items)
            {
                item.ForeColor = System.Drawing.Color.Black;
                item.BackColor = System.Drawing.Color.White;
                item.SubItems[1].Text = "";
            }
        }

        /// <summary>
        /// Deselects the Branch
        /// </summary>
        private void deselectBranch()
        {
            selectedLocalBranch = "";
            pathToBranch = "";

            cbModpacks.SelectedIndex = -1;

            lvBranchMods.Items.Clear();
            lvBranchConfigs.Items.Clear();

            filelistBranchMods.Clear();
            filelistBranchConf.Clear();
            filelistBranchConfMD5.Clear();
        }

        /// <summary>
        /// Clears the filelist variables for Remote Branch
        /// </summary>
        private void clearFilelistBranch() {
            filelistBranchConf.Clear();
            filelistBranchMods.Clear();
            filelistBranchConfMD5.Clear();
            filelistBranchModsMD5.Clear();
            lvBranchMods.Items.Clear();
            lvBranchConfigs.Items.Clear();
        }

        /// <summary>
        /// Creates a virtual, dummy Branch from the MD5 file.
        /// </summary>
        /// <param name="manifestFile"></param>
        private void makeDummyBranch(String manifestFile)
        {
            clearPendingOperations();
            clearFilelistBranch();

            //List<string> MD5Manifest = new List<string>();
            string[] MD5Manifest;

            MD5Manifest = File.ReadAllLines(manifestFile);
            foreach (string s in MD5Manifest)
            {
                String Hash;
                String Group;
                String Name;
                String Path;

                int posA = s.IndexOf(" ");
                int posB = s.IndexOf("*");

                Hash = s.Substring(0, posA);
                Path = s.Substring(posB + 1);
                Group = Path.Substring(0, Path.IndexOf("\\"));
                Name = Path.Substring(Path.IndexOf("\\") + 1);

                switch (Group)
                {
                    case "mods":
                        {
                            filelistBranchMods.Add(Name);
                            filelistBranchModsMD5.Add(Hash);

                            ListViewItem item = new ListViewItem(Name);
                            item.SubItems.Add("");
                            item.SubItems.Add(Hash);
                            lvBranchMods.Items.Add(item);
                            break;
                        }
                    case "config":
                        {
                            filelistBranchConf.Add(Name);
                            filelistBranchConfMD5.Add(Hash);

                            ListViewItem item = new ListViewItem(Name);
                            item.SubItems.Add(Hash);
                            lvBranchConfigs.Items.Add(item);
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// DO NOT USE, OLD CODE
        /// Checks for the current, mainstream modpack of the MC and compare remote ('current.md5') manifest file with the CURRENTLY SELECTED instance.
        /// PROMPTS for update, not good for "yes, I'm sure to update, don't ask me".
        /// </summary>
        private void checkForUpdateMainstream() {
            // Download the CURRENT manifest file!
            string remoteUri = Connection.HTTP.DocumentRoot;
            string fileName = selectedRemoteBranch + ".md5", webSource = null, localPath = pathApp + fileName;
            //string fileName = "current.md5", webSource = null;
            //string localPath = pathApp + "current.md5";

            // Create WebClient
            WebClient Client = new WebClient();
            webSource = remoteUri + fileName;

            logThis( String.Format( "Attempting to download current manifest at {0}...", webSource ) );
            // Attempt to download the file
            try {
                // Remove cached manifest. Should resolve this weird issue of updater not seeing the new file on web.
                if ( File.Exists( localPath ) ) { File.Delete( localPath ); }
                Client.DownloadFile( webSource, localPath );
            }
            // If there's an error, catch it and abort.
            catch ( WebException error ) {
                logThis( String.Format( "Error occured while downloading the manifest file: \r\n\r\n{0}", error.Message ), LogLevel.ERROR );
                MessageBox.Show( String.Format( "Error occured while downloading the manifest file: \r\n\r\n{0}", error.Message ), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                return;
            }
            // If the file has been downloaded successfuly, compare the instance to the dummy repo.
            finally {
                // Make the Dummy Repo from the file.
                tbPathLocalRepo.Text = webSource;
                makeDummyBranch( localPath );
                // Compare the contents
                compareLists();

                // If, after comparing, there are some files to be downloaded, GET ON THE JOB
                if ( filelistBranchModsProcess.Count > 0 || filelistInstanceModsProcess.Count > 0 ) {
                    // Ask the user to update
                    DialogResult result = MessageBox.Show( "You need to update. Do you want to update now?", "Update required!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation );
                    if ( result == DialogResult.Yes ) {
                        downloadUpdate();
                        //return;
                    }
                }
                // Configs have changed, but are not required.
                else if ( filelistBranchConfProcess.Count > 0 ) {
                    // Ask the user to update
                    DialogResult result = MessageBox.Show( "Your mods are up to date, but the configs are mismatched. Do you want to update them now?", "You are ok! ... for the most part", MessageBoxButtons.YesNo, MessageBoxIcon.Information );
                    if ( result == DialogResult.Yes ) {
                        downloadUpdate();
                        //return;
                    }
                }
                else {
                    MessageBox.Show( "Your instance is up to date!", "Up to date", MessageBoxButtons.OK, MessageBoxIcon.Information );
                }
            }
        }

        #region File Downloader

        // Global variables
        public static Boolean DownloadInProgress = false;
        public static String CurrentFileDownload = "";

        // public delegate void DownloadFileCallback2(Object sender,AsyncCompletedEventArgs e);
        public void DownloadFileCallback2(Object sender, AsyncCompletedEventArgs e)
        {
            DownloadInProgress = false;
        }

        public void DownloadFileProgress(Object sender, DownloadProgressChangedEventArgs e)
        {
            pbProgressFile.Maximum = 100;
            pbProgressFile.Value = e.ProgressPercentage;

            pbProgressFile2.Maximum = 100;
            pbProgressFile2.Value = e.ProgressPercentage;
            


            // Display percentage progress of download in the appropriate field
            tssCurrentFileProgress.Text = String.Format("{0}%", e.ProgressPercentage.ToString());

            // OBSOLETE!!!
            // Do not overrite status anymore, just the download percentage
            // lStatus.Text = String.Format("({0}%) {1}" , e.ProgressPercentage.ToString() , CurrentFileDownload);
        }

        private Boolean DownloadFile( String RemoteFile, String LocalFile ) {

           // TODO FTP DOWNLOAD TOP PRIORITY
            #region FTP DOWNLOAD
            //{
            //    // Get the object used to communicate with the server.
            //    Uri uri = new Uri( RemoteFile );
            //    FtpWebRequest FTPRequest = (FtpWebRequest)WebRequest.Create( "ftp://www.contoso.com/test.htm" );
            //    FTPRequest.Method = WebRequestMethods.Ftp.DownloadFile;

            //    // This example assumes the FTP site uses anonymous logon.
            //    FTPRequest.Credentials = new NetworkCredential( "anonymous", "janeDoe@contoso.com" );

            //    FtpWebResponse response = (FtpWebResponse)FTPRequest.GetResponse();

            //    Stream responseStream = response.GetResponseStream();
            //    StreamReader reader = new StreamReader( responseStream );
            //    Console.WriteLine( reader.ReadToEnd() );

            //    Console.WriteLine( "Download Complete, status {0}", response.StatusDescription );

            //    reader.Close();
            //    response.Close();  
            //}
            #endregion

            #region HTTP DOWNLOAD
            {
                WebClient Client = new WebClient();
                Uri uri = new Uri( RemoteFile );

                // If local file exists, overwrite
                if ( File.Exists( LocalFile ) ) {
                    File.Delete( LocalFile );
                }

                // Attempt to download the file
                try {
                    Client.DownloadFileCompleted += new AsyncCompletedEventHandler( DownloadFileCallback2 );
                    Client.DownloadProgressChanged += new DownloadProgressChangedEventHandler( DownloadFileProgress );
                    Client.DownloadFileAsync( uri, LocalFile );
                    DownloadInProgress = true;
                    CurrentFileDownload = RemoteFile;
                    //Client.DownloadFile(RemoteFile , LocalFile);
                }
                // If there's an error... oh well. Abort.
                catch ( WebException e ) {
                    logThis( String.Format( "Error downloading file \"{0}\": {1}", RemoteFile, e.Message ) );
                    return false;
                }
                // Wait for file to download;
                while ( DownloadInProgress == true ) {
                    Application.DoEvents();
                }
                return true;
            }
            #endregion

        }
        #endregion

        /// <summary>
        /// A workaround for calling downloadUpdate() without parameters. Downloads CURRENT modpack.
        /// </summary>
        private void downloadUpdate() {
            downloadUpdate( "current" );
        }

        /// <summary>
        /// Downloads a mod file and saves it to the cache
        /// </summary>
        /// <param name="ModFile"></param>
        /// <param name="Destination"></param>
        private void downloadMod( String ModFile, String MD5 ) {
            String SourceURL = forwardSlashPath( Connection.HTTP.DocumentRoot + MODS_FOLDER );
            String SourceFile = SourceURL + ModFile;
            SourceFile = SourceFile.Replace( "\\", "/" );
            String DestFile = pathAppTemp + "mods\\" + ModFile;

            logThis( String.Format( "Downloading mod \"{0}\" from \"{1}\", MD5 Checksum {2}", ModFile, SourceFile, MD5 ) );
            DownloadFile( SourceFile, DestFile );

            String checkMD5 = GetMD5HashFromFile( DestFile );
            if ( checkMD5 != MD5 ) {
                filelistFailedDownload.Add( ModFile );
            }

        }

        /// <summary>
        /// Downloads the mismatched and missing files, based on the checkForUpdate() results.
        /// </summary>
        private void downloadUpdate(String modpack) {
            toggleUserControls( false );
            // Define static paths
                // Local directory paths
                    // Path to temp mods dir
                    String localPathMods = pathAppTemp + "mods\\";
                    // Path to temp conf dir
                    String localPathConfig = pathAppTemp + "config\\";

                // Remote paths
                    // Make sure the path is forward-slashed
                    Connection.HTTP.DocumentRoot = forwardSlashPath( Connection.HTTP.DocumentRoot );
                    // URL to the directory containing mod JARs
                    String PATH_TO_REMOTE_MODS_DIR = forwardSlashPath( Connection.HTTP.DocumentRoot + MODS_FOLDER );
                    // URL to config root
                    String PATH_TO_REMOTE_CONF_DIR = forwardSlashPath( Connection.HTTP.DocumentRoot + selectedRemoteBranch ) + "config/";

            filelistFailedDownload.Clear();

            // Create tmp dirs if needed
            if ( !Directory.Exists( localPathMods ) ) {
                Directory.CreateDirectory( localPathMods );
            }
            if ( !Directory.Exists( localPathConfig ) ) {
                Directory.CreateDirectory( localPathConfig );
            }

            #region Step #0: Fetch the files from the web in a try{} clause.
            // Download all the files
            try {
                pbProgressTotal.Value = 0;
                pbProgressTotal.Maximum = filelistBranchModsProcess.Count;
                pbProgressTotal2.Value = 0;
                pbProgressTotal2.Maximum = filelistBranchModsProcess.Count;

                int Current = 1, Max = filelistBranchModsProcess.Count;

                // Download the Mod files from the repository
                #region Download Mod Files
                {
                    foreach ( string s in filelistBranchModsProcess ) {
                        // Prepare the directory for the file
                        String newDir = localPathMods + getFilePath( s );
                        if ( !Directory.Exists( newDir ) ) {
                            Directory.CreateDirectory( newDir );
                        }
                        // Target local path for the new (downloaded) file
                        String DestFile = localPathMods + s;

                        String MD5 = filelistBranchModsMD5[filelistBranchMods.IndexOf( s )];

                        // Create URL and format it properly
                        //String RemoteFile = WEB_ADDRESS_CURRENT_DO_NOT_USE + "mods/" + s;
                        //String RemoteFile = remoteBranchRoot + "mods/" + s;
                        String RemoteFile = PATH_TO_REMOTE_MODS_DIR + s;              // Once you implement MASTER MODS DIR, remove 'mods/'!
                        // Manifest uses non-web backward slashes. Convert them so that the URIs are valid
                        RemoteFile = RemoteFile.Replace( "\\", "/" );

                        // Log activity
                        logThis( String.Format( "Downloading File ({0} of {1}): \"{2}\" from \"{3}\" to \"{4}\"...", Current.ToString(), Max.ToString(), s, RemoteFile, newDir ) );
                        //lStatus.Text = String.Format("(Step 1 of 2) (Mod {0} of {1}) Downloading file \"{2}\"..." , Current.ToString() , Max.ToString() , s);
                        // Update statuses. Show what file is downloading and overall progress which file out of how many is being downloaded                        
                        lStatus.Text = String.Format( "{0}", s );
                        lCurrentFile.Text = String.Format( "{0}", s );
                        tssOverallProgress.Text = String.Format( "{0} / {1}", Current.ToString(), Max.ToString() );

                        Application.DoEvents();

                        /*
                         * This bit is a bit buggy! If the cached file is downloaded, but incomplete or corrupted, downloader would still skip it.
                         * 
                            // Only download the file if it does not exist. There might be cached downloads!
                            if ( !File.Exists(DestFile) ) {
                                DownloadFile(RemoteFile , DestFile);
                            }
                         */

                        if ( File.Exists( DestFile ) ) { File.Delete( DestFile ); }
                        //DownloadFile( RemoteFile, DestFile );
                        downloadMod( s, MD5 );

                        pbProgressTotal.Value++;
                        pbProgressTotal2.Value++;
                        Current++;
                    }
                }
                #endregion

                // Download config files from the repository
                #region Download Config Files
                {
                    // Only download them if specifically instructed by the user.
                    //if ( cbIncludeConfigs.Checked == true ) {
                        // Disable the control, so the user won't screw the update.
                        //cbIncludeConfigs.Enabled = false;

                        pbProgressTotal.Value = 0;
                        pbProgressTotal.Maximum = filelistBranchConfProcess.Count;
                        pbProgressTotal2.Value = 0;
                        pbProgressTotal2.Maximum = filelistBranchConfProcess.Count;

                        Current = 1;
                        Max = filelistBranchConfProcess.Count();
                        foreach ( string s in filelistBranchConfProcess ) {
                            // Prepare the directory for the file
                            String newDir = localPathConfig + getFilePath( s );
                            if ( !Directory.Exists( newDir ) ) {
                                Directory.CreateDirectory( newDir );
                            }

                            String DestFile = localPathConfig + s;

                            // Create URL and format it properly
                            //String RemoteFile = WEB_ADDRESS_CURRENT_DO_NOT_USE + "config/" + s;
                            //String RemoteFile = remoteBranchRoot + "config/" + s;
                            String RemoteFile = PATH_TO_REMOTE_CONF_DIR + s;
                            RemoteFile = RemoteFile.Replace( "\\", "/" );

                            // Log activity
                            logThis( String.Format( "Downloading File ({0} of {1}): \"{2}\" from \"{3}\" to \"{4}\"...", Current.ToString(), Max.ToString(), s, RemoteFile, newDir ) );
                            //lStatus.Text = String.Format("(Step 1 of 2) (Mod {0} of {1}) Downloading file \"{2}\"..." , Current.ToString() , Max.ToString() , s);
                            // Update statuses. Show what file is downloading and overall progress which file out of how many is being downloaded                        
                            lStatus.Text = String.Format( "{0}", s );
                            lCurrentFile.Text = String.Format( "{0}", s );
                            tssOverallProgress.Text = String.Format( "{0} / {1}", Current.ToString(), Max.ToString() );

                            Application.DoEvents();

                            //// Only download the file if it does not exist. There might be cached downloads!
                            //if ( !File.Exists( newDir + s ) ) {
                            //    DownloadFile( RemoteFile, DestFile );
                            //}

                            // If the file exists in the cache, delete it
                            if ( File.Exists( DestFile ) ) { File.Delete( DestFile ); }
                            DownloadFile( RemoteFile, DestFile );

                            pbProgressTotal.Value++;
                            pbProgressTotal2.Value++;
                            Current++;
                        }
                    //}
                }
                #endregion

                lStatus.Text = "OK";
            }
            catch {
                MessageBox.Show( "There was a fatal error while downloading the mods. Check logs for details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                toggleUserControls( true );
                return;
            }
            // Finished downloading!
            #endregion

            // LOG
            foreach ( String s in filelistInstanceModsProcess ) { logThis( String.Format( "REMOVE: {0}", s ) ); }
            foreach ( String s in filelistBranchModsProcess ) { logThis( String.Format( "PULL: {0}", s ) ); }

            #region Step #1: Delete marked instance mods. ( filelistInstanceModsProcess )
            foreach ( string s in filelistInstanceModsProcess ) {
                String PathTargetMods = pathToInstance + "mods\\";
                if ( File.Exists( PathTargetMods + s ) ) {
                    File.Delete( PathTargetMods + s );
                }
            }
            #endregion
            #region Step #2: Copy mods from tmp to instance. ( filelistBranchModsProcess )
            // Copy the mods from temporary directory to the instance mods directory.
            foreach ( string s in filelistBranchModsProcess ) {
                //Get path to instance's mods 
                String PathTargetMods = pathToInstance + "mods\\";
                // Create target directories
                String TargetDir = PathTargetMods + getFilePath( s );
                if ( !Directory.Exists( TargetDir ) ) {
                    Directory.CreateDirectory( TargetDir );
                }

                String SourceFile = localPathMods + s;
                String DestFile = PathTargetMods + s;

                // If destination file exists, remove it.
                if ( File.Exists( DestFile ) ) {
                    File.Delete( DestFile );
                }
                if ( File.Exists( SourceFile ) ) {
                    File.Copy( SourceFile, DestFile );
                }
                else {
                    logThis( String.Format( "Tried to copy the file {0}, however the source file was not found. Poke Iggy around to upload that damn file first!", SourceFile ) );
                }
            }
            // Done copying!
            #endregion
            #region Step #3: Copy configs from tmp to instance. ( filelistBranchConfProcess )
            // Again. Only do so if instructed by user. Otherwise, don't mess up with them.
            //if ( cbIncludeConfigs.Checked == true ) {
                foreach ( string s in filelistBranchConfProcess ) {
                    String PathTargetConfig = pathToInstance + "config\\";
                    if ( File.Exists( PathTargetConfig + s ) ) {
                        File.Delete( PathTargetConfig + s );
                    };
                    // Create target directories
                    String TargetDir = PathTargetConfig + getFilePath( s );
                    if ( !Directory.Exists( TargetDir ) ) {
                        Directory.CreateDirectory( TargetDir );
                    }

                    String SourceFile = localPathConfig + s;
                    String DestFile = PathTargetConfig + s;

                    // If destination file exists, remove it.
                    if ( File.Exists( DestFile ) ) {
                        File.Delete( DestFile );
                    }

                    // Copy the file
                    if ( File.Exists( SourceFile ) ) {
                        logThis( String.Format( "Applying the file as {0}", DestFile ) );
                        File.Copy( SourceFile, DestFile );
                    }
                    else {
                        logThis( String.Format( "Tried to copy the file {0}, however the source file was not found. Poke Iggy around to upload that damn file first!", SourceFile ) );
                    }
                }
            //}
            #endregion

            readInstanceFiles();
            toggleUserControls( true );

            if ( filelistFailedDownload.Count > 0 ) {
                string failedMods = "";
                foreach ( string s in filelistFailedDownload ) { failedMods = failedMods + s + "\n\r"; }

                DialogResult d = MessageBox.Show( "Some mods failed to download correctly: "+ failedMods, "Update failed", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error );
                switch ( d ) {
                    case DialogResult.Retry:
                        downloadUpdate( modpack ); break;
                    case DialogResult.Cancel:
                        return;
                    default:
                        return;
                }
            }

        }

        /// <summary>
        /// Allows update with one click. Updates selected, or prompts to select if nothing is selected. Easy!
        /// </summary>
        private void OneClickUpdate() {
            // Check #1 - If MultiMC path isn't selected, prompt...
            if ( pathMultiMC == "" /* && selectedInstance == "" */ ) {
                DialogResult result = MessageBox.Show( "You have not selected a MultiMC directory. To check for an update, you MUST:\r\n\r\n- Browse for the MultiMC directory by clicking the \"...\" button in the left panel,\r\n- Select an instance to check against from within the dropdown menu\r\n\r\nDo you want to browse for path now?",
                    "Not ready!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation );
                switch ( result ) {
                    case ( DialogResult.Yes ): {
                            if ( fdBrowse.ShowDialog() == DialogResult.OK ) {
                                setMultiMCPath( fdBrowse.SelectedPath );
                            }
                            break;
                        }
                    case ( DialogResult.No ): {
                            return;
                        }
                }
            }

            // Check #2 - If the MultiMC path is selected, but no instance is chosen, select the first one from the list.
            if ( pathMultiMC != "" && selectedInstance == "" ) {
                DialogResult result = MessageBox.Show( "You have not selected an instance. Select the first one from the list?\r\nThis is advised only if you have just one instance.",
                    "No instance selected", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation );
                // If OK, chose first instance from list, if CANCEL, cancel the update check and wait for manual entry. Gracefully throw an error if no instances are present.
                switch ( result ) {
                    case DialogResult.OK: {
                            if ( listInstances.Count != 0 ) {
                                selectInstance( listInstances[0] );
                            } else { MessageBox.Show("There are no instances defined, cannot proceed. Please make an instance from within MultiMC first.", "No Instances Found", MessageBoxButtons.OK, MessageBoxIcon.Error ); return; }
                            break;
                        }
                    case DialogResult.Cancel: {
                            return;
                        }
                }
            }

            // Check #3 - Check if remote branch is selected. If not, offer to select current         
            if ( selectedRemoteBranch == "" ) {
                DialogResult result = MessageBox.Show( "No remote branch is selected. Would you like to select a 'current' branch?", "No branch selected", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation );
                switch ( result ) {
                    case DialogResult.OK: {
                            selectRemoteBranch( "current" );
                            break;
                        }
                    case DialogResult.Cancel: { return; }
                }
            }

            // Check #4 - If everything checks out, download update. Make final check for the branch just in case.
            if ( selectedRemoteBranch != "" ) { downloadUpdate( selectedRemoteBranch ); }



            // :: Old Code for PROMPTING for updates.
            // Only check for update if an instance is selected
            /*
            if ( pathMultiMC != "" && selectedInstance != "" ) {
                checkForUpdateMainstream();
            } */
        }

        private void tsbCheckForUpdates_Click(object sender, EventArgs e)
        {
            OneClickUpdate();
        }

        /// <summary>
        /// Downloads the whole online CURRENT branch into the local repository.
        /// </summary>
        private void downloadBranchCurrent()
        {
            /* 
             *  NO OP, uses out of date system of checking for stuff
             */

            return;

            //if (pathRepository == "")
            //{
            //    MessageBox.Show("Whoops! I don't know how you did it, but you have no directory selected as repository! Please select one first!", "No repository selected", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //    return;
            //}

            //// Get manifest!
            //if (File.Exists(pathAppTemp + "current.md5"))
            //{
            //    File.Delete(pathAppTemp + "current.md5");
            //}
            //DownloadFile("http://gaming.iggyslab.com/minecraft/repository/current.md5", pathAppTemp + "current.md5");

            //String[] branchFiles = File.ReadAllLines(pathAppTemp + "current.md5");


            //// Set BranchPath and create it if it does not exist!
            //String BranchPath = pathRepository + "current\\";
            //if (!Directory.Exists(BranchPath)) { Directory.CreateDirectory(BranchPath); }

            //// convert string array to List of strings;
            //List<string> BranchFiles = new List<string>();
            //foreach (string s in branchFiles)
            //{
            //    BranchFiles.Add(s);
            //}

            //// ... and clear it of all files, just in case we'd get some IO errors.
            //DirectoryInfo BranchDir = new DirectoryInfo(BranchPath);
            //foreach (FileInfo f in BranchDir.GetFiles("*", SearchOption.AllDirectories))
            //{
            //    File.Delete(f.FullName);
            //}

            //pbProgress.Maximum = BranchFiles.Count;
            //pbProgress.Value = 0;

            //int Current = 0, Max = BranchFiles.Count;

            //// Now, get the list of files to download.
            //foreach (string s in BranchFiles)
            //{
            //    String MD5FileString = s.Substring(s.IndexOf("*") + 1);
            //    String TargetDirectory = BranchPath + getFilePath(MD5FileString);
            //    String TargetFile = BranchPath + MD5FileString;
            //    String RemoteFile = "http://gaming.iggyslab.com/minecraft/repository/current/" + MD5FileString;
            //    RemoteFile = RemoteFile.Replace("\\", "/");

            //    // Create file's target directory if not present
            //    if (!Directory.Exists(TargetDirectory))
            //    {
            //        Directory.CreateDirectory(TargetDirectory);
            //    }


            //    lStatus.Text = String.Format("(File {0} of {1}) \"{2}\"...", Current, Max, MD5FileString);
            //    logThis(String.Format("Downloading file {0} of {1}: \"{2}\" as \"{3}\"", Current, Max, MD5FileString, TargetFile));

            //    Application.DoEvents();

            //    if (!File.Exists(TargetFile))
            //    {
            //        DownloadFile(RemoteFile, TargetFile);
            //    }

            //    Application.DoEvents();

            //    Current++;
            //    pbProgress.Value++;
            //}

            //selectBranch("current");
        }

        private void tsbDownBranch_Click(object sender, EventArgs e)
        {
            downloadBranchCurrent();
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            if (pathMultiMC != "")
            {
                System.Diagnostics.Process.Start(pathMultiMC + "MultiMC.exe");
                Close();
            }
        }


        private void cbIncludeConfigs_CheckedChanged( object sender, EventArgs e ) {

        }

        private void updaterDownloadUpdate( Boolean force = false ) {
            toggleUserControls( false );
            lvChangesPending.Clear();
            String appExeTemp = APP_EXENAME + ".tmp";
            String appExeName = System.IO.Path.GetFileNameWithoutExtension( APP_EXENAME );
            
            // Write the update BATCH file script
            StreamWriter f = File.CreateText( "updatebustersapp.bat" );
            f.WriteLine("@ECHO OFF");
             f.WriteLine("sleep 1");
             f.WriteLine( String.Format( "copy {0} {1}-{2}.{3}.exe",APP_EXENAME, appExeName, VERSION, BUILD ) ); // Make a copy of current build, just in case (i.e.: BMC-1.1.24.exe)
             f.WriteLine( String.Format( "copy {0} {1}", appExeTemp, APP_EXENAME));
             f.WriteLine( String.Format( "del {0}", appExeTemp));
             f.WriteLine( String.Format( "start {0}", APP_EXENAME));
             f.WriteLine( "@ECHO ON" );
            f.Close();

            // Try to download the update. If successful, launch update script.
            try {
                foreach ( string s in UPDATER_WEB_FILES ) {
                    string newFilename;
                    if ( s == APP_EXENAME ) { newFilename = appExeTemp; } else { newFilename = s; }
                    DownloadFile( UPDATER_WEB_ROOT + s, backSlashPath( pathApp ) + newFilename );
                }
            }
            finally {
                MessageBox.Show( "The application will now exit and update.", "Update available.", MessageBoxButtons.OK, MessageBoxIcon.Information );
                System.Diagnostics.Process.Start( "updatebustersapp.bat" );
                Application.Exit();
            }
        }

        /// <summary>
        /// Checks whether the client is up to date.
        /// </summary>
        /// <returns></returns>
        public Boolean upToDate() {
            int online_version = 0;

            try {
                logThis( String.Format( "Checking for newer version... {0}", UPDATER_WEB_ROOT + UPDATER_VERSION_FILE ) );
                DownloadFile( UPDATER_WEB_ROOT + UPDATER_VERSION_FILE, backSlashPath( pathAppTemp ) + "version" );
                online_version = Convert.ToInt16( File.ReadAllText( backSlashPath( pathAppTemp ) + "version" ) );
            }
            catch ( Exception e ) {
                logThis( String.Format( "Error chceking for update. Assuming newest. ({0})", e.Message ) );
                return true;
            }
            finally {
                logThis( String.Format( "Current version: {0}; Remote Version: {1}", BUILD.ToString(), online_version.ToString() ) );
                lVersionOnline.Text = online_version.ToString();
            }

            if ( online_version > BUILD ) { return false; } else { return true; }
        }

        // Right-clock on List View of Pending Changes? Copy the entry to clipboard!
        private void lvChangesPending_MouseClick( object sender, MouseEventArgs e ) {
            if ( e.Button == MouseButtons.Right ) {
                if ( lvChangesPending.SelectedItems != null ) { Clipboard.SetText( lvChangesPending.SelectedItems[0].Text ); }
            }
        }

        private void btnUpdate_Click( object sender, EventArgs e ) {
            updaterDownloadUpdate();
        }


        

        /// <summary>
        /// Splits a string into array of strings. (Using "\r\n" as delimeter, useful for TextBox.Text fields)
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string[] StringAsArray( string text ) {
            string[] delimString = {"\r\n"};
            return text.Split(delimString,StringSplitOptions.None);
        }

        private void frmMain_FormClosing( object sender, FormClosingEventArgs e ) {

            // Write the Blacklist
            StreamWriter f = File.CreateText( backSlashPath( pathApp ) + "blacklist" );
            foreach ( string s in fileBlacklist ) { f.WriteLine( s ); }
            f.Close();
        }

        private void tbBlacklist_TextChanged( object sender, EventArgs e ) {
            tbBlacklist.ForeColor = Color.LightGreen;
        }

        private void button1_Click( object sender, EventArgs e ) {
            initBlacklistFromTextbox();
        }

        /// <summary>
        /// Loads the fileBlacklist into memory, from the text field
        /// </summary>
        private void initBlacklistFromTextbox() {
            // Button that loads Blacklist from form controll into memory.
            fileBlacklist.Clear();
            fileBlacklist.AddRange(StringAsArray( tbBlacklist.Text ));
            // Convert all into lowercase
            for (int i = 0 ;  i < fileBlacklist.Count() ; i++ )
            {
                fileBlacklist[i] = fileBlacklist[i].ToLower();
            }
            tbBlacklist.Text = String.Join( "\r\n", fileBlacklist );
            tbBlacklist.ForeColor = Color.FromArgb( 216, 216, 216 );
        }

        private void tsbAppUpdate_Click( object sender, EventArgs e ) {
            updaterDownloadUpdate();
        }

        private void label8_Click( object sender, EventArgs e ) {

        }

        private void lLocalModFiles_Click( object sender, EventArgs e ) {
        }

        public void refreshModpackList() {
            DownloadFile( Connection.HTTP.DocumentRoot + "modpacks", pathAppTemp + "modpacks" );

            StreamReader f;
            f = File.OpenText( pathAppTemp + "modpacks" );

            cbModpacks.Items.Clear();

            while (!f.EndOfStream) {
                string s = f.ReadLine();
                logThis(String.Format("Registering modpack {0}", s));
                cbModpacks.Items.Add( s );
            }

            f.Close();

        }

        private void bRefreshRepository_Click( object sender, EventArgs e ) {

            // Refresh the SELECTED instance
            string tmp = selectedRemoteBranch;
            refreshModpackList();
            selectRemoteBranch( tmp );
        }

        private void lFilesToDownload_Click( object sender, EventArgs e ) {

        }

        private void btnUpdateSelected_Click( object sender, EventArgs e ) {
            if ( selectedRemoteBranch != "" ) { downloadUpdate( selectedRemoteBranch ); }
        }

        private void lvInstanceMods_SelectedIndexChanged( object sender, EventArgs e ) {

        }

        private void eConnectionHTTPUri_TextChanged( object sender, EventArgs e ) {
            eConnectionHTTPUri.ForeColor = Color.Crimson;
        }

        private void btnApplyRepoURI_Click( object sender, EventArgs e ) {
            Connection.HTTP.DocumentRoot = eConnectionHTTPUri.Text;
            Properties.Settings.Default.HTTP_DocumentRoot = eConnectionHTTPUri.Text;
            eConnectionHTTPUri.ForeColor = Color.ForestGreen;
            Properties.Settings.Default.Save();
        }
    }

 
}

namespace IggyUtils {
    class ModPack {
        /// <summary>
        /// List item containing information about the file.
        /// </summary>
        class CustomFileItem {
            public string FileName;
            public string MD5;
            public string Path;

            /// <summary>
            /// Adds a file entry with just its name.
            /// </summary>
            /// <param name="FileName"></param>
            public CustomFileItem( string FileName ) {
                // TODO: Complete member initialization
                this.FileName = FileName;
                this.Path = "";
                this.MD5 = "";
            }

            /// <summary>
            /// Adds a file entry with the MD5 checksum
            /// </summary>
            /// <param name="FileName"></param>
            /// <param name="MD5"></param>
            public CustomFileItem( string FileName, string MD5 ) {
                // TODO: Complete member initialization
                this.FileName = FileName;
                this.MD5 = MD5;
                this.Path = "";
            }

            /// <summary>
            /// Adds file entry with its ABSOLUTE path.
            /// </summary>
            /// <param name="FileName"></param>
            /// <param name="MD5"></param>
            /// <param name="Path"></param>
            public CustomFileItem( string FileName, string MD5, string Path ) {
                // TODO: Complete member initialization
                this.FileName = FileName;
                this.MD5 = MD5;
                this.Path = Path;
            }

        }

        /// <summary>
        /// Custom class handling the list of fileEntry lists.
        /// </summary>
        class CustomFileItemList {
            public List<CustomFileItem> Items;

            public CustomFileItemList() {
                Items = new List<CustomFileItem>();
            }

            public void Clear() {
                Items.Clear();
            }

            public void AddItem( String FileName, String MD5 = "", String Path = "" ) {
                CustomFileItem Entry = new CustomFileItem( FileName, MD5, Path );
                this.Items.Add( Entry );
            }

            public CustomFileItem Find( string FileName ) {
                foreach ( CustomFileItem f in Items ) {
                    if ( f.FileName.ToLower() == FileName ) {
                        return f;
                    }
                }
                return null;
            }

        }
    }

}