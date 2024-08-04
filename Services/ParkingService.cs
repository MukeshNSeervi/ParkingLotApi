using ParkingLotApp.Models;
using ParkingLotApp.Repository;

namespace ParkingLotApp.Service;

public class ParkingLotService : IParkingService
{
    private readonly IParkRepository _parkRepository;
    public ParkingLotService(IParkRepository parkRepository)
    {
        _parkRepository = parkRepository;
    }
    public bool InitializeParkingLot(ParkingInitModel parkingInitModel)
    {
        return _parkRepository.InitializePArkingSystem(parkingInitModel);   
    }

    public bool IsSpaceAvaialble(string vehicalType)
    {
        return _parkRepository.IsSpaceAvaialble(vehicalType);
    }

    public TicketResponseModel? ParkVehical(VehicalParkRequestModel vehicalParkRequestModel)
    {
       return _parkRepository.ParkVehical(vehicalParkRequestModel);
    }

    public bool UnParkVehical(string ticketId)
    {
        return _parkRepository.UnParkVehical(ticketId);
    }
}