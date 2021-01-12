using System;
using UnityEngine.Serialization;

namespace Statistics
{
    [Serializable]
    public class Data
    {
        public int day;

        public float avgManufactureMoney;
        public float avgProductCoastPrice;
        public float avgProductCreationTime;

        public Exchange exchange;
        public TaxOffice taxOffice;
    }

    [Serializable]
    public class Exchange
    {
        public int soldProducts;
        public float vat;
    }

    [Serializable]
    public class TaxOffice
    {
        public float taxes;
        public float fines;
        public float bribes;

        public float uncollectedTaxes;
    }
}