namespace ParkingLotSystem
{
    class  FourWheeler:IVehicle
    {
        public string VehicleNumber{ get;set; } = string.Empty;
        public VehicleType VehicleType
        {
            get
            {
                return VehicleType.FourWheeler;
            }
        }

        public ParkingTicket Ticket { get;set; }

        public override string ToString()
        {
            return $"{this.Ticket.SlotNumber} {this.VehicleNumber}";
        }

    }
}