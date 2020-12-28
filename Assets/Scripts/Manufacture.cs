using System;
using System.Collections.Generic;
using System.Diagnostics;
using GeneticAlgorithm;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;
using Debug = UnityEngine.Debug;

public class Manufacture : MonoBehaviour
{
    public WorldDateTime worldDateTime;
    public ManufacturesManager manufacturesManager;
    public GameObject productPrefab;

    public Material liveMaterial;
    public Material dieMaterial;
    private Renderer _renderer;

    private VM.Basic _vm;
    private TaxOffice _taxOffice;
    private Stopwatch _stopWatch;

    public float Money => _money;
    public Dnk Dnk => _dnk;

    private float _money;
    private Dnk _dnk;

    private float _productCoastPrice;
    private float _productCreationTime;

    private const float ProductReduceCoastPricePrice = 50f;
    private const float ProductReduceCreationTimePrice = 50f;

    private const float MinProductCoastPricePrice = 10f;
    private const float MinProductCreationTimePrice = 1f;

    private bool _isAlive;
    private bool _isBusy;
    private float _busyTime;

    public int CreateDay => _createDay;
    private int _createDay;

    private const string BigSize = "big_size";
    private const string MediumSize = "medium_size";
    private const string SmallSize = "small_size";

    private string _currentSize;

    private void Awake()
    {
        _taxOffice = new TaxOffice();
        _stopWatch = new Stopwatch();

        _renderer = gameObject.GetComponentInChildren<Renderer>();

        var environment = gameObject.transform.parent.gameObject;
        var world = environment.transform.parent.gameObject;
        worldDateTime = world.GetComponentInChildren<WorldDateTime>();
        manufacturesManager = world.GetComponentInChildren<ManufacturesManager>();

        InitializeSettings(new DnkFactory().CreateRandom());
        worldDateTime.NewDay += WorldDateTimeNewDayHandler;
    }

    private void Update()
    {
        if (!_isAlive)
        {
            return;
        }

        CheckBusy();

        if (!_isBusy)
        {
            _vm.Process();
            MarkBusy(0.5f);
        }
    }

    public int GetId()
    {
        return this.GetHashCode();
    }

    private void InitializeSettings(Dnk dnk)
    {
        _dnk = dnk;
        _money = Settings.Basic.ManufactureMoney;
        _productCoastPrice = Settings.Basic.ManufactureProductCoast;
        _productCreationTime = Settings.Basic.ManufactureProductCreationTime;

        _isAlive = true;
        _isBusy = false;

        _currentSize = SmallSize;

        _createDay = worldDateTime.CurrentDay;

        _vm = new VM.Basic(this, _dnk);
    }

    private void MarkBusy(float time)
    {
        if (_isBusy)
        {
            return;
        }

        _isBusy = true;
        _busyTime = time;
        _stopWatch.Start();
    }

    private void CheckBusy()
    {
        if (!_isBusy)
        {
            return;
        }

        var duration = float.Parse(_stopWatch.Elapsed.ToString(@"ss\,fff"));

        if (duration >= _busyTime)
        {
            _isBusy = false;
            _stopWatch.Stop();
            _stopWatch.Reset();
        }
    }

    private void Die()
    {
        _isAlive = false;
        _renderer.material = dieMaterial;

        Debug.Log("Die");
    }

    private void Alive(GeneticAlgorithm.Dnk dnk)
    {
        InitializeSettings(dnk);
        _renderer.material = liveMaterial;

        CheckSize();
    }

    private void WorldDateTimeNewDayHandler(object sender, Event.WorldDateTimeEventArgs e)
    {
        if (_isAlive)
        {
            Debug.Log("Pay maintenance (100)");
            SpendMoney(100);

            return;
        }

        Alive(manufacturesManager.GetDnk());

        //todo save statistic
    }

    #region Finance

    public void AddMoney(float money)
    {
        _money += money;
        CheckSize();

        Debug.Log("Add money. Money: " + _money);
    }

    private void SpendMoney(float money)
    {
        _money -= money;

        if (_money < 0)
        {
            Die();

            return;
        }

        CheckSize();

        Debug.Log("Spend money. Money: " + _money);
    }

