using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using GeneticAlgorithm;
using Random = UnityEngine.Random;

public class ManufacturesManager : MonoBehaviour
{
    public WorldDateTime worldDateTime;

    private const int TopManufacturePart = 25; // 25%

    private List<Manufacture> _manufactures = new List<Manufacture>();
    private ProbabilityManager _probabilityManager = new ProbabilityManager();

    private int _manufactureId = 1;

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
            manufacture.Id = _manufactureId;

            _manufactureId++;
        }
    }

    public List<Manufacture> GetManufactures()
    {
        return _manufactures;
    }

    public int GetManufactureId()
    {
        return ++_manufactureId;
    }

    private List<Dnk> GetTopManufacturesDnk()
    {
        var result = new List<Dnk>();

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
        var countGenToReproduction = _manufactures.Count / topManufactureMaxIndex;

        for (var i = 0; i < topManufactureMaxIndex; i++)
        {
            var manufacture = _manufactures[i];

            for (var j = 0; j < countGenToReproduction; j++)
            {
                var dnk = (Dnk) manufacture.Dnk.Clone();

                //mutation probability: 20%
                if (_probabilityManager.IsProbability(20))
                {
                    dnk.Mutate();

                    Debug.Log("Mutation");
                }

                result.Add(dnk);
            }
        }

        return result;
    }

    private void WorldDateTimeNewDayHandler(object sender, Event.WorldDateTimeEventArgs e)
    {
        var isAllManufacturesDie = true;

        //kill old manufacture
        foreach (var manufacture in _manufactures)
        {
            if (manufacture.IsAlive &&
                worldDateTime.CurrentDay - manufacture.CreateDay > Settings.Basic.ManufactureLiveDays
            )
            {
                manufacture.Die();
            }

            if (manufacture.IsAlive)
            {
                isAllManufacturesDie = false;
            }
        }

        //new iteration, alive all manufactures
        if (isAllManufacturesDie)
        {
            var index = 0;
            var topManufacturesDnk = GetTopManufacturesDnk();

            foreach (var manufacture in _manufactures)
            {
                var dnk = topManufacturesDnk[index];

                manufacture.Alive(GetManufactureId(), dnk);

                index++;
            }
        }
    }
}