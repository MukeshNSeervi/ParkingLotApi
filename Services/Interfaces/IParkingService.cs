using ParkingLotApp.Models;

namespace ParkingLotApp.Service;

public interface IParkingService
{
    public bool InitializeParkingLot(ParkingInitModel parkingInitModel);
    public bool IsSpaceAvaialble(string vehicalType);
    public TicketResponseModel? ParkVehical(VehicalParkRequestModel vehicalParkRequestModel);
    public bool UnParkVehical(string ticketId);
}