    public void PayTaxes(Product product)
    {
        float taxes = _taxOffice.CalculateTaxes(this, product);

        Debug.Log("Pay taxes " + taxes);
        SpendMoney(taxes);

        //todo statistic
    }

    public void PayFines(Product product)
    {
        float fines = _taxOffice.CalculateFines(this, product);

        Debug.Log("Pay fines " + fines);
        SpendMoney(fines);

        //todo statistic
    }

    public void PayBribe(Product product)
    {
        float bribe = _taxOffice.CalculateBribe(this, product);

        Debug.Log("Pay bribe " + bribe);
        SpendMoney(bribe);

        //todo statistic
    }

    #endregion

    #region Product

    public bool IsPossibleCreateProduct()
    {
        return _money >= _productCoastPrice;
    }

    [CanBeNull]
    public Product CreateProduct()
    {
        if (!IsPossibleCreateProduct() || _isBusy)
        {
            return null;
        }

        Debug.Log("Create product");
        SpendMoney(_productCoastPrice);
        MarkBusy(_productCreationTime);

        //Create product from prefab
        var productPrefabPosition = gameObject.transform.position;
        if (_currentSize == SmallSize)
        {
            productPrefabPosition.z -= 3;
            productPrefabPosition.y = 1;
        }
        else if (_currentSize == MediumSize)
        {
            productPrefabPosition.z -= 5;
            productPrefabPosition.y = 2;
        }
        else
        {
            productPrefabPosition.z -= 6;
            productPrefabPosition.y = 3;
        }

        var environment = gameObject.transform.parent.gameObject;

        var productGameObject = Instantiate(productPrefab, productPrefabPosition, Quaternion.identity);
        productGameObject.transform.SetParent(environment.transform);

        var product = environment.GetComponentInChildren<Product>();
        product.CoastPrice = _productCoastPrice;

        return product;
    }

    public bool IsPossibleReduceProductCoastPrice()
    {
        return _productCoastPrice <= MinProductCoastPricePrice &&
               Money >= ProductReduceCoastPricePrice;
    }

    public bool ReduceProductCoastPrice()
    {
        if (!IsPossibleReduceProductCoastPrice())
        {
            return false;
        }

        _productCoastPrice -= 0.01f;
        SpendMoney(ProductReduceCoastPricePrice);

        return true;
    }

    public bool IsPossibleReduceProductCreationTime()
    {
        return _productCreationTime <= MinProductCreationTimePrice &&
               Money >= ProductReduceCreationTimePrice;
    }

    public bool ReduceProductCreationTime()
    {
        if (!IsPossibleReduceProductCreationTime())
        {
            return false;
        }

        _productCreationTime -= 0.01f;
        SpendMoney(ProductReduceCreationTimePrice);

        return true;
    }

    #endregion

    #region Size Manufacture Object

    public void CheckSize()
    {
        //todo const
        if (_money <= 5000f)
        {
            SetSmallSize();
        }
        else if (_money <= 20000f)
        {
            SetMediumSize();
        }
        else
        {
            SetBigSize();
        }
    }

    public void SetSmallSize()
    {
        if (_currentSize == SmallSize)
        {
            return;
        }

        _currentSize = SmallSize;

        Scale(new Vector3(1f, 1f, 1f), 1.6f);
    }

    public void SetMediumSize()
    {
        if (_currentSize == MediumSize)
        {
            return;
        }

        _currentSize = MediumSize;

        Scale(new Vector3(1.5f, 3f, 1.5f), 3.8f);
    }

    public void SetBigSize()
    {
        if (_currentSize == BigSize)
        {
            return;
        }

        _currentSize = MediumSize;

        Scale(new Vector3(2f, 5f, 2f), 6f);
    }

    private void Scale(Vector3 scale, float y)
    {
        gameObject.transform.localScale = scale;

        gameObject.transform.position = new Vector3(
            gameObject.transform.position.x,
            y,
            gameObject.transform.position.z
        );
    }

    #endregion
}