using Microsoft.AspNetCore.Mvc;
using ParkingLotApp.Models;
using ParkingLotApp.Service;

namespace ParkingLotApp.Controller;

[ApiController]
[Route("[controller]")]
public class ParkingLotController : ControllerBase
{
    private readonly IParkingService _parkingService;
    public ParkingLotController(IParkingService parkingService)
    {
        _parkingService = parkingService;
    }
    [HttpPost]
    public bool Post(ParkingInitModel parkingInit)
    {
        return _parkingService.InitializeParkingLot(parkingInit);
    }
    [HttpGet]
    public bool Get(string vehicalType)
    {
        return _parkingService.IsSpaceAvaialble(vehicalType);
    }
    [HttpPut]
    public TicketResponseModel? Put(VehicalParkRequestModel vehicalParkRequest)
    {
        return _parkingService.ParkVehical(vehicalParkRequest);
    }
    [HttpDelete]
    public bool Delete(string ticketID)
    {
        return _parkingService.UnParkVehical(ticketID);
    }


}