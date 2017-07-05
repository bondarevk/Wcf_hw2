using System;
using System.Linq;
using System.ServiceModel;
using WcfClient.WcfService;

namespace WcfClient
{
    public class PathCallbackHandler : IPathServiceCallback
    {
        public void ReceivePathInfo(string[] info)
        {
            Console.WriteLine("Содержимое папки: ");
            info.ToList().ForEach(Console.WriteLine);
        }

        public void OnError(string message)
        {
            Console.WriteLine(message);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            PathServiceClient client = new PathServiceClient(new InstanceContext(new PathCallbackHandler()));
            client.RequestPathInfo("C:/Games");

            Console.WriteLine("Я не блокируюсь!");
            Console.ReadKey();
        }
    }
}
