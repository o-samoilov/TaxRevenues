using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
using GeneticAlgorithm;

public class ManufacturesManager : MonoBehaviour
{
    private const int TopManufactureMaxIndex = 10;
        
    private List<Manufacture> _manufactures = new List<Manufacture>();
    private ProbabilityManager _probabilityManager = new ProbabilityManager();
    private Random _random = new Random();
    
    private void Start()
    {
        var world = gameObject.transform.parent.gameObject;
        foreach (var manufacture in world.GetComponentsInChildren<Manufacture>())
        {
            _manufactures.Add(manufacture);
        }

        var test = GetTopManufactureDnk();
        var test2 = GetRandomManufactureDnk();
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
        
        //todo deep copy 
        //todo mutatation

        return dnk;
    }

    private Dnk GetTopManufactureDnk()
    {
        var bestManufactures = new List<Manufacture>();
        bestManufactures.Sort();
        
        var index = _random.Next(0, _manufactures.Count);
        var manufacture = _manufactures[index];
        
        return manufacture.Dnk;
    }
    
    private Dnk GetRandomManufactureDnk()
    {
        var index = _random.Next(0, _manufactures.Count);
        var manufacture = _manufactures[index];

        return manufacture.Dnk;
    }
}