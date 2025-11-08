/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: Create queue with invalid size (0) - should default to 10
        // Expected Result: maxSize should be 10
        Console.WriteLine("Test 1");
        var cs1 = new CustomerService(0);
        Console.WriteLine(cs1);
        Console.WriteLine("Expected: max_size=10");
        // Defect(s) Found: None expected

        Console.WriteLine("=================");

        // Test 2
        // Scenario: Create queue with invalid size (-5) - should default to 10
        // Expected Result: maxSize should be 10
        Console.WriteLine("Test 2");
        var cs2 = new CustomerService(-5);
        Console.WriteLine(cs2);
        Console.WriteLine("Expected: max_size=10");
        // Defect(s) Found: None expected

        Console.WriteLine("=================");

        // Test 3
        // Scenario: Serve customer from empty queue
        // Expected Result: Error message should be displayed
        Console.WriteLine("Test 3");
        var cs3 = new CustomerService(5);
        cs3.ServeCustomer();
        Console.WriteLine("Expected: Error message about empty queue");
        // Defect(s) Found: No empty queue check - will crash with ArgumentOutOfRangeException

        Console.WriteLine("=================");

        // Test 4
        // Scenario: Add customers and serve them in FIFO order
        // Expected Result: First customer added should be first served
        Console.WriteLine("Test 4");
        var cs4 = new CustomerService(3);
        cs4.AddNewCustomer("Alice", "A001", "Login issue");
        cs4.AddNewCustomer("Bob", "B002", "Payment problem");
        Console.WriteLine(cs4);
        Console.WriteLine("Serving first customer (should be Alice):");
        cs4.ServeCustomer();
        Console.WriteLine(cs4);
        Console.WriteLine("Expected: Alice should have been served, Bob should remain");
        // Defect(s) Found: Wrong order - RemoveAt(0) before accessing [0], serves Bob instead of Alice

        Console.WriteLine("=================");

        // Test 5
        // Scenario: Fill queue to max capacity and try to add one more
        // Expected Result: Error message when queue is full
        Console.WriteLine("Test 5");
        var cs5 = new CustomerService(2);
        cs5.AddNewCustomer("Customer1", "C001", "Problem1");
        cs5.AddNewCustomer("Customer2", "C002", "Problem2");
        Console.WriteLine(cs5);
        Console.WriteLine("Trying to add 3rd customer to queue with max_size=2:");
        cs5.AddNewCustomer("Customer3", "C003", "Problem3");
        Console.WriteLine(cs5);
        Console.WriteLine("Expected: Error message, only 2 customers in queue");
        // Defect(s) Found: Uses > instead of >= so allows maxSize+1 customers (3 instead of 2)

        Console.WriteLine("=================");
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Add a new customer to the queue (for testing purposes)
    /// </summary>
    public void AddNewCustomer(string name, string accountId, string problem) {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    public void ServeCustomer() {
        if (_queue.Count == 0) {
            Console.WriteLine("The queue is empty.");
            return;
        }

        var customer = _queue[0];
        _queue.RemoveAt(0);
        Console.WriteLine(customer);
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}