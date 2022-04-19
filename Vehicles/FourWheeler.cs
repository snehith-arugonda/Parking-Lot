namespace ParkingLotSystem
{
    class  FourWheeler:IVehicle
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
        public VehicleType VehicleType
        {
            get
            {
                return VehicleType.FourWheeler;
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