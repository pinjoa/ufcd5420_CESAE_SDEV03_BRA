using System;
using System.Collections.Generic;

namespace V03
{ 
    /// <summary>
    /// Order class with a constructor and some read-only attributes
    /// </summary>
    public class Order
    {
        public int OrderId { get; }
        public string CustomerName { get; }
        public List<string> Items { get; }
        public OrderStatus Status { get; set; }
        public Order(int orderId, string customerName, List<string> items)
        {
            OrderId = orderId;
            CustomerName = customerName;
            Items = items;
            Status = OrderStatus.Pending;
        }
    }

    public enum OrderStatus
    {
        Pending,
        Preparing,
        Served
    }

    /// <summary>
    /// OrderManager class, protecting list object
    /// </summary>
    public class OrderManager
    {
        private readonly List<Order> _orders;

        public OrderManager()
        {
            _orders = new List<Order>();
        }

        public void PlaceOrder(string customerName, List<string> items)
        {
            Order newOrder = new Order(_orders.Count + 1, customerName, items);
            _orders.Add(newOrder);
            Console.WriteLine($"Order {newOrder.OrderId} placed for {customerName}");
        }

        public void UpdateOrderStatus(int orderId, OrderStatus status)
        {
            bool notFound = true;
            foreach (Order order in _orders)
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

        public void DisplayOrderDetails(int orderId)
        {
            bool notFound = true;
            foreach (Order order in _orders)
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
