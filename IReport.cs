using System;

namespace Tech_Otchet_SMART
{
    abstract class IReport
    {
        protected WordWriter ww;

        public IReport(string template_path, string template_name)
        {
            string filename = GetFileName(template_path, template_name);
            ww = new WordWriter(filename);
        }

        private string GetFileName(string template_path, string template_name)
        {

            string filename = template_path + @"\" + template_name;

            if (System.IO.File.Exists(filename))
            {
                return filename;
            }
              
            string template_path_alt = @"c:\Tech_Otchet SMART";
            filename = template_path_alt + @"\" + template_name;

            if (System.IO.File.Exists(filename))
            {
                return filename;
            }

            throw new Exception(@"Не найден файл " + filename + " в папках " + template_path + "   и   " + template_path_alt);
        }

        public void Show()
        {
            ww.Show();
        }


        public string Generate()
        {
               try
            {
                GenerateTheReport();
                return "";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        internal virtual void GenerateTheReport()
        {
        }

    }
}
