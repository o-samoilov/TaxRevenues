using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Manufacture : MonoBehaviour
{
    public GameObject productPrefab;

    private float _money = 0;
    
    void Start()
    {
    }

    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Z))
        {
            CreateProduct();
        }*/

        /*if (Exchange.IsPossibleSell())
        {
            var product = CreateProduct();
            _money += Exchange.Sold(product);
        }*/
    }

    public GameObject CreateProduct()
    {
        var productPrefabPosition = gameObject.transform.position;
        productPrefabPosition.z -= 3;
        productPrefabPosition.y = 1;

        return Instantiate(productPrefab, productPrefabPosition, Quaternion.identity);
    }
}