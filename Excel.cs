using Microsoft.Office.Interop.Excel;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;



namespace FinalProjectSeluniom
{
    class Excel
    {

        Application excel = new Application();
        Workbook wb;
        Worksheet wh;

        public void OpenExcel(string path, int sheet)
        {
            wb = excel.Workbooks.Open(path);
            wh = wb.Worksheets[sheet];
        }
        public string ReadExcel(int c, int r)
        {
            return wh.Cells[c][r].value.ToString();
        }

        public string WriteExcel(int c, int r)
        {
            return wh.Cells[c][r].value;
        }

        public void CloseExcel()
        {
            excel.Workbooks.Close();
        }

        public void TestMethod()
        {
            String outputPath = "C:\\Test.xlsx";

            Application excel = new Application();
           Workbook workbook = excel.Workbooks.Add(Type.Missing);
          Worksheet sheet = (Worksheet)workbook.ActiveSheet;

            ((Excel.Range)sheet.Cells[1, 1]).Value = "Hello";

            workbook.SaveCopyAs(outputPath);
            workbook.Close();
            excel.Quit();
        }

        private class Range
        {
            internal string Value;
        }
    }
}
