using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
using GeneticAlgorithm;

public class ManufacturesManager : MonoBehaviour
{
    private const int TopManufacturePart = 10; // 10%
        
    private List<Manufacture> _manufactures = new List<Manufacture>();
    private ProbabilityManager _probabilityManager = new ProbabilityManager();
    private Random _random = new Random();
    
    private GenElementFactory _genElementFactory = new GenElementFactory();
    
    private void Start()
    {
        var world = gameObject.transform.parent.gameObject;
        foreach (var manufacture in world.GetComponentsInChildren<Manufacture>())
        {
            _manufactures.Add(manufacture);
        }
    }

    public Dnk GetDnk()
    {
        Dnk dnk;
        if (_probabilityManager.IsProbability(80))
        {
            dnk = GetTopManufactureDnk();
        }
        else
        {
            dnk = GetRandomManufactureDnk();
        }
        
        //mutation probability: 20%
        if (_probabilityManager.IsProbability(20))
        {
            var index = _random.Next(0, dnk.MainGen.Size());
            
            dnk.MainGen.SetElement(index, _genElementFactory.CreateRandom());
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

        var topManufactureMaxIndex = (int) (_manufactures.Count * TopManufacturePart / 100);
        
        var index = _random.Next(0, topManufactureMaxIndex);
        var manufacture = _manufactures[index];
        
        return (Dnk)manufacture.Dnk.Clone();
    }
    
    private Dnk GetRandomManufactureDnk()
    {
        var index = _random.Next(0, _manufactures.Count);
        var manufacture = _manufactures[index];

        return (Dnk)manufacture.Dnk.Clone();
    }
}