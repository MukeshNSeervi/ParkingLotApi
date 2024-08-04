using ParkingLotApp.Models;

namespace ParkingLotApp.Repository;

public interface IParkRepository
{
    public bool InitializePArkingSystem(ParkingInitModel parkingInitModel);

    public bool IsSpaceAvaialble(string vehicalType);

    public TicketResponseModel? ParkVehical(VehicalParkRequestModel vehicalParkRequestModel);

    public bool UnParkVehical(string ticketID);
}