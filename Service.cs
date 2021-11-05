using System.Windows.Forms;

namespace Tech_Otchet_SMART
{
    static class Service
    {
        public static string getVersion()
        {
            return "Tech_Otchet SMART v.1.02";
        }

        public static string SelectFile(string fileName)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.FileName = fileName;
            openFileDialog.Filter = "Excel-файлы (*.xls*)|*.xls*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            return (openFileDialog.ShowDialog() == DialogResult.OK) ? openFileDialog.FileName : fileName;
        }

    }
}
