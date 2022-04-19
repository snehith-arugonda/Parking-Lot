namespace ParkingLotSystem
{
    class CustomerService
    {
        private static readonly CustomerService instance = new CustomerService();  
        private readonly ParkingService parkingServiceInstance = ParkingService.ParkingServiceInstance;
        public static CustomerService CustomerInstance 
        {  
            get {
                return instance;  
            }  
        }
        private CustomerService() {}  

        private Dictionary<VehicleType, List<IVehicle>> vehicles = new Dictionary<VehicleType, List<IVehicle>>();
        public void Initialize()
        {
            parkingServiceInstance.InitializeParkingLot();
            this.InitializeVehicles();
        }

        private void InitializeVehicles()
        {
            foreach (VehicleType item in Enum.GetValues(typeof(VehicleType)))
            {
                vehicles[item] = new List<IVehicle>();
            }
        }

        public void Customer()
        {
            Console.WriteLine("\nProvide your vehicle type ");
            int num = 1;
            foreach (VehicleType item in Enum.GetValues(typeof(VehicleType)))
            {
                Console.WriteLine($"{num++}. {item}");
            }

            if (!int.TryParse(Console.ReadLine(), out int type) || 0 > type || type > Enum.GetValues(typeof(VehicleType)).Length)
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
                        bool slotAvailable = parkingServiceInstance.CheckForSlot(VehicleType.TwoWheeler);
                        if (slotAvailable)
                        {
                            TwoWheeler TwoWheeler = new TwoWheeler();
                            NewVehicle(TwoWheeler);
                        }
                        break;
                    case 2:
                        slotAvailable = parkingServiceInstance.CheckForSlot(VehicleType.FourWheeler);
                        if (slotAvailable)
                        {
                            FourWheeler fourWheeler = new FourWheeler();
                            NewVehicle(fourWheeler);
                        }
                        break;
                    case 3:
                        slotAvailable = parkingServiceInstance.CheckForSlot(VehicleType.HeavyVehicle);
                        if (slotAvailable)
                        {
                            HeavyVehicle HeavyVehicle = new HeavyVehicle();
                            NewVehicle(HeavyVehicle);
                        }
                        break;
                }
            }
            else if (option == 2)
            {
                switch (type)
                {
                    case 1:
                        this.UnPark(VehicleType.TwoWheeler);
                        break;
                    case 2:
                        this.UnPark(VehicleType.FourWheeler);
                        break;
                    case 3:
                        this.UnPark(VehicleType.HeavyVehicle);
                        break;
                }
            }

        }

        private void NewVehicle(IVehicle vehicle)
        {
            vehicles[vehicle.VehicleType].Add(vehicle);
            Console.WriteLine("Enter the vehicle number");
            vehicle.VehicleNumber = Console.ReadLine()!;
            parkingServiceInstance.InVehicle(vehicle);
        }

        private void UnPark(VehicleType type)
        {
            bool there = false;
            foreach (IVehicle vehicle in vehicles[type])
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
                foreach (IVehicle vehicle in vehicles[type])
                {
                    if (vehicle.Ticket.SlotNumber == slot)
                    {
                        parkingServiceInstance.OutVehicle(vehicle.Ticket, type);
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