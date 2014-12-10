using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;
using System.IO;

namespace ExcelSql
{
    /// <summary>
    /// Query and results
    /// </summary>
    public partial class QueryTab : UserControl
    {
        MainForm mainForm;
        SaveFileDialog saveFileDialog;
        string name;
  

        public QueryTab()
        {
            InitializeComponent();
        }

        public void init(MainForm mainForm, string name, string initialQuery)
        {
            this.mainForm = mainForm;
            this.name = name;

            saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save results to a CSV file";
            saveFileDialog.Filter = "CSV Files (.csv)|*.csv|Text Files (.txt)|*.txt";

            this.richTextBoxQuery.Text = initialQuery;
            this.executeCurrentQuery();
        }

        /// <summary>
        /// Execute query
        /// </summary>
        private void executeCurrentQuery()
        {
            string queryText = this.richTextBoxQuery.Text.Trim();
            if (queryText.Length < 1)
                return;


            //mainForm.clearLog();
            mainForm.log("-----------------------------------------------------------------------------------------------------------------------");
            mainForm.log("Executing query: \n\t" + queryText);


            OdbcConnection connection = null;
            try
            {
                //Adapt table names
                queryText = adaptQueryToExecute(queryText, this.mainForm.TableFiles);

                //Open ODBC connection to temp folder
                string connectionStr = @"Driver={Microsoft Text Driver (*.txt; *.csv)};Dbq=" + mainForm.TempTablesPath + ";Extensions=csv,txt";
                connection = new OdbcConnection(connectionStr);
                connection.Open();

                //Execute query
                OdbcDataAdapter odbcAdapter = new OdbcDataAdapter(queryText, connection);

                //Fill dataGrid
                DataTable dataTable = new DataTable();
                odbcAdapter.Fill(dataTable);
                dataGridViewResults.DataSource = dataTable;
                dataGridViewResults.Refresh();
                mainForm.log(dataGridViewResults.Rows.Count + " rows loaded");

                //Close connection
                connection.Close();
            }
            catch (Exception e)
            {
                string error = "Error executing query:\n" + e.Message;
                if (e.InnerException != null)
                {
                    error += Environment.NewLine + e.InnerException.Message;
                }
                mainForm.logError(error);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }
        
        /// <summary>
        /// Adapt table names and syntax to ODBC
        /// </summary>
        private string adaptQueryToExecute(string query, List<TableFile> tableFiles)
        {
            string adaptedQuery = query;

            //Load existing table names in map
            Dictionary<string, TableFile> tableNames = new Dictionary<string, TableFile>();
            foreach (TableFile tableFile in tableFiles)
            {
                tableNames[tableFile.TableName] = tableFile;
            }

            //Replace table names starting with $tableName to [tableName]
            string[] tokens = query.Split();
            foreach (string token in tokens)
            {
                if (token.StartsWith("$"))
                {
                    //Get table name
                    string tableName = token.Substring(1);
                    //Remove possible last character thar is not part of the name
                    tableName = tableName.Replace(",", "").Replace(")", "");

                    //Check if the table exists
                    if (!tableNames.ContainsKey(tableName))
                    {
                        throw new Exception("Invalid table name: " + tableName);
                    }

                    //Replace $tableName for [tableName.csv]
                    adaptedQuery = adaptedQuery.Replace(token, "[" + tableName + ".csv]");
                }
            }

            return adaptedQuery;
        }

        /// <summary>
        /// Clic on Run
        /// </summary>
        private void toolStripButtonRun_Click(object sender, EventArgs e)
        {
            executeCurrentQuery();
        }

        /// <summary>
        /// Clic on Save results
        /// </summary>
        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                saveResultsToFile(saveFileDialog.FileName);
                MessageBox.Show(this, "File saved successfully", "Result");
            }
        }



        /// <summary>
        /// Save results of the dataGrid to a CSV file
        /// </summary>
        private void saveResultsToFile(string destPath)
        {
            using (var writer = new StreamWriter(destPath))
            {
                //columns
                for (int i = 0; i < this.dataGridViewResults.Columns.Count; i++)
                {
                    string colName = this.dataGridViewResults.Columns[i].Name;
                    if (i != this.dataGridViewResults.Columns.Count - 1)
                    {
                        writer.Write(colName + ",");
                    }
                    else
                    {
                        writer.WriteLine(colName);
                    }
                }
                writer.Flush();

                //rows
                for (int i = 0; i < this.dataGridViewResults.Rows.Count; i++)
                {
                    DataGridViewRow row = this.dataGridViewResults.Rows[i];
                    for (int j = 0; j < row.Cells.Count; j++)
                    {
                        object value = row.Cells[j].Value;
                        string cellValue = value != null ? value.ToString() : "";
                        if (j != row.Cells.Count - 1)
                        {
                            writer.Write(cellValue + ",");
                        }
                        else
                        {
                            writer.WriteLine(cellValue);
                        }
                    }
                    writer.Flush();
                }
            }
        }

        /// <summary>
        /// Clic on Create table
        /// </summary>
        private void toolStripButtonCreateTable_Click(object sender, EventArgs e)
        {
            string dstPath = this.mainForm.createNewPathToCopy(this.name, this.mainForm.TempTablesPath);
            this.saveResultsToFile(dstPath);
            this.mainForm.loadFileFromTempFolder(dstPath, TableFile.TableType.FromQuery, "");
        }

        /// <summary>
        /// Clic on close
        /// </summary>
        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.mainForm.removeQueryTab(this);
        }

        /// <summary>
        /// KeyDown in richText
        /// </summary>
        private void richTextBoxQuery_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                this.executeCurrentQuery();
            }
        }



        
    }
}

