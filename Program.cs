namespace ParkingLotSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ParkingLot.CreateParkingLot();
            CustomerService.VehiclesTypes();
            while(true)
            {
                CustomerService.Customer();
            }
        }
    }
}