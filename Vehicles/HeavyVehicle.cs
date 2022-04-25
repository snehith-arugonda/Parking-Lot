namespace ParkingLotSystem
{
    class  HeavyVehicle:IVehicle
    {
        public string VehicleNumber{ get;set; } = string.Empty;
        public VehicleType VehicleType
        {
            get
            {
                return VehicleType.HeavyVehicle;
            }
        }

        public ParkingTicket Ticket{get;set;}

        public override string ToString()
        {
            return $"{this.Ticket.SlotNumber} {this.VehicleNumber}";
        }

    }
}