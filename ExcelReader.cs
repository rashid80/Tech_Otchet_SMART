using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

using Excel = Microsoft.Office.Interop.Excel;

namespace Tech_Otchet_SMART
{
    static class ExcelReader
    {
        [DllImport("user32.dll")]
        private static extern int GetWindowThreadProcessId(int hWnd, out int lpdwProcessId);

        private static Process GetExcelProcess(Excel.Application excelApp)
        {
            GetWindowThreadProcessId(excelApp.Hwnd, out int id);
            return Process.GetProcessById(id);
        }


        private static string getStringFromExcelCell(Excel.Worksheet sheet, int numRow, int numCol)
        {
            var range2 = (Excel.Range)sheet.Cells[numRow, numCol];
            return range2.Text.ToString();
        }

        public static Tuple<Mass1, Mass2> getMass1fromFile(string fileName)
        {

            Excel.Application excelApp = new Excel.Application(); //создаём приложение Excel
            excelApp.Visible = false;

            Process appProcess = GetExcelProcess(excelApp);

            var workBook = excelApp.Workbooks.Open(fileName);
            var sheet = (Excel.Worksheet)workBook.Sheets[1];

            var lastCell = sheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell);//1 ячейку
            int lastRow = (int)lastCell.Row;

            var mass = new Mass1();

            List<string> tempList = new List<string>();

            string errText = "";
            try
            {

                for (int currRow = 2; currRow <= lastRow; currRow++)
                {
                    string strData = getStringFromExcelCell(sheet, currRow, 1);
                    if (!String.IsNullOrEmpty(strData))
                    {
                        mass.var1.Add(strData);
                    }

                    strData = getStringFromExcelCell(sheet, currRow, 2);
                    if (!String.IsNullOrEmpty(strData))
                    {
                        mass.var2.Add(strData);
                    }

                    if (currRow < 7)
                    {
                        tempList.Add(getStringFromExcelCell(sheet, currRow, 3));
                    }
                }

                mass.name = tempList[0];
                mass.temperature = decimal.Parse(tempList[1]);
                mass.humidity = decimal.Parse(tempList[2]);
                mass.pressure = decimal.Parse(tempList[3]);
                mass.period = tempList[4];

                workBook.Close(true);
                excelApp.Quit();
            }

            catch (Exception e)
            {
                errText = e.ToString();
            }

            sheet = null;
            workBook = null;
            excelApp = null;

            try
            {
                appProcess.Kill(); //Иначе Excel не закроется
            }
            catch
            {

            }

            if (!String.IsNullOrEmpty(errText))
            {
                throw new Exception(errText);
            }

            return mass;

        }

        public static Mass2 getMass2fromFile(string fileName)
        {

            Excel.Application excelApp = new Excel.Application(); //создаём приложение Excel
            excelApp.Visible = false;

            Process appProcess = GetExcelProcess(excelApp);

            var workBook = excelApp.Workbooks.Open(fileName);
            var sheet = (Excel.Worksheet)workBook.Sheets[1];

            var lastCell = sheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell);//1 ячейку
            int lastRow = (int)lastCell.Row;

            var mass = new Mass2();

            List<string> tempList = new List<string>();

            string errText = "";
            string numTP = "";
            string prev_numTP = "####%$#%###############";
            string prev_consumerLine = "####%$#%###############";
            string consumerLine = "";
            var tpLine = new Mass2infoLine0();
            var cLine = new Mass2infoLine1();
            try
            {

                for (int currRow = 3; currRow <= lastRow; currRow++)
                {
                    if (currRow < 8)
                    {
                        tempList.Add(getStringFromExcelCell(sheet, currRow, 7));
                    }

                    var strData = getStringFromExcelCell(sheet, currRow, 2);  //Вторая колонка всегда д.б. заполнена
                    if (String.IsNullOrEmpty(strData))
                    {
                        continue;
                    }

                    var infoLine = new Mass2infoLine2();
                    infoLine.numTT = strData;

                    infoLine.primaryAmperage = decimal.Parse(getStringFromExcelCell(sheet, currRow, 3));
                    infoLine.transformCoef = decimal.Parse(getStringFromExcelCell(sheet, currRow, 4));
                    infoLine.transformType = getStringFromExcelCell(sheet, currRow, 5);

                    strData = getStringFromExcelCell(sheet, currRow, 1);
                    if (!String.IsNullOrEmpty(strData))
                    {
                        numTP = strData;
                    }

                    if (numTP != prev_numTP)
                    {
                        mass.tps.Add(new Mass2infoLine0());
                        tpLine = mass.tps[mass.tps.Count - 1];

                        tpLine.numTP = numTP;
                        tpLine.cls = new List<Mass2infoLine1>();

                        prev_numTP = numTP;
                        prev_consumerLine = "####%$#%###############";
                    }

                    strData = getStringFromExcelCell(sheet, currRow, 6);
                    if (!String.IsNullOrEmpty(strData))
                    {
                        consumerLine = strData;
                    }

                    if (consumerLine != prev_consumerLine)
                    {
                        tpLine.cls.Add(new Mass2infoLine1());
                        cLine = tpLine.cls[tpLine.cls.Count - 1];
                        cLine.consumerLine = consumerLine;

                        prev_consumerLine = consumerLine;
                    }

                    cLine.infoLines.Add(infoLine);
                }



                mass.name = tempList[0];
                mass.temperature = decimal.Parse(tempList[1]);
                mass.humidity = decimal.Parse(tempList[2]);
                mass.pressure = decimal.Parse(tempList[3]);
                mass.period = tempList[4];

                workBook.Close(true);
                excelApp.Quit();
            }

            catch (Exception e)
            {
                errText = e.ToString();
            }

            sheet = null;
            workBook = null;
            excelApp = null;

            try
            {
                appProcess.Kill(); //Иначе Excel не закроется
            }
            catch
            {

            }

            if (!String.IsNullOrEmpty(errText))
            {
                throw new Exception(errText);
            }

            return mass;

        }

    }



}


