using System;
using UnityEngine.Serialization;

namespace Statistics
{
    [Serializable]
    public class Data
    {
        public int day;
        public Exchange exchange;
        public TaxOffice taxOffice;
    }

    [Serializable]
    public class Exchange
    {
        public int soldProducts;
    }

    [Serializable]
    public class TaxOffice
    {
        public float taxes;
        public float fines;
        public float bribes;
    }
}