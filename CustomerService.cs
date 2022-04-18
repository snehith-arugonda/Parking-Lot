namespace ParkingLotSystem
{
    class CustomerService
    {
        private static Dictionary<VehicleTypes, List<Ivehicle>> vehicles = new Dictionary<VehicleTypes, List<Ivehicle>>();
        public static void VehiclesTypes()
        {
            foreach (VehicleTypes item in Enum.GetValues(typeof(VehicleTypes)))
            {
                vehicles[item] = new List<Ivehicle>();
            }
        }

        public static void Customer()
        {
            Console.WriteLine("\nProvide your vehicle type ");
            int num = 1;
            foreach (VehicleTypes item in Enum.GetValues(typeof(VehicleTypes)))
            {
                Console.WriteLine($"{num++}. {item}");
            }

            if (!int.TryParse(Console.ReadLine(), out int type) || 0 > type || type > Enum.GetValues(typeof(VehicleTypes)).Length)
            {
                try
                {
                    throw new FormatException();
                }
                catch (FormatException e)
                {
                    Console.WriteLine("\nInvalid Input \n" + e.Message);
                    return;
                }
            }
            Console.WriteLine("\n1. Parking \n2.Leaving \n");
            if (!int.TryParse(Console.ReadLine(), out int option) || 0 > option || option > 2)
            {
                try
                {
                    throw new FormatException();
                }
                catch (FormatException e)
                {
                    Console.WriteLine("\n\nInvalid Input \n" + e.Message);
                    return;
                }
            }
            if (option == 1)
            {
                switch (type)
                {
                    case 1:
                        bool slotAvailable = ParkingService.CheckForSlot(VehicleTypes.twoWheeler);
                        if (slotAvailable)
                        {
                            TwoWheeler twoWheeler = new TwoWheeler();
                            NewVehicle(twoWheeler);
                        }
                        break;
                    case 2:
                        slotAvailable = ParkingService.CheckForSlot(VehicleTypes.fourWheeler);
                        if (slotAvailable)
                        {
                            FourWheeler fourWheeler = new FourWheeler();
                            NewVehicle(fourWheeler);
                        }
                        break;
                    case 3:
                        slotAvailable = ParkingService.CheckForSlot(VehicleTypes.heavyVehicle);
                        if (slotAvailable)
                        {
                            HeavyVehicle heavyVehicle = new HeavyVehicle();
                            NewVehicle(heavyVehicle);
                        }
                        break;
                }
            }
            else if (option == 2)
            {
                switch (type)
                {
                    case 1:
                        CustomerService.UnPark(VehicleTypes.twoWheeler);
                        break;
                    case 2:
                        CustomerService.UnPark(VehicleTypes.fourWheeler);
                        break;
                    case 3:
                        CustomerService.UnPark(VehicleTypes.heavyVehicle);
                        break;
                }
            }

        }

        private static void NewVehicle(Ivehicle vehicle)
        {
            vehicles[vehicle.VehicleType].Add(vehicle);
            Console.WriteLine("Enter the vehicle number");
            vehicle.VehicleNumber = Console.ReadLine()!;
            ParkingService.InVehicle(vehicle);
        }

        private static void UnPark(VehicleTypes type)
        {
            bool there = false;
            foreach (Ivehicle vehicle in vehicles[type])
            {
                Console.WriteLine(vehicle.ToString());
                there = true;
            }
            
            if (there)
            {
                Console.WriteLine("select the vehicle to un park");
                if (!int.TryParse(Console.ReadLine(), out int slot))
                {
                    try
                    {
                        throw new FormatException();
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("\n Invalid Input \n" + e.Message);
                        return;
                    }
                }
                bool selectSlot = false;
                foreach (Ivehicle vehicle in vehicles[type])
                {
                    if (vehicle.Ticket.SlotNumber == slot)
                    {
                        ParkingService.OutVehicle(vehicle.Ticket, type);
                        vehicles[type].Remove(vehicle);
                        selectSlot = true;
                        break;
                    }
                }
                if(!selectSlot)
                {
                    Console.WriteLine("No vehicle in selected slot");
                }
            }
            else
            {
                Console.WriteLine("No vehicles parked of this type");
            }
        }
    }
}