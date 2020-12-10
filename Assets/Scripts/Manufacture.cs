using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Serialization;
using Debug = UnityEngine.Debug;

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

    private const string BigSize = "big_size";
    private const string MediumSize = "medium_size";
    private const string SmallSize = "small_size";

    private string _currentSize = SmallSize;

    void Start()
    {
        _vm = new VM.Basic(this);
        _stopWatch = new Stopwatch();
    }

    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Z))
        {
            SetMiddleSize();
        }*/

        CheckBusy();

        if (!_isBusy)
        {
            _vm.Process();
        }
    }

    private void CheckBusy()
    {
        if (!_isBusy)
        {
            return;
        }

        var duration = float.Parse(_stopWatch.Elapsed.ToString(@"ss\,fff"));

        if (duration >= _productCreationTime)
        {
            _isBusy = false;
            _stopWatch.Stop();
            _stopWatch.Reset();
        }
    }

    public bool IsPossibleCreateProduct()
    {
        return _money >= _productCoast;
    }

    public bool CreateProduct()
    {
        if (!IsPossibleCreateProduct() || _isBusy)
        {
            return false;
        }

        _money -= _productCoast;
        _isBusy = true;
        _stopWatch.Start();

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
        if (_currentSize == SmallSize)
        {
            return;
        }

        _currentSize = SmallSize;

        Scale(new Vector3(1f, 1f, 1f));
    }

    public void SetMediumSize()
    {
        if (_currentSize == MediumSize)
        {
            return;
        }

        _currentSize = MediumSize;
        
        Scale(new Vector3(1.5f, 3f, 1.5f));
    }

    public void SetBigSize()
    {
        if (_currentSize == BigSize)
        {
            return;
        }

        _currentSize = MediumSize;
        
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