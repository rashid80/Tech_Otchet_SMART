using System;
using System.Collections.Generic;

namespace Tech_Otchet_SMART
{
    internal class Report1 : IReport
    {
        private Mass1 mass;

        public Report1(string t_path, string t_name, Mass1 vmass) : base(t_path, t_name)
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

            var data = ww.GetTextFromRow(numTable, beginDataRow); //Берем данные из первой значимой строки (оставили в шаблоне)

            int num = 1;

            Random rnd = new Random();

            foreach (var str in mass.var1)
            {
                data[0] = num.ToString() + ".";
                num += 1;

                data[1] = str;

                int rand;

                rand = rnd.Next(210, 280);
                data[5] = ((decimal)rand / 10).ToString();

                //Правка от 05.11.2020
                //rand = rnd.Next(350, 550);
                rand = rnd.Next(472, 550); 

                data[7] = rand.ToString();

                ww.AddRowInTable(numTable, data);
            }

            ww.DeleteRowInTable(numTable, beginDataRow, beginDataRow);



            numTable = 4;
            beginDataRow = 2;

            int addRow = 3;

            List<int> colMerge = new List<int> { 1, 2, 3, 4, 7 };

            var dataBeg = ww.GetTextFromRow(numTable, beginDataRow); //Берем данные из первой значимой строки (оставили в шаблоне)

            foreach (var str in mass.var2)
            {
                data = new List<string>(dataBeg);
                data[0] = num.ToString() + ".";
                num += 1;

                for (int irow = 1; irow <= addRow; irow++)
                {
                    data[1] = str;

                    int rand;

                    rand = rnd.Next(135, 149);
                    data[5] = ((decimal)rand / 10).ToString();
                    
                    //Правка от 05.11.2020
                    //rand = rnd.Next(170, 300);
                    rand = rnd.Next(224, 300); 

                    data[7] = rand.ToString();

                    if (irow == 1)
                    {
                        ww.AddRowInTable(numTable, data);
                        continue;
                    }

                    for (int col = 1; col <= data.Count; col++)
                    {
                        if (colMerge.Contains(col))
                        {
                            data[col - 1] = "";
                        }
                    }

                    ww.AddRowInTable(numTable, data);

                }
            }

            ww.DeleteRowInTable(numTable, beginDataRow, beginDataRow + addRow - 1);


            ww.MergeRows(numTable, beginDataRow, addRow, colMerge);





        }

    }
}
