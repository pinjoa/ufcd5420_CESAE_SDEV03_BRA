using System;
using System.Collections.Generic;

namespace V02
{ 
    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public List<string> Items { get; set; }
        public OrderStatus Status { get; set; }
    }

    public enum OrderStatus
    {
        Pending,
        Preparing,
        Served
    }

    public class OrderManager
    {
        private List<Order> orders;

        public OrderManager()
        {
            orders = new List<Order>();
        }

        public void PlaceOrder(string customerName, List<string> items)
        {
            Order newOrder = new Order
            {
                OrderId = orders.Count + 1,
                CustomerName = customerName,
                Items = items,
                Status = OrderStatus.Pending
            };

            orders.Add(newOrder);
            Console.WriteLine($"Order {newOrder.OrderId} placed for {customerName}");
        }


        // version 1, using a flag to control the flow and output
        public void UpdateOrderStatus(int orderId, OrderStatus status)
        {
            bool notFound = true;
            foreach (Order order in orders)
            {
                if (order.OrderId == orderId)
                {
                    order.Status = status;
                    Console.WriteLine($"Order {order.OrderId} status updated to {status}");
                    notFound = false;
                    break;
                }
            }
            if (notFound)
            {
                Console.WriteLine($"Order {orderId} not found");
            }
        }

        /*
        // version 2, return inside foreach block
        // this approach in implementation can be very dangerous, but it is one of the possible solutions
        public void UpdateOrderStatus(int orderId, OrderStatus status)
        {
            foreach (Order order in orders)
            {
                if (order.OrderId == orderId)
                {
                    order.Status = status;
                    Console.WriteLine($"Order {order.OrderId} status updated to {status}");
                    return;
                }
            }
            Console.WriteLine($"Order {orderId} not found");
        }*/
        
        public void DisplayOrderDetails(int orderId)
        {
            bool notFound = true;
            foreach (Order order in orders)
            {
                if (order.OrderId == orderId)
                {
                    Console.WriteLine($"Order ID: {order.OrderId}");
                    Console.WriteLine($"Customer Name: {order.CustomerName}");
                    Console.WriteLine("Items:");
                    foreach (var item in order.Items)
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine($"Status: {order.Status}");
                    notFound = false;
                    break;
                }
            }
            if (notFound)
            {
                Console.WriteLine($"Order {orderId} not found");
            }
        }
    }

    public class Program
    {
        public static void Main()
        {
            var orderManager = new OrderManager();

            // Place an order
            orderManager.PlaceOrder("John Doe", new List<string> { "Burger", "Fries", "Coke" });

            // Place another order
            orderManager.PlaceOrder("Jane Smith", new List<string> { "Pizza", "Salad", "Water" });

            // Update order status
            orderManager.UpdateOrderStatus(1, OrderStatus.Preparing);

            // Display order details
            orderManager.DisplayOrderDetails(1);
            orderManager.DisplayOrderDetails(2);
        }
    }

}
