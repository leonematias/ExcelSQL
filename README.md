ExcelSQL
========

A simple tool to execute a SQL select over a bunch of Excel spreadsheets or CSV files.

Imagine you have some spreadsheets and you want to perform a SELECT COUNT or a DISTINCT. You may deal with Excel functions but sometimes it would be better to just use SQL. If you find yourself in that situation this tool is exactly for you.
See detailed explanation in: http://leonedev.blogspot.com/2014/12/sql-query-on-spreadsheet.html

##Features:
- Windows desktop app implemented in C# with .NET framework 4.0.
- You can load CSV and XLS files (sorry no XLSX for now).
- You can perform any SQL query on them. Supported features are defined by ODBC Text driver: http://msdn.microsoft.com/en-us/library/ms714091(v=vs.85).aspx
- You can also perform joins between these files
- You can generate a new file as the output of a query (like a materalized view) and then use that for another query

##Usage:
- Execute ExcelSQL.exe
- Click in "Load file" and select the file you want to load. The file must be a CSV or XLS file. If you have XLSX save it as a XLS. The first row should be the header with the name of each column.
- By default the app creates a new Query tab with a SELECT *. You can open many Query tabs an operate on different files in the same tab.
- Files are considered tables. You must specify them starting with $. Example: SELECT * FROM $products
- You can specify alias on a table. Example: SELECT * FROM $products as p WHERE p.id > 20
- You can join two different files specifying the required condition in WHERE. Example: SELECT p.id FROM $products as p, $references r WHERE p.type = r.type. You cannot use JOIN in FROM because you don't have primrary and foreign keys. It's just a bunch of files. Join conditions must be specified in WHERE.
- You click in "Save results" to store the result of a Query tab into a CSV file.
- If you click on "Create table" a new file will be created with the content of the current Query tab. You can then use that table as a pre-computed result for another query
- If you double click on a table from the right panel then a new Query tab is opened with a SELECT * query.



