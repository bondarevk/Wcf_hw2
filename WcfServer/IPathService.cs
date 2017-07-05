using System;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace WcfServer
{
    [ServiceContract]
    public interface IPathService
    {
        [OperationContract]
        [FaultContract(typeof(PathFault))]
        string[] GetPathInfo(string path);
    }

    [DataContract]
    public class PathFault
    {
        [DataMember]
        public readonly string ExceptionMessage;

        public PathFault(string message)
        {
            ExceptionMessage = message;
        }
    }
}
