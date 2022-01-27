using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns
{
    // Will ensure only one object is created for the specified class

    public class SingletonChecker
    {
        public string GetIP()
        {
            return LoadBalancer.Instance.GetServer().IP;
        }
    }
    public class Server
    {
        public string Name { get; set; }
        public string IP { get; set; }
    }

    public interface ILoadBalancer
    {
        Server GetServer();
    }
    public class LoadBalancer : ILoadBalancer
    {
        private List<Server> Servers;
        private readonly Random random = new Random();

        private LoadBalancer()
        {
            Servers = new List<Server>()
            {
                new Server{ Name = "Server-01", IP = "11.11.11.11" },
                new Server{ Name = "Server-02", IP = "22.22.22.22" },
            };
        }
        public Server GetServer()
        {
            int r = random.Next(Servers.Count);
            return Servers[r];
        }

        private static Lazy<LoadBalancer> instance = new Lazy<LoadBalancer>(() =>
        {
            return new LoadBalancer();
        });

        public static ILoadBalancer Instance => instance.Value;
    }

   
}
