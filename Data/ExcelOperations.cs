﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using ExcelDataReader;
using System.Diagnostics;

namespace TestKuboFit
{
    public static class ExcelOperations
    {
        private static DataTable ExcelToDataTable(string filename)
        {
            FileStream stream = File.Open(filename, FileMode.Open, FileAccess.Read);
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

            DataSet resultSet = excelReader.AsDataSet(new ExcelDataSetConfiguration()
            {
                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                {
                    UseHeaderRow = true
                }
                
        }
        
            );
            DataTableCollection table = resultSet.Tables;
            DataTable resultTable = table["MyTable"];
            excelReader.Close();
            return resultTable;
            

        }
        
        public static void QuitExcel(string processtitle)
        {
            var processes = from p in Process.GetProcessesByName("EXCEL")
                            select p;

            foreach (var process in processes)
                if (process.MainWindowTitle == "Microsoft Excel - " + processtitle + " - Excel")
                    process.Kill();
        }


        public static void ClearData()
        {
            dataCol.Clear();
        }


        public class Datacollection
        {
            public int rowNumber { get; set; }
            public string colName { get; set; }
            public string colValue { get; set; }
        }

        internal static string ReadData(object rowNumber, string v)
        {
            throw new NotImplementedException();
        }

        static List<Datacollection> dataCol = new List<Datacollection>();

        public static void PopulateInCollection(string filename)
        {
            DataTable table = ExcelToDataTable(filename);
            //totalRowCount = table.Rows.Count;
            for (int row = 1; row <= table.Rows.Count; row++)
            {
                for (int col = 0; col < table.Columns.Count; col++)
                {
                    Datacollection dtTable = new Datacollection()
                    {
                        rowNumber = row,
                        colName = table.Columns[col].ColumnName,
                        colValue = table.Rows[row - 1][col].ToString()
                    };
                    dataCol.Add(dtTable);
                }
            }

        }
        public static string ReadData(int rowNumber, string columnName)
        {
            try
            {
                string data = (from colData in dataCol where colData.colName == columnName && colData.rowNumber == rowNumber select colData.colValue).SingleOrDefault();
                return data.ToString();
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}