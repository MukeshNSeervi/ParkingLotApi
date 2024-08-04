namespace ParkingLotApp.Models;

public class VehicalParkRequestModel
{
    public string VehicalType {get;set;} = null!;
    public string VehicalNumber {get;set;} = null!;
    public int Duration {get;set;}
}