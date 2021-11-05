using System;
using System.Collections.Generic;

namespace Tech_Otchet_SMART
{
    internal class Report2 : IReport
    {
        private Mass1 mass;

        public Report2(string t_path, string t_name, Mass1 vmass) : base(t_path, t_name)
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

            //Правка от 05.11.2020
            //Random rnd = new Random();

            string value500 = 500.ToString(); //Правка от 05.11.2020

            foreach (var str in mass.var1)
            {
                var numMergeRow = ww.AddRowInTable(numTable, new List<string> { str });

                data[0] = num.ToString() + ".";
                num += 1;

                //Правка от 05.11.2020
                //int rand;

                //Правка от 05.11.2020
                //rand = rnd.Next(500, 700);
                //data[3] = rand.ToString();
                data[3] = value500; 
                
                //Правка от 05.11.2020
                //rand = rnd.Next(500, 700);
                //data[9] = rand.ToString();
                data[9] = value500; 

                ww.AddRowInTable(numTable, data);

                ww.MergeTableAria(numTable, numMergeRow, 1, numMergeRow, data.Count);

            }

            ww.DeleteRowInTable(numTable, beginDataRow - 1, beginDataRow);



            numTable = 4;
            beginDataRow = 3;

            data = ww.GetTextFromRow(numTable, beginDataRow); //Берем данные из первой значимой строки (оставили в шаблоне)

            foreach (var str in mass.var2)
            {
                var numMergeRow = ww.AddRowInTable(numTable, new List<string> { str });

                data[0] = num.ToString() + ".";
                num += 1;

                //Правка от 05.11.2020
                //int rand;

                for (int i = 3; i <= 11; i++)
                {
                    //rand = rnd.Next(500, 700);
                    //data[i] = rand.ToString();
                    data[i] = value500; //Правка от 05.11.2020
                }

                ww.AddRowInTable(numTable, data);

                ww.MergeTableAria(numTable, numMergeRow, 1, numMergeRow, data.Count);

            }

            ww.DeleteRowInTable(numTable, beginDataRow - 1, beginDataRow);

        }

    }
}
