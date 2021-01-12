using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using GeneticAlgorithm;
using Random = UnityEngine.Random;

public class ManufacturesManager : MonoBehaviour
{
    public WorldDateTime worldDateTime;
    
    public int ReproductionCount { get; private set; }

    private const int ReproductionGensLiveDays = 35;
    private const int TopManufacturePart = 30; // 30%

    private List<Manufacture> _manufactures = new List<Manufacture>();
    private ProbabilityManager _probabilityManager = new ProbabilityManager();

    private Queue<ReproductionDnk> _reproductionDnkQueue = new Queue<ReproductionDnk>();

    private int _id = 1;

    private void Start()
    {
        worldDateTime.NewDay += WorldDateTimeNewDayHandler;
    }

    private void Awake()
    {
        var world = gameObject.transform.parent.gameObject;
        foreach (var manufacture in world.GetComponentsInChildren<Manufacture>())
        {
            _manufactures.Add(manufacture);
            manufacture.Id = _id;

            _id++;
        }
    }

    public List<Manufacture> GetManufactures()
    {
        return _manufactures;
    }

    public int GetManufactureId()
    {
        return ++_id;
    }

    public Dnk GetDnk()
    {
        Dnk dnk;
        if (_reproductionDnkQueue.Count != 0)
        {
            dnk = _reproductionDnkQueue.Dequeue().Dnk;
        }
        else
        {
            dnk = GetTopManufactureDnk();
        }

        //mutation probability: 20%
        if (_probabilityManager.IsProbability(20))
        {
            dnk.Mutate();

            Debug.Log("Mutation");
        }

        return dnk;
    }

    public int GetReproductionDnkCount()
    {
        return _reproductionDnkQueue.Count;
    }
    
    public int GetReproductionDnkCount(int manufactureId)
    {
        return _reproductionDnkQueue.Count(x => x.ManufactureId == manufactureId);
    }

    public void AddReproductionDnk(ReproductionDnk reproductionDnk)
    {
        ReproductionCount++;
        _reproductionDnkQueue.Enqueue(reproductionDnk);
    }

    private Dnk GetTopManufactureDnk()
    {
        _manufactures.Sort(delegate(Manufacture x, Manufacture y)
        {
            if (x.Money < y.Money)
            {
                return 1;
            }

            if (x.Money > y.Money)
            {
                return -1;
            }

            return 0;
        });

        var topManufactureMaxIndex = (int) (_manufactures.Count * TopManufacturePart / 100f);

        var index = Random.Range(0, topManufactureMaxIndex);
        var manufacture = _manufactures[index];

        return (Dnk) manufacture.Dnk.Clone();
    }

    private void WorldDateTimeNewDayHandler(object sender, Event.WorldDateTimeEventArgs e)
    {
        _reproductionDnkQueue = new Queue<ReproductionDnk>(
            _reproductionDnkQueue.Where(x => e.Day - ReproductionGensLiveDays <= x.CreateDay)
        );
    }
}