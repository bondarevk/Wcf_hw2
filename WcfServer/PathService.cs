using System;
using System.IO;
using System.Linq;
using System.ServiceModel;

namespace WcfServer
{
    public class PathService : IPathService
    {
        public string[] GetPathInfo(string path)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                return dir.GetDirectories().Select(d => d.Name).Concat(dir.GetFiles().Select(f => f.Name)).ToArray();
            }
            catch (Exception ex)
            {
                throw new FaultException<PathFault>(new PathFault(ex.Message));
            }
        }
    }
}
