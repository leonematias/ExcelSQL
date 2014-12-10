ExcelSQL
========

A simple tool to execute a SQL select over a bunch of Excel spreadsheets or CSV files.

Imagine you have some spreadsheets and you want to perform a SELECT COUNT or a DISTINCT. You may deal with Excel functions but sometimes it would be better to just use SQL. If you find yourself in that situation this tool is exactly for you.

##Features:
- Implemented in C# for Windows.
- You can load CSV and XLS files (sorry no XLSX for now).
- You can perform any SQL query on them.
- You can also perform joins between these files
- You can generate a new file as the output of a query (like a materalized view) and then use that for another query
