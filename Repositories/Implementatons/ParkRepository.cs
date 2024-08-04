using ParkingLotApp.Models;
using ParkingLotApp.Repository;
using ParkingLotApp.Utilities;

public class ParkRepository : IParkRepository
{
    Dictionary<string,List<VehicalSpotModel>> _database = new();
    Dictionary<string,TicketModel> _ticketInfo = new();
    public bool InitializePArkingSystem(ParkingInitModel parkingInitModel)
    {
        try
        {
            if(parkingInitModel.TwoWheelerCapacity > 0)
            {
                InitTwoWheeler(parkingInitModel);
            }
            if(parkingInitModel.FourWheelerCapacity > 0)
            {
                InitFourWheeler(parkingInitModel);
            }
            if(parkingInitModel.HeavyWheelerCapacity > 0)
            {
                InitHeavyVehical(parkingInitModel);
            }
            return true;
        }
        catch(Exception)
        {
            //handle Exception
        }
        return false;
    }

    private void InitHeavyVehical(ParkingInitModel parkingInitModel)
    {
         _database.Add(AppConstants.VehicalType.HeavyVehical.ToString(), new());
        for (int i = 0; i < parkingInitModel.HeavyWheelerCapacity; i++)
        {
            _database[AppConstants.VehicalType.HeavyVehical.ToString()].Add(new()
            {
                IsOccupied = false,
                SpotId = $"Spot-{Guid.NewGuid()}",
                VehicalType = AppConstants.VehicalType.HeavyVehical.ToString()
            });
        }
    }

    private void InitFourWheeler(ParkingInitModel parkingInitModel)
    {
         _database.Add(AppConstants.VehicalType.FourWheeler.ToString(), new());
        for (int i = 0; i < parkingInitModel.FourWheelerCapacity; i++)
        {
            _database[AppConstants.VehicalType.FourWheeler.ToString()].Add(new()
            {
                IsOccupied = false,
                SpotId = $"Spot-{Guid.NewGuid()}",
                VehicalType = AppConstants.VehicalType.FourWheeler.ToString()
            });
        }
    }

    private void InitTwoWheeler(ParkingInitModel parkingInitModel)
    {
        _database.Add(AppConstants.VehicalType.TwoWheeler.ToString(), new());
        for (int i = 0; i < parkingInitModel.TwoWheelerCapacity; i++)
        {
            _database[AppConstants.VehicalType.TwoWheeler.ToString()].Add(new()
            {
                IsOccupied = false,
                SpotId = $"Spot-{Guid.NewGuid()}",
                VehicalType = AppConstants.VehicalType.TwoWheeler.ToString()
            });
        }
    }

    public bool IsSpaceAvaialble(string vehicalType)
    {
        return _database[vehicalType].Where(x => !x.IsOccupied).Select(x => x).FirstOrDefault() != null;
    }

    public TicketResponseModel? ParkVehical(VehicalParkRequestModel vehicalParkRequestModel)
    {
        var spotDetails = _database[vehicalParkRequestModel.VehicalType]
                            .Where(x => !x.IsOccupied)
                            .Select(x => x).FirstOrDefault();
        if(spotDetails != null)
        {
            _database[vehicalParkRequestModel.VehicalType]
                    .Where(x => x.SpotId == spotDetails.SpotId)
                    .Select(x => x)
                    .First().IsOccupied = true;
            string ticketId = $"Id-{Guid.NewGuid()}";
            _ticketInfo.Add(ticketId,new(){
                SpotId = spotDetails.SpotId,
                TicketId = ticketId,
                VehicalType = vehicalParkRequestModel.VehicalType
            });
            return new()
            {
                InTime = DateTime.UtcNow,
                OutTime = DateTime.UtcNow.AddMinutes(-vehicalParkRequestModel.Duration),
                SpotId = spotDetails.SpotId,
                TicketId = $"Id-{Guid.NewGuid()}",
                VehicalNumber = vehicalParkRequestModel.VehicalNumber
            };
        }
        return null;
    }

    public bool UnParkVehical(string ticketID)
    {
        if(_ticketInfo.TryGetValue(ticketID,out var ticketModel))
        {
            _database[ticketModel.VehicalType]
                .Where(x => x.SpotId == ticketModel.SpotId)
                .Select(x => x).First().IsOccupied = false;
            _ticketInfo.Remove(ticketID);
            return true;
        }
        return false;
    }
}