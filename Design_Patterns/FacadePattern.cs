using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns
{
    // performing a complex task dividing into small small sub systems
    public class FacadePattern
    {
        private readonly OrderManagement _orderManagement;
        public FacadePattern(OrderManagement orderManagement)
        {
            _orderManagement = orderManagement;
        }

        public string CheckOrderManagement()
        {
            return _orderManagement.ProcessOrder();
        }


    }

    public class OrderManagement
    {
        public string ProcessOrder()
        {
            string response = string.Empty;

            Order order = new Order();
            response = $"{response} \n {order.CreateOrder()}";

            Payment payment = new Payment();
            response = $"{response} \n {payment.MakePayment()}";

            Invoice invoice = new Invoice();
            response = $"{response} \n {invoice.Sendinvoice()}";

            return response;
        }
    }

    public class Order
    {
        public string CreateOrder()
        {
            return "Creating the order";
        }
    }

    public class Payment
    {
        public string MakePayment()
        {
            return "Creating the payment";
        }
    }

    public class Invoice
    {
        public string Sendinvoice()
        {
            return "Sending the invoice";
        }
    }

}
