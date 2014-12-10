using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;
using System.IO;

namespace ExcelSql
{
    /// <summary>
    /// Main form
    /// </summary>
    public partial class MainForm : Form
    {

        const string TEMP_TABLES_FOLDER = "tables\\";

        OpenFileDialog openFileDialog;
        FileImporter fileImporter;
        

        List<TableFile> tableFiles;
        /// <summary>
        /// List of table files
        /// </summary>
        public List<TableFile> TableFiles
        {
            get { return tableFiles; }
        }

        string tempTablesPath;
        /// <summary>
        /// Folder for all tables
        /// </summary>
        public string TempTablesPath
        {
            get { return tempTablesPath; }
        }

        public MainForm()
        {
            InitializeComponent();

            tableFiles = new List<TableFile>();
            fileImporter = new FileImporter(this);

            openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select CSV file";
            openFileDialog.Filter = "CSV Files (.csv)|*.csv|Text Files (.txt)|*.txt|XLS Files (.xls)|*.xls";
            openFileDialog.Multiselect = false;

            //Create temp folder for tables
            tempTablesPath = System.Environment.CurrentDirectory + TEMP_TABLES_FOLDER;
            if (Directory.Exists(tempTablesPath))
            {
                Directory.Delete(tempTablesPath, true);
            }
            Directory.CreateDirectory(tempTablesPath);
        }


        /// <summary>
        /// Load new file
        /// </summary>
        private void toolStripButtonLoadFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                //Obtain path and folder
                string filePath = openFileDialog.FileName;
                FileInfo fi = new FileInfo(filePath);
                string folderPath = fi.DirectoryName;
                string fileName = fi.Name;

                try
                {
                    //Import file
                    string newPath = createNewPathToCopy(fileName, this.tempTablesPath);
                    bool result = fileImporter.importFile(filePath, newPath);
                    if (result)
                    {
                        //Query all file content
                        loadFileFromTempFolder(newPath, TableFile.TableType.FromFile, filePath);
                    }

                }
                catch (Exception ex)
                {
                    showError("Error loading file", "Could not load file: " + filePath);
                }
                
            }
        }

        /// <summary>
        /// Load a file from the temp folder and creates a new tab
        /// </summary>
        public void loadFileFromTempFolder(string filePath, TableFile.TableType tableType, string origFilePath)
        {
            //Create table file and add to list
            TableFile tableFile = new TableFile();
            tableFile.init(this, tableType, filePath, origFilePath);
            this.tableFiles.Add(tableFile);

            //Add item to listView
            this.listBoxTables.Items.Add(tableFile);

            //Create tab with default query
            createNewQueryTab(tableFile);
        }

        /// <summary>
        /// Get non-existing path to copy
        /// </summary>
        public string createNewPathToCopy(string origFileName, String destFolder)
        {
            //Remove extension
            string filename = Path.GetFileNameWithoutExtension(origFileName);

            //Replace spaces by underscores
            filename = filename.Replace(" ", "_");

            //Find unique name
            int i = 0;
            while (true)
            {
                string suffix = i > 0 ? "_" + (i + 1) : "";
                string newPath = destFolder + filename + suffix + /*orig.Extension*/".csv";
                i++;

                if (!File.Exists(newPath))
                {
                    return newPath;
                }
            }
        }

        /// <summary>
        /// Show error
        /// </summary>
        public void showError(String title, String msg)
        {
            MessageBox.Show(this, msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void clearLog()
        {
            richTextBoxLog.Clear();
        }

        public void log(string text)
        {
            richTextBoxLog.SelectionColor = Color.Black;
            richTextBoxLog.SelectedText = text + Environment.NewLine;
            richTextBoxLog.ScrollToCaret();
        }

        public void logError(string text)
        {
            richTextBoxLog.SelectionColor = Color.Red;
            richTextBoxLog.SelectedText = text + Environment.NewLine;
            richTextBoxLog.ScrollToCaret();
        }


        /// <summary>
        /// Double clic on a file in ListView
        /// </summary>
        private void listBoxTables_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxTables.SelectedItem != null)
            {
                TableFile tableFile = (TableFile)listBoxTables.SelectedItem;
                createNewQueryTab(tableFile);
            }
        }

        /// <summary>
        /// Clic in New Query
        /// </summary>
        private void toolStripButtonNewQuery_Click(object sender, EventArgs e)
        {
            createNewEmptyQueryTab();
        }

        /// <summary>
        /// Create a new query tab with default query
        /// </summary>
        private void createNewQueryTab(TableFile tableFile)
        {
            QueryTab queryTab = new QueryTab();
            string defaultQuery = "select * from $" + tableFile.TableName;
            queryTab.init(this, tableFile.TableName, defaultQuery);
            queryTab.Dock = DockStyle.Fill;

            //Add to tabControl
            TabPage tab = new TabPage(tableFile.TableName);
            tab.Tag = queryTab;
            tab.Controls.Add(queryTab);
            addTab(tab);
        }

        /// <summary>
        /// Create a new empty query tab
        /// </summary>
        private void createNewEmptyQueryTab()
        {
            QueryTab queryTab = new QueryTab();
            queryTab.init(this, "new", "");
            queryTab.Dock = DockStyle.Fill;

            //Add to tabControl
            TabPage tab = new TabPage("new");
            tab.Tag = queryTab;
            tab.Controls.Add(queryTab);
            addTab(tab);
        }

        /// <summary>
        /// Add a new tab to the tab panel
        /// </summary>
        private void addTab(TabPage tab)
        {
            this.tabControlQueries.TabPages.Add(tab);
            this.tabControlQueries.SelectedTab = tab;
        }

        /// <summary>
        /// Remove existing tab
        /// </summary>
        public void removeQueryTab(QueryTab queryTab)
        {
            TabPage tabToRemove = null;
            foreach (TabPage tab in this.tabControlQueries.TabPages)
            {
                if (tab.Tag.Equals(queryTab))
                {
                    tabToRemove = tab;
                }
            }

            if (tabToRemove != null)
            {
                this.tabControlQueries.TabPages.Remove(tabToRemove);
            }
        }

        
    }
}
