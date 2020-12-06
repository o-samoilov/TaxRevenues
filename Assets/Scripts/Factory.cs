using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Factory : MonoBehaviour
{
    public GameObject productPrefab;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            CreateProduct();
        }
    }

    public void CreateProduct()
    {
        var productPrefabPosition = gameObject.transform.position;
        productPrefabPosition.z -= 3;
        productPrefabPosition.y = 1;

        Instantiate(productPrefab, productPrefabPosition, Quaternion.identity);
    }
}