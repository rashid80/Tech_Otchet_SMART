using System;
using System.Collections.Generic;
using Word = Microsoft.Office.Interop.Word;

namespace Tech_Otchet_SMART
{
    class WordWriter
    {
        private Word.Application wordApp;
        private Word.Document wordDocument;
        private Word.Find fnd;

        public WordWriter(string filename)
        {
            wordApp = new Word.Application();
            wordApp.Visible = false;

            //wordApp.Documents.Open(filename);
            wordApp.Documents.Add(filename, false, Word.WdNewDocumentType.wdNewBlankDocument, true); //Так открывается копия документа на основе нашего doc-шаблона и при случайном сохранении не перезапишет шаблон


            wordDocument = wordApp.ActiveDocument;

            //fnd = wordApp.ActiveDocument.Range().Find;
            fnd = wordDocument.Range().Find;

            fnd.ClearFormatting();
            fnd.Forward = true;
        }

        public void ReplaceKeyWords(string keyWord, decimal data)
        {
            ReplaceKeyWords(keyWord, data.ToString());
        }

        public void ReplaceKeyWords(string keyWord, string data)
        {
            fnd.Execute(keyWord, null, null, null, null, null, null, null, null, data, 2);
        }

        public int AddRowInTable(int tableNum, List<string> data)
        {
            var tableWord = wordDocument.Tables[tableNum];
            //tableWord.Rows.Add(tableWord.Rows[1]);
            tableWord.Rows.Add();

            int maxRow = tableWord.Rows.Count;
            int maxCol = tableWord.Columns.Count;

            int lim = Math.Min(maxCol, data.Count);

            for (int col = 1; col <= lim; col++)
            {
                tableWord.Cell(maxRow, col).Range.Text = data[col - 1];
            }

            return tableWord.Rows.Count;
        }


        public void MergeRows(int tableNum, int rowBegin, int countMerge, List<int> colMerge)
        {
            var tableWord = wordDocument.Tables[tableNum];

            int maxRow = tableWord.Rows.Count;

            for (int row = rowBegin; row <= maxRow; row += countMerge)
            {
                foreach (var col in colMerge)
                {
                    //tableWord.Cell(2, 1).Merge(tableWord.Cell(4, 1));
                    //tableWord.Cell(row, col).Merge(tableWord.Cell(row + countMerge - 1, col)); //объединяем строки в колонке
                    MergeTableAria(tableWord, row, col, row + countMerge - 1, col); //объединяем строки в колонке
                }
            }


        }


        public void MergeTableAria(int tableNum, int rowBegin, int colBegin, int rowEnd, int colEnd)
        {
            var tableWord = wordDocument.Tables[tableNum];
            MergeTableAria(tableWord, rowBegin, colBegin, rowEnd, colEnd);
        }

        public void MergeTableAria(Word.Table tableWord, int rowBegin, int colBegin, int rowEnd, int colEnd)
        {
            if (rowBegin == rowEnd && colBegin == colEnd) //Если указана одна ячейка, то выпадет исключение
            {
                return;
            }

            tableWord.Cell(rowBegin, colBegin).Merge(tableWord.Cell(rowEnd, colEnd));
        }



        public List<string> GetTextFromRow(int tableNum, int rowNum)
        {

            var res = new List<string>();

            var tableWord = wordDocument.Tables[tableNum];
            int lim = tableWord.Columns.Count;

            for (int col = 1; col <= lim; col++)
            {
                var str = tableWord.Cell(rowNum, col).Range.Text;
                str = str.TrimEnd('\r', '\a'); //Почему-то из ячейки Word текст возвращается с символом переноса \r\a - вычищаем
                res.Add(str);
            }



            return res;
        }

        public void DeleteRowInTable(int tableNum, int rowNum, int rowNumEnd)
        {
            var tableWord = wordDocument.Tables[tableNum];
            //tableWord.Rows[rowNum].Delete();

            int maxCol = tableWord.Columns.Count;
            wordDocument.Range(tableWord.Cell(rowNum, 1).Range.Start, tableWord.Cell(rowNumEnd, maxCol).Range.End).Cells.Delete();
        }

        public void Show()
        {
            wordApp.Visible = true;
        }

    }
}
