namespace ParkingLotApp.Models;

public class TicketResponseModel
{
    public string TicketId{get;set;} = null!;
    public string SpotId {get;set;} = null!;
    public DateTime InTime {get;set;}
    public DateTime OutTime {get;set;}
    public string VehicalNumber {get;set;} = null!;
}

public class TicketModel
{
    public string TicketId{get;set;} = null!;
    public string SpotId {get;set;} = null!;
    public string VehicalType {get;set;} = null!;
}