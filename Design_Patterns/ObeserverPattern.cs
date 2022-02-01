using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns
{
    public class ObeserverPattern
    {
        public string GetStockUpdates()
        {
            IObservable stockExchange = new StockExchange();


            ISubscriber investorA = new InvestorA();
            stockExchange.AddSubscriber(investorA);

            ISubscriber investorB = new InvestorB();
            stockExchange.AddSubscriber(investorB);

            return stockExchange.ChangeStockPrice();
        }  
    }

    public interface ISubscriber
    {
        string GetNotified(IObservable subject);
    }

    public interface IObservable
    {
        void AddSubscriber(ISubscriber observer);

        void RemoveSubscriber(ISubscriber observer);

        string Notify();
        string ChangeStockPrice();
    }

    public class StockExchange : IObservable
    {

        private List<ISubscriber> _subscribers = new List<ISubscriber>();

        public void AddSubscriber(ISubscriber subscriber)
        {
            _subscribers.Add(subscriber);
        }

        public void RemoveSubscriber(ISubscriber subscriber)
        {
            _subscribers.Remove(subscriber);
        }

        public string Notify()
        {
            var response = string.Empty;
            foreach (var subscriber in _subscribers)
            {
                response = $"{response} {subscriber.GetNotified(this)} .";
            }
            return response;
        }

        public string ChangeStockPrice()
        {
            // business processing and then notify.
            return Notify();
        }

    }


    class InvestorA : ISubscriber
    {
        public string GetNotified(IObservable stockExchange)
        {
            // check condition based on subjecvt state

            return $"Investor A notified";
        }
    }

    class InvestorB : ISubscriber
    {
        public string GetNotified(IObservable stockExchange)
        {
            // check condition based on subjecvt state

            return $"Investor B notified";
        }
    }
}
