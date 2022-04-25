namespace ParkingLotSystem
{
    class ParkingLot
    {
        private static readonly ParkingLot instance = new ParkingLot();  
        public static ParkingLot ParkingLotInstance 
        {  
            get {
                return instance;  
            }  
        }
        private ParkingLot() {}  

        private Dictionary<VehicleType, List<bool>> parkingSlots = new Dictionary<VehicleType, List<bool>>();
        // private Dictionary<VehicleType, List<IVehicle?>> parkingVrhicles = new Dictionary<VehicleType, List<IVehicle?>>();
        
        public void CreateParkingLot()
        {
            Random random = new Random();
            
            foreach (VehicleType item in Enum.GetValues(typeof(VehicleType)))
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

        public string GetParkingLot()
        {
            string lot = "\n";
            foreach (VehicleType item in Enum.GetValues(typeof(VehicleType)))
            {
                lot += item.ToString() + "  ";
                int count = 0;
                for (int i = 1; i < parkingSlots[item].Count ; i++)
                {
                    if(!parkingSlots[item][i]){
                        count++;
                    }
                }
                lot += $"{count.ToString()}(Free)/{parkingSlots[item].Count-1}(Total)";
                lot += "\n";
            }
            return lot;
        }

        public bool SlotCheck(VehicleType type)
        {
            return parkingSlots[type].Contains(false);
        }

        public int AssignSlot(VehicleType type)
        {
            int index = parkingSlots[type].IndexOf(false);
            parkingSlots[type][index] = true;
            return index;
        }

        public void FreeTheSlot(int slot, VehicleType type)
        {
            parkingSlots[type][slot] = false;
        }

    }
}