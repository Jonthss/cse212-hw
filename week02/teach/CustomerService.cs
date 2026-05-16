/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        var cs = new CustomerService(3);
        cs._queue.Add(new Customer("Alice", "A100", "Password reset"));

        // Test Cases

        // Test 1
        // Scenario: Serve one customer from the queue.
        // Expected Result: The first customer is displayed and removed from the queue.
        Console.WriteLine("Test 1");
        cs.ServeCustomer();

        // Defect(s) Found: 

        Console.WriteLine("=================");

        // Test 2
        // Scenario: Dequeue from an empty queue.
        // Expected Result: A message indicating no customers are in the queue.
        Console.WriteLine("Test 2");

        if (cs._queue.Count <= 0) {
            Console.WriteLine("No Customers in the queue");
        }

        // Defect(s) Found: 

        Console.WriteLine("=================");

        // Test 3
        // Scenario: Fill the queue to maximum capacity.
        // Expected Result: The queue reports it is full.
        Console.WriteLine("Test 3");
        cs._queue.Clear();
        for (int i = 0; i < cs._maxSize; i++) {
            cs._queue.Add(new Customer($"Customer{i + 1}", $"ID{i + 1:000}", "Sample problem"));
        }

        if (cs._queue.Count >= cs._maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
        }

        // Defect(s) Found:

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
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {

        
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