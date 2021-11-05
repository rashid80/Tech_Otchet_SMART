using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Tech_Otchet_SMART
{
    public partial class Form1 : Form
    {
        private string fileNameMas1Value;
        private string fileNameMas2Value;
        private string FileNameMas1Value
        {
            set { fileNameMas1.Text = value; fileNameMas1Value = value; Properties.Settings.Default.fileNameMas1 = value; Properties.Settings.Default.Save(); }
            get { return fileNameMas1Value; }
        }
        private string FileNameMas2Value
        {
            set { fileNameMas2.Text = value; fileNameMas2Value = value; Properties.Settings.Default.fileNameMas2 = value; Properties.Settings.Default.Save(); }
            get { return fileNameMas2Value; }
        }


        public Form1()
        {
            InitializeComponent();

            this.Text = Service.getVersion();

            FileNameMas1Value = Properties.Settings.Default.fileNameMas1;
            FileNameMas2Value = Properties.Settings.Default.fileNameMas2;

        }

        private void buttonGetData_Click(object sender, EventArgs e)
        {
            MakeWordFiles();
        }

        private void MakeWordFiles()
        {

            tbProcess.Text = "";

            tbProcess.AppendText("НАЧАЛО:   " + DateTime.Now.ToString() + Environment.NewLine);

            var repList = new List<IReport>();
            string t_path = Application.StartupPath;

            if (!String.IsNullOrEmpty(fileNameMas1Value))
            {
                tbProcess.AppendText("Чтение Excel-файла (Массив №1) ..." + Environment.NewLine);
                var mass1 = ExcelReader.getMass1fromFile(@fileNameMas1Value);

                repList.Add(new Report1(t_path, @"Dop1_Template.doc", mass1));
                repList.Add(new Report2(t_path, @"Dop2_Template.doc", mass1));
            }

            if (!String.IsNullOrEmpty(fileNameMas2Value))
            {
                tbProcess.AppendText("Чтение Excel-файла (Массив №2) ..." + Environment.NewLine);
                var mass2 = ExcelReader.getMass2fromFile(@fileNameMas2Value);

                repList.Add(new Report3(t_path, @"Dop3_Template.doc", mass2));
                repList.Add(new Report4(t_path, @"Dop4_Template.doc", mass2));
            }

            int numRep = 1;

            foreach (var rep in repList)
            {
                tbProcess.AppendText("Генерация отчета №" + numRep.ToString() + " ..." + Environment.NewLine);
                numRep += 1;

                var et = rep.Generate();
                tbProcess.AppendText((String.IsNullOrEmpty(et)) ? "OK" : et);
                tbProcess.AppendText(Environment.NewLine + Environment.NewLine);
                rep.Show();
            }

            tbProcess.AppendText("ОКОНЧАНИЕ:   " + DateTime.Now.ToString() + Environment.NewLine);
        }




        private void buttonSelectfileNameMas1_Click(object sender, EventArgs e)
        {
            FileNameMas1Value = Service.SelectFile(fileNameMas1.Text);
        }

        private void buttonSelectfileNameMas2_Click(object sender, EventArgs e)
        {
            FileNameMas2Value = Service.SelectFile(fileNameMas2.Text);
        }

        private void buttonDeletefileNameMas1_Click(object sender, EventArgs e)
        {
            FileNameMas1Value = "";
        }

        private void buttonDeletefileNameMas2_Click(object sender, EventArgs e)
        {
            FileNameMas2Value = "";
        }
    }
}
