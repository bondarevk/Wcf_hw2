using System;
using System.Linq;
using System.ServiceModel;
using WcfClient.WcfService;

namespace WcfClient
{
    class Program
    {
        static void Main(string[] args)
        {
            PathServiceClient client = new PathServiceClient();

            try
            {
                client.GetPathInfo("C:/Games").ToList().ForEach(Console.WriteLine);
            }
            catch (FaultException<PathFault> exception)
            {
                Console.WriteLine("Error: " + exception.Detail.ExceptionMessage);
            }
            
            client.Close();
            Console.ReadKey();
        }
    }
}
