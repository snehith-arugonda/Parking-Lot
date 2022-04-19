namespace ParkingLotSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CustomerService customerInstance = CustomerService.CustomerInstance;
            customerInstance.Initialize();
            while(true)
            {
                customerInstance.Customer();
            }
        }
    }
}