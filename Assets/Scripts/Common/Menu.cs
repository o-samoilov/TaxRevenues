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
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.M))
            {
                Debug.Log("asdasdasd");
                gameObject.SetActive(!gameObject.activeSelf);
            }
        }
    }
}
