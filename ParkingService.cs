namespace ParkingLotSystem
{
    class ParkingService
    {

        public static bool CheckForSlot(VehicleTypes type)
        {
            bool slotNumber = ParkingLot.SlotCheck(type, 0);
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

        public static void InVehicle(Ivehicle vehicle)
        {
            int slotNumber = ParkingLot.SlotCheck(vehicle.VehicleType);
            vehicle.Ticket = new ParkingTicket(slotNumber, vehicle.VehicleNumber);
            Console.WriteLine(" \n please collect your ticket");
            Console.WriteLine(vehicle.Ticket.ToString());
        }

        public static void OutVehicle(ParkingTicket ticket, VehicleTypes type)
        {
            ParkingTicket.Dispose(ticket);
            ParkingLot.FreeTheSlot(ticket.SlotNumber, type);
        }

    }
}