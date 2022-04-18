namespace ParkingLotSystem
{
    class ParkingLot
    {
        private static Dictionary<VehicleTypes, List<bool>> parkingSlots = new Dictionary<VehicleTypes, List<bool>>();
        
        public static void CreateParkingLot()
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

        public static string GetParkingLot()
        {
            string lot = "\n";
            foreach (VehicleTypes item in Enum.GetValues(typeof(VehicleTypes)))
            {
                lot += item.ToString() + " ";
                for (int i = 1; i < parkingSlots[item].Count ; i++)
                {
                    lot += parkingSlots[item][i].ToString() +" ";
                }
                lot += "\n";
            }
            return lot;
        }

        public static bool SlotCheck(VehicleTypes type, int i)
        {
            return ParkingLot.parkingSlots[type].Contains(false);
        }

        public static int SlotCheck(VehicleTypes type)
        {
            int index = ParkingLot.parkingSlots[type].IndexOf(false);
            ParkingLot.parkingSlots[type][index] = true;
            return index;
        }

        public static void FreeTheSlot(int slot, VehicleTypes type)
        {
            ParkingLot.parkingSlots[type][slot] = false;
        }

    }
}