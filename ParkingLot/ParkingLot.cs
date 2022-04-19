namespace ParkingLotSystem
{
    class ParkingLot
    {
        private ParkingLot() {}  
        private static readonly ParkingLot instance = new ParkingLot();  
        public static ParkingLot ParkingLotInstance 
        {  
            get {
                return instance;  
            }  
        }

        private Dictionary<VehicleTypes, List<bool>> parkingSlots = new Dictionary<VehicleTypes, List<bool>>();
        
        public void CreateParkingLot()
        {
            Random random = new Random();
            foreach (VehicleTypes item in Enum.GetValues(typeof(VehicleTypes)))
            {
                int slots = random.Next(4, 7);
                parkingSlots[item] = new List<bool>();
                for (int i = 0; i <= slots; i++)
                {
                    parkingSlots[item].Add(false);
                }
                parkingSlots[item][0]=true;
            }
        }

        public bool SlotCheck(VehicleTypes type)
        {
            return parkingSlots[type].Contains(false);
        }

        public int AssignSlot(VehicleTypes type)
        {
            int index = parkingSlots[type].IndexOf(false);
            parkingSlots[type][index] = true;
            return index;
        }

        public void FreeTheSlot(int slot, VehicleTypes type)
        {
            parkingSlots[type][slot] = false;
        }

    }
}