namespace ParkingLotSystem
{
    class  FourWheeler:Ivehicle
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
                return VehicleTypes.fourWheeler;
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