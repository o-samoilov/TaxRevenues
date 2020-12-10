using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Serialization;

public class Manufacture : MonoBehaviour
{
    public GameObject productPrefab;

    private VM.Basic _vm;

    private float _money = Settings.Basic.StartManufactureMoney;
    private float _productCoast = Settings.Basic.StartManufactureProductCoast;
    private float _productCreationTime = Settings.Basic.StartManufactureProductCreationTime;

    private Stopwatch _stopWatch;
    private bool _isBusy = false;
    private TimeSpan _productCreate;


    void Start()
    {
        _vm = new VM.Basic(this);
        _stopWatch = new Stopwatch();
        _stopWatch.Start();
    }

    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Z))
        {
            SetMiddleSize();
        }*/


        //_vm.Process();
    }

    public bool IsBusy()
    {
        return _isBusy;
    }
    
    private void checkBusy()
    {
        TimeSpan ts = _stopWatch.Elapsed;

    }

    public bool IsPossibleCreateProduct()
    {
        return _money >= _productCoast;
    }

    public bool CreateProduct()
    {
        if (!IsPossibleCreateProduct() || IsBusy())
        {
            return false;
        }

        _isBusy = true;
        //_productCreate = DateTime.Now.;
        
        _money -= _productCoast;

        var productPrefabPosition = gameObject.transform.position;
        productPrefabPosition.z -= 3;
        productPrefabPosition.y = 1;

        Instantiate(productPrefab, productPrefabPosition, Quaternion.identity);

        //var product = obj.GetComponentInChildren<Product>();

        return true;
    }

    public void AddMoney(float money)
    {
        _money += money;
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