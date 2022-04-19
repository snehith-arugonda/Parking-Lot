namespace ParkingLotSystem
{
    class  HeavyVehicle:IVehicle
    {
        private string _vechicleNumber = "";
        private ParkingTicket _ticket = new ParkingTicket();
        public string VehicleNumber
        {
            get
            {
                return _vechicleNumber;
            }
            set
            {
                _vechicleNumber = value;
            }
        }
        public VehicleTypes VehicleType
        {
            get
            {
                return VehicleTypes.HeavyVehicle;
            }
        }

        public ParkingTicket Ticket
        {
            get
            {
                return _ticket;
            }
            set
            {
                _ticket = value;
            }
        }

        public override string ToString()
        {
            return $"{this.Ticket.SlotNumber} {this.VehicleNumber}";
        }

    }
}