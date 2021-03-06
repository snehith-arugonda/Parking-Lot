namespace ParkingLotSystem
{
    class ParkingService
    {

        private ParkingService() {}  
        private static readonly ParkingService instance = new ParkingService();
        public static ParkingService ParkingServiceInstance 
        {  
            get {
                return instance;  
            }  
        }
        private static readonly ParkingLot parkingLotInstance = ParkingLot.ParkingLotInstance;

        public void InitializeParkingLot()
        {
            parkingLotInstance.CreateParkingLot();
        }

        public bool CheckForSlot(VehicleTypes type)
        {
            bool slotNumber = parkingLotInstance.SlotCheck(type, 0);
            if(slotNumber)
            {
                Console.WriteLine("\n Slot is available \n");
                return true;
            }
            else
            {
                Console.WriteLine("\n Sorry...  No Slot available \n ");
            }
            return false;
        }

        public void InVehicle(IVehicle vehicle)
        {
            int slotNumber = parkingLotInstance.SlotCheck(vehicle.VehicleType);
            vehicle.Ticket = new ParkingTicket(slotNumber, vehicle.VehicleNumber);
            Console.WriteLine(" \n please collect your ticket");
            Console.WriteLine(vehicle.Ticket.ToString());
        }

        public void OutVehicle(ParkingTicket ticket, VehicleTypes type)
        {
            ParkingTicket.Dispose(ticket);
            parkingLotInstance.FreeTheSlot(ticket.SlotNumber, type);
        }

    }
}