using System;
using System.IO;
using UnityEngine;

public class Statistic : MonoBehaviour
{
    public ManufacturesManager manufacturesManager;
    public WorldDateTime worldDateTime;

    // todo in config
    private string _logPath = "C:\\Users\\alexa\\Desktop\\Log\\";

    private bool _isNeedSaveManufactureInfo = false;

    private void Start()
    {
        worldDateTime.NewDay += WorldDateTimeNewDayHandler;
    }

    private void Update()
    {
        //todo make toggle in menu
        if (Input.GetKeyDown(KeyCode.L))
        {
            _isNeedSaveManufactureInfo = !_isNeedSaveManufactureInfo;
        }
    }
    
    private void WorldDateTimeNewDayHandler(object sender, Event.WorldDateTimeEventArgs e)
    {
        if (_isNeedSaveManufactureInfo)
        {
            foreach (var manufacture in manufacturesManager.GetManufactures())
            {
                SaveManufactureInfo(e.Day, manufacture);
            }
        }

        CollectInfo(e.Day);
    }

    private void CollectInfo(int day)
    {
        var taxOffice = new Statistics.TaxOffice()
        {
            taxes = TaxOffice.Taxes,
            fines = TaxOffice.Fines,
            bribes = TaxOffice.Bribes
        };
        var exchange = new Statistics.Exchange { soldProducts = Exchange.SoldProducts};
        var data = new Statistics.Data()
        {
            day = day,
            taxOffice = taxOffice,
            exchange = exchange
        };
        
        var json = JsonUtility.ToJson(data);
        var filePath = _logPath + $"Day{day}.json";
        
        using (var writer = new StreamWriter(filePath))
        {
            writer.WriteLine(json);
        }
    }

    private void SaveManufactureInfo(int day, Manufacture manufacture)
    {
        var message =
            $"Day: {day}\n" +
            $"ID: {manufacture.Id}\n" +
            $"Create Day: {manufacture.CreateDay}\n" +
            $"Money: {manufacture.Money}\n" +
            $"Product coast price: {manufacture.ProductCoastPrice}\n" +
            $"Product creation time: {manufacture.ProductCreationTime}\n" +
            $"Gen: \n{manufacture.Dnk.MainGen.ToString()}\n";

        var dirPath = _logPath + $"Day{day}\\";
        var fileName = $"Manufacture_{manufacture.Id}";

        var filePath = dirPath + fileName;

        if (!Directory.Exists(dirPath))
        {
            Directory.CreateDirectory(dirPath);
        }

        //File.Create(_logPath + fileName)

        using (var writer = new StreamWriter(filePath))
        {
            writer.WriteLine(message);
        }
    }

    private void Save(string fileName)
    {
        /*var dirPath = _logPath + $"Day{day}\\";
        var filePath = dirPath + fileName;
        
        if (!Directory.Exists(dirPath))
        {
            Directory.CreateDirectory(dirPath);
        }*/
    }
}