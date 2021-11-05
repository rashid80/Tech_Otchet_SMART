using System.Collections.Generic;

namespace Tech_Otchet_SMART
{
    class Mass2
    {
        public string name;
        public decimal temperature;
        public decimal humidity;
        public decimal pressure;
        public string period;
        public List<Mass2infoLine0> tps;

        public Mass2()
        {
            tps = new List<Mass2infoLine0>();
        }
    }


    class Mass2infoLine0
    {
        public string numTP;
        public List<Mass2infoLine1> cls;

        public Mass2infoLine0()
        {
            cls = new List<Mass2infoLine1>();
        }
    }

    class Mass2infoLine1
    {
        public string consumerLine;
        public List<Mass2infoLine2> infoLines;

        public Mass2infoLine1()
        {
            infoLines = new List<Mass2infoLine2>();
        }

    }

    class Mass2infoLine2
    {
        public string numTT;
        public decimal primaryAmperage;
        public decimal transformCoef;
        public string transformType;
    }

}
