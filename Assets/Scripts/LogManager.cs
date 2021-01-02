using System.IO;

public class LogManager
{
    // todo in config
    private string _logPath = "C:\\Users\\alexa\\Desktop\\Log\\";
        
    public void SaveManufactureAliveInfo(int day, Manufacture manufacture)
    {
        SaveManufactureInfo("Alive", day, manufacture);
    }
    
    public void SaveManufactureDieInfo(int day, Manufacture manufacture)
    {
        SaveManufactureInfo("Die", day, manufacture);
    }
    
    public void SaveManufactureInfo(string action, int day, Manufacture manufacture)
    {
        var message =
            $"Day: {day}\n" +
            $"Action: {action}\n" +
            $"ID: {manufacture.GetId()}\n" +
            $"Money: {manufacture.Money}\n" +
            $"Product coast price: {manufacture.ProductCoastPrice}\n" +
            $"Product creation time: {manufacture.ProductCreationTime}\n" +
            $"Gen: {manufacture.Dnk.MainGen.ToString()}\n";

        var fileName = $"Manufacture_day_{day}_id_{manufacture.GetId()}_action_{action}";
        var filePath = _logPath + fileName;
        
        //File.Create(_logPath + fileName)
        
        using (var writer = new StreamWriter(filePath))  
        {  
            writer.WriteLine(message);  
        }  
    }
}