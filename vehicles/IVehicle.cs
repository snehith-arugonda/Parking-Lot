namespace ParkingLotSystem
{
    interface Ivehicle
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