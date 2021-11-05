using System;
using System.Collections.Generic;

namespace Tech_Otchet_SMART
{
    internal class Report4 : IReport
    {
        private Mass2 mass;

        public Report4(string t_path, string t_name, Mass2 vmass) : base(t_path, t_name)
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
            int beginDataRow = 5;

            var predata = ww.GetTextFromRow(numTable, beginDataRow - 1);
            var data = ww.GetTextFromRow(numTable, beginDataRow); //Берем данные из первой значимой строки (оставили в шаблоне)

            int num = 1;

            var ABC = new Queue<string>(new List<string>() { "A", "B", "C" });
            var resist = new Queue<string>(new List<string>() { "0,03", "0,02", "0,03" });


            foreach (var tpLine in mass.tps)
            {
                var numMergeRow = ww.AddRowInTable(numTable, new List<string> { tpLine.numTP });

                predata[0] = num.ToString() + ".";
                num += 1;
                ww.AddRowInTable(numTable, predata);

                foreach (var cLine in tpLine.cls)
                {

                    foreach (var infoLine in cLine.infoLines)
                    {

                        data[0] = num.ToString() + ".";
                        num += 1;

                        var letter = ABC.Dequeue();
                        ABC.Enqueue(letter);
                        data[1] = "РЕ шина – вывод вторичной обмотки ТТ, " + cLine.consumerLine + " ф." + letter; //РЕ шина – вывод вторичной обмотки ТТ, Линия№4 ф.А

                        var res = resist.Dequeue();
                        resist.Enqueue(res);
                        data[3] = res;

                        ww.AddRowInTable(numTable, data);
                    }

                }

                ww.MergeTableAria(numTable, numMergeRow, 1, numMergeRow, data.Count);
            }

            ww.DeleteRowInTable(numTable, beginDataRow - 2, beginDataRow);




        }
    }
}
