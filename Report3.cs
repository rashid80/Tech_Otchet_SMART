using System;
using System.Collections.Generic;

namespace Tech_Otchet_SMART
{
    internal class Report3 : IReport
    {
        private Mass2 mass;

        public Report3(string t_path, string t_name, Mass2 vmass) : base(t_path, t_name)
        {
            mass = vmass;
        }

        internal override void GenerateTheReport()
        {
            ww.ReplaceKeyWords("~name~", mass.name);
            ww.ReplaceKeyWords("~temp~", mass.temperature);
            ww.ReplaceKeyWords("~hum~", mass.humidity);
            ww.ReplaceKeyWords("~press~", mass.pressure);
            ww.ReplaceKeyWords("~period~", mass.period);

            int numTable = 3;
            int beginDataRow = 4;

            var data = ww.GetTextFromRow(numTable, beginDataRow); //Берем данные из первой значимой строки (оставили в шаблоне)

            //int num = 1;

            var ABC = new Queue<string>(new List<string>() { "A", "B", "C" });


            foreach (var tpLine in mass.tps)
            {
                var numMergeRow = ww.AddRowInTable(numTable, new List<string> { tpLine.numTP });

                foreach (var cLine in tpLine.cls)
                {

                    foreach (var infoLine in cLine.infoLines)
                    {
                        data[1] = infoLine.transformType;
                        data[2] = infoLine.numTT;
                        data[3] = infoLine.transformCoef.ToString();
                        data[7] = cLine.consumerLine;

                        var letter = ABC.Dequeue();
                        ABC.Enqueue(letter);
                        data[0] = letter;

                        ww.AddRowInTable(numTable, data);
                    }

                }

                ww.MergeTableAria(numTable, numMergeRow, 1, numMergeRow, data.Count);
            }

            ww.DeleteRowInTable(numTable, beginDataRow - 1, beginDataRow);




            numTable = 4;
            beginDataRow = 5;

            List<int> colMerge = new List<int> { 3 };


            data = ww.GetTextFromRow(numTable, beginDataRow); //Берем данные из первой значимой строки (оставили в шаблоне)

            int num = 1;


            foreach (var tpLine in mass.tps)
            {
                var numMergeRow = ww.AddRowInTable(numTable, new List<string> { tpLine.numTP });

                foreach (var cLine in tpLine.cls)
                {

                    data[0] = num.ToString() + ".";
                    num += 1;

                    var infoLine = cLine.infoLines[0];

                    data[9] = infoLine.primaryAmperage.ToString();
                    data[11] = infoLine.transformCoef.ToString();

                    ww.AddRowInTable(numTable, data);
                }

                ww.MergeTableAria(numTable, numMergeRow, 1, numMergeRow, data.Count);

                int addRow = tpLine.cls.Count;
                ww.MergeRows(numTable, numMergeRow + 1, addRow, colMerge);

            }

            ww.DeleteRowInTable(numTable, beginDataRow - 1, beginDataRow);
        }
    }
}
