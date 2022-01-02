using System;
using System.Collections.Generic;
using System.Linq;

namespace Design_Patterns.SOLID
{

    //High-level modules should not depend on low-level modules, both should depend on abstractions.
    //Abstractions should not depend on details.Details should depend on abstractions. 
    //Here the IServerFilterable has inversed the control and made the system loosely coupled.

    public enum ServerType
    {
        Dev, QA, UAT
    }

    public class Server
    {
        public string Name { get; set; }
        public ServerType ServerType { get; set; }
    }

    public interface IServerFilterable
    {
        IEnumerable<Server> GetServerByType(ServerType serverType);
    }

    public class ServerManager : IServerFilterable
    {
        private List<Server> _servers = new List<Server> { new Server { Name = "Development", ServerType = ServerType.Dev } };

        public void AddServer(Server server)
        {
            _servers.Add(server);
        }

        public IEnumerable<Server> GetServerByType(ServerType serverType)
        {
            return _servers.Where(s => s.ServerType == serverType);
        }
    }
    public class DependencyInversion
    {

        private readonly IServerFilterable _server;
        public DependencyInversion(IServerFilterable server)
        {
            _server = server;
        }
        public int DevServerCount()
        {
            return _server.GetServerByType(ServerType.Dev).Count();
        }

    }

}
