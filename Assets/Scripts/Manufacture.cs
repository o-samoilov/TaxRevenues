using System.Diagnostics;
using GeneticAlgorithm;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Manufacture : MonoBehaviour
{
    public WorldDateTime worldDateTime;
    public ManufacturesManager manufacturesManager;
    public GameObject productPrefab;
    public TextMeshPro textInfo;

    public Material liveMaterial;
    public Material dieMaterial;

    public GameObject manufactureModel;

    public int Id { get; set; }

    public float Money { get; private set; }
    public Dnk Dnk { get; private set; }
    public float ProductCoastPrice { get; private set; }
    public float ProductCreationTime { get; private set; }
    public int CreateDay { get; private set; }

    private const float ProductReduceCoastPricePrice = 50f;
    private const float ProductReduceCreationTimePrice = 50f;

    private const float MinProductCoastPricePrice = 10f;
    private const float MinProductCreationTimePrice = 0.1f;

    private Renderer _renderer;

    private VM.Basic _vm;
    private Stopwatch _stopWatch = new Stopwatch();

    private bool _isAlive = true;
    private bool _isBusy = false;
    private float _busyTime;
    
    private bool _showInfoText = false;

    private const string SmallSize = "small_size";
    private const string MediumSize = "medium_size";
    private const string BigSize = "big_size";
    private const string ExtraBigSize = "extra_big_size";

    private string _currentSize;

    private void Start()
    {
        _renderer = gameObject.GetComponentInChildren<Renderer>();

        var environment = gameObject.transform.parent.gameObject;
        var world = environment.transform.parent.gameObject;
        worldDateTime = world.GetComponentInChildren<WorldDateTime>();
        manufacturesManager = world.GetComponentInChildren<ManufacturesManager>();

        textInfo = gameObject.GetComponentInChildren<TextMeshPro>();

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
            MarkBusy(0.1f);
        }
    }

    public void ShowInfoText()
    {
        _showInfoText = true;
        UpdateInfoText();
    }
    
    public void HideInfoText()
    {
        _showInfoText = false;
        textInfo.text = "";
    }
    
    private void UpdateInfoText()
    {
        if (!_showInfoText)
        {
            return;
        }

        textInfo.text = $"ID: {Id}\n" +
                        $"Create day: {CreateDay}\n" +
                        $"Money: {Money}\n" +
                        $"Pr. coast: {ProductCoastPrice}\n" +
                        $"Pr. time: {ProductCreationTime}\n";
    }

    private void InitializeSettings(Dnk dnk)
    {
        Dnk = dnk;
        Money = Settings.Basic.ManufactureMoney;
        ProductCoastPrice = Settings.Basic.ProductCoast;
        ProductCreationTime = Settings.Basic.ProductCreationTime;

        _isBusy = false;
        CheckSize();
        
        CreateDay = worldDateTime.CurrentDay;

        _vm = new VM.Basic(this, Dnk);
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

    private void Alive(int id, GeneticAlgorithm.Dnk dnk)
    {
        _isAlive = true;

        Id = id;
        InitializeSettings(dnk);
        _renderer.material = liveMaterial;

        CheckSize();
        UpdateInfoText();

        Debug.Log("Alive");
    }

    private void Die()
    {
        _isAlive = false;
        _renderer.material = dieMaterial;

        Debug.Log("Die");
    }

    private void WorldDateTimeNewDayHandler(object sender, Event.WorldDateTimeEventArgs e)
    {
        if (_isAlive)
        {
            SpendMoney(Settings.Basic.ManufactureMaintenanceCost);

            if (worldDateTime.CurrentDay - CreateDay > Settings.Basic.ManufactureLiveDays)
            {
                Die();
            }

            return;
        }

        Alive(manufacturesManager.GetManufactureId(), manufacturesManager.GetDnk());

        //todo save statistic
    }

    #region Finance

    public void AddMoney(float money)
    {
        Money += money;

        CheckSize();
        UpdateInfoText();
    }

    private void SpendMoney(float money)
    {
        Money -= money;

        if (Money < 0)
        {
            Die();

            return;
        }

        CheckSize();
        UpdateInfoText();
    }

    public void PayTaxes(Product product)
    {
        float taxes = TaxOffice.CalculateTaxes(this, product);
        SpendMoney(taxes);

        TaxOffice.PayTaxes(taxes);

        //todo statistic
    }

    public void PayFines(Product product)
    {
        float fines = TaxOffice.CalculateFines(this, product);
        SpendMoney(fines);

        TaxOffice.PayFines(fines);

        //todo statistic
    }

    public void PayBribe(Product product)
    {
        float bribe = TaxOffice.CalculateBribe(this, product);
        SpendMoney(bribe);

        TaxOffice.PayBribe(bribe);

        //todo statistic
    }

    #endregion

    #region Product

    public bool IsPossibleCreateProduct()
    {
        return Money >= ProductCoastPrice;
    }

    [CanBeNull]
    public Product CreateProduct()
    {
        if (!IsPossibleCreateProduct() || _isBusy)
        {
            return null;
        }

        SpendMoney(ProductCoastPrice);
        MarkBusy(ProductCreationTime);

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
        product.CoastPrice = ProductCoastPrice;

        return product;
    }

    public bool IsPossibleReduceProductCoastPrice()
    {
        return ProductCoastPrice > MinProductCoastPricePrice &&
               Money >= ProductReduceCoastPricePrice;
    }

    public bool ReduceProductCoastPrice()
    {
        if (!IsPossibleReduceProductCoastPrice())
        {
            return false;
        }

        ProductCoastPrice -= 1f;
        SpendMoney(ProductReduceCoastPricePrice);

        return true;
    }

    public bool IsPossibleReduceProductCreationTime()
    {
        return ProductCreationTime > MinProductCreationTimePrice &&
               Money >= ProductReduceCreationTimePrice;
    }

    public bool ReduceProductCreationTime()
    {
        if (!IsPossibleReduceProductCreationTime())
        {
            return false;
        }

        ProductCreationTime -= 0.1f;
        SpendMoney(ProductReduceCreationTimePrice);

        return true;
    }

    #endregion

    #region Size Manufacture Model

    private void CheckSize()
    {
        //todo const
        if (Money <= 5000f)
        {
            SetSmallSize();
        }
        else if (Money <= 15000f)
        {
            SetMediumSize();
        }
        else if (Money <= 50000f)
        {
            SetBigSize();
        }
        else
        {
            SetExtraBigSize();
        }
    }

    private void SetSmallSize()
    {
        if (_currentSize == SmallSize)
        {
            return;
        }

        _currentSize = SmallSize;

        Scale(new Vector3(0.01f, 0.01f, 0.01f), 1.6f);
    }

    private void SetMediumSize()
    {
        if (_currentSize == MediumSize)
        {
            return;
        }

        _currentSize = MediumSize;

        Scale(new Vector3(0.015f, 0.015f, 0.04f), 4.7f);
    }

    private void SetBigSize()
    {
        if (_currentSize == BigSize)
        {
            return;
        }

        _currentSize = BigSize;

        Scale(new Vector3(0.02f, 0.02f, 0.08f), 8.6f);
    }

    private void SetExtraBigSize()
    {
        if (_currentSize == ExtraBigSize)
        {
            return;
        }

        _currentSize = ExtraBigSize;

        Scale(new Vector3(0.02f, 0.025f, 0.12f), 12.5f);
    }

    private void Scale(Vector3 scale, float y)
    {
        manufactureModel.transform.localScale = scale;

        manufactureModel.transform.position = new Vector3(
            manufactureModel.transform.position.x,
            y,
            manufactureModel.transform.position.z
        );
    }

    #endregion
}