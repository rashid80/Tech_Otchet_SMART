using System.Collections.Generic;

namespace Tech_Otchet_SMART
{
    class Mass1
    {
        public string name;
        public decimal temperature;
        public decimal humidity;
        public decimal pressure;
        public string period;
        public List<string> var1;
        public List<string> var2;

        public Mass1()
        {
            var1 = new List<string>();
            var2 = new List<string>();
        }
    }
}
