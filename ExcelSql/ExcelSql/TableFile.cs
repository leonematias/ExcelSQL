using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ExcelSql
{
    /// <summary>
    /// Table stored in a file
    /// </summary>
    public class TableFile
    {
        MainForm mainForm;
        TableType tableType;
        string origFilePath;

        string filePath;
        /// <summary>
        /// File path
        /// </summary>
        public string FilePath
        {
            get { return filePath; }
        }

        string tableName;
        /// <summary>
        /// Table name
        /// </summary>
        public string TableName
        {
            get { return tableName; }
        }

        /// <summary>
        /// Types of tables
        /// </summary>
        public enum TableType
        {
            FromFile,
            FromQuery
        }

        

        public void init(MainForm mainForm, TableType tableType, string filePath, string origFilePath)
        {
            this.mainForm = mainForm;
            this.filePath = filePath;
            this.tableType = tableType;
            this.origFilePath = origFilePath;

            this.tableName = Path.GetFileNameWithoutExtension(filePath);
            //this.tableName = new FileInfo(filePath).Name;
        }

        

        public override string ToString()
        {
            return tableName + (tableType == TableType.FromFile ? " [file]" : " [query]") ;
        }


    }
}
