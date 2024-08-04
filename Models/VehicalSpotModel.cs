namespace ParkingLotApp.Models;

public class VehicalSpotModel
{
    public string VehicalType {get;set;} = null!;
    public string SpotId {get;set;} = null!;
    public bool IsOccupied {get;set;}
}