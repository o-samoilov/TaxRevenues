using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Common
{
    public class Menu : MonoBehaviour
    {
        public WorldDateTime worldDateTime;
        public Exchange exchange;
        public TaxOffice taxOffice;

        public TextMeshProUGUI worldDateTimeText;
        public TextMeshProUGUI exchangeText;
        
        private void Start()
        {
            worldDateTime.NewDay += WorldDateTimeNewDayHandler;
        }
        
        private void WorldDateTimeNewDayHandler(object sender, Event.WorldDateTimeEventArgs e)
        {
            worldDateTimeText.text = $"Current Day: {e.Day}";
            exchangeText.text = $"Sold Products: {Exchange.SoldProducts}";
        }
    }
}
