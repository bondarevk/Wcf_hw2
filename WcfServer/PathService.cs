using System;
using System.IO;
using System.Linq;
using System.ServiceModel;

namespace WcfServer
{
    public class PathService : IPathService
    {
        public void RequestPathInfo(string path)
        {
            IPathCallback callback = OperationContext.Current.GetCallbackChannel<IPathCallback>();
            try
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                string[] info = dir.GetDirectories().Select(d => d.Name).Concat(dir.GetFiles().Select(f => f.Name)).ToArray();
                callback.ReceivePathInfo(info);
            }
            catch (Exception ex)
            {
                callback.OnError("Ошибка получения содержимого папки.");
            }
        }
    }
}
