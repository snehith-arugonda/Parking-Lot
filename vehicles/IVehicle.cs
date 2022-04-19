namespace ParkingLotSystem
{
    interface IVehicle
    {
        string VehicleNumber
        {
            get;set;
        }
        VehicleTypes VehicleType
        {
            get;
        }

        ParkingTicket Ticket
        {
            get;set;
        }

    }
}