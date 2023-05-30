<?php

class Order {
    public $orderId;
    public $customerName;
    public $items;
    public $status;

    public function __construct($orderId, $customerName, $items, $status) {
        $this->orderId = $orderId;
        $this->customerName = $customerName;
        $this->items = $items;
        $this->status = $status;
    }
}

class OrderStatus {
    const Pending = 0;
    const Preparing = 1;
    const Served = 2;
}

class OrderManager {
    private $orders;

    public function __construct() {
        $this->orders = array();
    }

    public function placeOrder($customerName, $items) {
        $newOrder = new Order(count($this->orders) + 1, $customerName, $items, OrderStatus::Pending);
        $this->orders[] = $newOrder;
        echo "Order {$newOrder->orderId} placed for {$newOrder->customerName}\n";
    }

    public function updateOrderStatus($orderId, $status) {
        $order = $this->findOrderById($orderId);
        if ($order != null) {
            $order->status = $status;
            echo "Order {$order->orderId} status updated to $status\n";
        } else {
            echo "Order $orderId not found\n";
        }
    }

    public function displayOrderDetails($orderId) {
        $order = $this->findOrderById($orderId);
        if ($order != null) {
            echo "Order ID: {$order->orderId}\n";
            echo "Customer Name: {$order->customerName}\n";
            echo "Items:\n";
            foreach ($order->items as $item) {
                echo $item . "\n";
            }
            echo "Status: {$order->status}\n";
        } else {
            echo "Order $orderId not found\n";
        }
    }

    private function findOrderById($orderId) {
        foreach ($this->orders as $order) {
            if ($order->orderId == $orderId) {
                return $order;
            }
        }
        return null;
    }
}

$orderManager = new OrderManager();

// Place an order
$orderManager->placeOrder("John Doe", array("Burger", "Fries", "Coke"));

// Place another order
$orderManager->placeOrder("Jane Smith", array("Pizza", "Salad", "Water"));

// Update order status
$orderManager->updateOrderStatus(1, OrderStatus::Preparing);

// Display order details
$orderManager->displayOrderDetails(1);
$orderManager->displayOrderDetails(2);
?>
