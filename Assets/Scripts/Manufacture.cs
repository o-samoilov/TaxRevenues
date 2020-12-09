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
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SetBigSize();
        }

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

    public void SetSmallSize()
    {
        Scale(new Vector3(1f, 1f, 1f));
    }
    
    public void SetMidldeSize()
    {
        Scale(new Vector3(1.5f, 3f, 1.5f));
    }
    
    public void SetBigSize()
    {
        Scale(new Vector3(2f, 5f, 2f));
    }

    private void Scale(Vector3 scale)
    {
        gameObject.transform.localScale = scale;

        gameObject.transform.position = new Vector3(
            gameObject.transform.position.x,
            (scale.y / 2) * -1,
            gameObject.transform.position.z
        );
    }
}