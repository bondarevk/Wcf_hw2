using System;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace WcfServer
{
    [ServiceContract(CallbackContract = typeof(IPathCallback))]
    public interface IPathService
    {
        [OperationContract(IsOneWay = true)]
        void RequestPathInfo(string path);
    }
    
    public interface IPathCallback
    {
        [OperationContract(IsOneWay = true)]
        void ReceivePathInfo(string[] info);

        [OperationContract(IsOneWay = true)]
        void OnError(string message);
    }
}
