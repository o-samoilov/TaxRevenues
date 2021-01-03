using TMPro;
using UnityEngine;

namespace Common
{
    public class Menu : MonoBehaviour
    {
        public WorldDateTime worldDateTime;

        public TextMeshProUGUI worldDateTimeText;
        public TextMeshProUGUI exchangeText;
        public TextMeshProUGUI taxOfficeText;
        
        private void Start()
        {
            worldDateTime.NewDay += WorldDateTimeNewDayHandler;
        }

        private void Update()
        {
            exchangeText.text = $"Sold Products: {Exchange.SoldProducts}\n" +
                                $"Sold Products Today: {Exchange.SoldProductsToday}";
            
            taxOfficeText.text = $"Taxes: \n" +
                                 $"B: {TaxOffice.Bribe}, F: {TaxOffice.Fines}, T: {TaxOffice.Taxes}\n" +
                                 $"CB: {TaxOffice.CurrentDayBribe}, CF: {TaxOffice.CurrentDayFines}, CT: {TaxOffice.CurrentDayTaxes}\n";
        }

        private void WorldDateTimeNewDayHandler(object sender, Event.WorldDateTimeEventArgs e)
        {
            worldDateTimeText.text = $"Current Day: {e.Day}";
            //exchangeText.text = $"Sold Products: {Exchange.SoldProducts}";
        }
    }
}
