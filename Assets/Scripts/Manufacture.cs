using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Manufacture : MonoBehaviour
{
    public GameObject productPrefab;

    private float _money = 0;

    private VM.Basic _vm;

    void Start()
    {
        _vm = new VM.Basic(this);
    }

    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Z))
        {
            SetMiddleSize();
        }*/
        
        _vm.Process();
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
    
    public void SetMiddleSize()
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