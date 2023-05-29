using System;
using System.Collections.Generic;

namespace V01
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
            var newOrder = new Order
            {
                OrderId = orders.Count + 1,
                CustomerName = customerName,
                Items = items,
                Status = OrderStatus.Pending
            };

            orders.Add(newOrder);
            Console.WriteLine($"Order {newOrder.OrderId} placed for {customerName}");
        }

        public void UpdateOrderStatus(int orderId, OrderStatus status)
        {
            var order = orders.Find(o => o.OrderId == orderId);
            if (order != null)
            {
                order.Status = status;
                Console.WriteLine($"Order {order.OrderId} status updated to {status}");
            }
            else
            {
                Console.WriteLine($"Order {orderId} not found");
            }
        }

        public void DisplayOrderDetails(int orderId)
        {
            var order = orders.Find(o => o.OrderId == orderId);
            if (order != null)
            {
                Console.WriteLine($"Order ID: {order.OrderId}");
                Console.WriteLine($"Customer Name: {order.CustomerName}");
                Console.WriteLine("Items:");
                foreach (var item in order.Items)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine($"Status: {order.Status}");
            }
            else
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
