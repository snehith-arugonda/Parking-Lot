namespace ParkingLotSystem
{
    interface IVehicle
    {
        string VehicleNumber
        {
            get;set;
        }
        VehicleType VehicleType
        {
            get;
        }

        ParkingTicket Ticket
        {
            get;set;
        }

    }
}