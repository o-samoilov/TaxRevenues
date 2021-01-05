using System.Collections.Generic;
using UnityEngine;
using GeneticAlgorithm;
using Random = UnityEngine.Random;

public class ManufacturesManager : MonoBehaviour
{
    private const int TopManufacturePart = 30; // 30%

    private List<Manufacture> _manufactures = new List<Manufacture>();
    private ProbabilityManager _probabilityManager = new ProbabilityManager();

    private int _id = 1;

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
        var dnk = GetTopManufactureDnk();

        //mutation probability: 20%
        if (_probabilityManager.IsProbability(20))
        {
            dnk.Mutate();

            Debug.Log("Mutation");
        }

        return dnk;
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

    private Dnk GetRandomManufactureDnk()
    {
        var index = Random.Range(0, _manufactures.Count);
        var manufacture = _manufactures[index];

        return (Dnk) manufacture.Dnk.Clone();
    }
}