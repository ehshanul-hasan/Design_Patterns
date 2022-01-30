using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns
{

    // Adapter pattern works as a bridge between two incompatible interfaces.
    // Here adapter class was instantiated directly istead of DI to keep the things visible here. 
    public class AdapterPattern
    {
        public string CheckActiveSocket()
        {
            TwoPinSocket twoPinSocket = new SocketAdapter();
            return twoPinSocket.GetPinCount();
        }

    }

    public class TwoPinSocket {
        public virtual string GetPinCount()
        {
            return "I have 2 pins"; 
        }
    }

    public class ThreePinSocket
    {
        public string GetPinCount()
        {
            return "I have 3 pins";
        }
    }

    public class SocketAdapter : TwoPinSocket
    {
        private ThreePinSocket adaptee = new ThreePinSocket();
        public override string GetPinCount()
        {
            return adaptee.GetPinCount();
        }
    }


}
