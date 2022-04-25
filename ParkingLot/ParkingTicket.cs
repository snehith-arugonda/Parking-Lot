namespace ParkingLotSystem
{
    class ParkingTicket
    {
        private string _vehicleNumber = " ";
        private int _slotNumber;
        private DateTime _inTime;
        private DateTime? _outTime = null;
        
        public int SlotNumber
        {
            get
            {
                return _slotNumber;
            }
        }
        public DateTime? OutTime
        {
            get
            {
                return _outTime;
            }
            set
            {
                _outTime = value;
            }
        }
        public ParkingTicket()
        {
            _slotNumber = 0;
            _vehicleNumber = "vehicleNumber";
            _inTime = DateTime.Now;
        }
        public ParkingTicket(int slot, string vehicleNumber)
        {
            _slotNumber = slot;
            _vehicleNumber = vehicleNumber;
            _inTime = DateTime.Now;
        }
        public static void Dispose(ParkingTicket? ticket)
        {
            ticket = null;
        }   
        public override string ToString()
        {
            return $"\nVehicle Number : {_vehicleNumber}\nSlot Number : {_slotNumber}\nIn Time : {_inTime}\nOut Time : {_outTime}";
        }
    }
}