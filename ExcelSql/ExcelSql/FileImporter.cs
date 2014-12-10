using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.OleDb;
using System.Data;

namespace ExcelSql
{
    /// <summary>
    /// Load external file into temp CSV folder
    /// </summary>
    public class FileImporter
    {
        MainForm mainForm;

        public FileImporter(MainForm mainForm)
        {
            this.mainForm = mainForm;
        }
        
        /// <summary>
        /// Import external file into local folder as a csv file
        /// </summary>
        public bool importFile(string srcFilePath, string dstFilePath)
        {
            FileInfo fi = new FileInfo(srcFilePath);
            string ext = fi.Extension.ToLower();

            //CSV file
            if (ext == ".csv")
            {
                //Just copy the file
                File.Copy(srcFilePath, dstFilePath);

            }
            //Excel file
            else if (ext == ".xls")
            {
                //Read file and convert to CSV
                OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + srcFilePath + ";Extended Properties=Excel 8.0");
                conn.Open();

                //Obtain first sheet
                string firstSheet = null;
                DataTable schemaDt = conn.GetSchema("Tables");
                for (int i = 0; i < schemaDt.Rows.Count - 1; i++)
                {
                    string tableType = schemaDt.Rows[i].ItemArray[schemaDt.Columns.IndexOf("TABLE_TYPE")].ToString();
                    string sheetName = schemaDt.Rows[i].ItemArray[schemaDt.Columns.IndexOf("TABLE_NAME")].ToString();
                    if (tableType == "TABLE" && sheetName.Contains("$"))
                    {
                        firstSheet = sheetName;
                        break;
                    }
                }
                if (firstSheet == null)
                {
                    mainForm.showError("Import file error", "Could not find first sheet in excel file: " + srcFilePath);
                    return false;
                }

                //Query sheet
                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM [" + firstSheet + "]", conn);
                OleDbCommandBuilder commandBuilder = new OleDbCommandBuilder(adapter);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                //Create CSV file
                using (var writer = new StreamWriter(dstFilePath))
                {
                    //columns
                    for (int i = 0; i < dataTable.Columns.Count; i++)
                    {
                        string colName = dataTable.Columns[i].ColumnName;
                        if (i != dataTable.Columns.Count - 1)
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
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        object[] cells = dataTable.Rows[i].ItemArray;
                        for (int j = 0; j < cells.Length; j++)
                        {
                            object value = cells[j];
                            string cellValue = value != null ? value.ToString() : "";
                            if (j != cells.Length - 1)
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
            //File not supported
            else
            {
                mainForm.showError("Import file error", "File extension not supported for file: " + srcFilePath);
                return false;
            }



            return true;
        }

    }
}
