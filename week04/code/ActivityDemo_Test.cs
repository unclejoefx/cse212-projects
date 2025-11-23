using Microsoft.VisualStudio.TestTools.UnitTesting;

/// <summary>
/// This test demonstrates the doubly-linked list activity:
/// Begin with a list containing A B C D, then:
/// 1. Insert X at the head
/// 2. Insert Y between B and C
/// 3. Remove D (the tail)
/// 4. Remove B
/// </summary>
[TestClass]
public class ActivityDemoTest
{
    [TestMethod]
    public void RunActivityDemo()
    {
        Console.WriteLine("\n" + new string('=', 60));
        Console.WriteLine("Doubly-Linked List Activity Demo");
        Console.WriteLine(new string('=', 60));

        // Step 1: Begin with a list containing A B C D
        // Using integers: A=1, B=2, C=3, D=4
        var list = new LinkedList();
        list.InsertTail(1); // A
        list.InsertTail(2); // B
        list.InsertTail(3); // C
        list.InsertTail(4); // D

        Console.WriteLine("\nInitial List (A=1, B=2, C=3, D=4):");
        Console.WriteLine($"  {list}");
        Console.WriteLine("  Visual: [1(A)] ↔ [2(B)] ↔ [3(C)] ↔ [4(D)]");

        // Verify initial state
        Assert.AreEqual("<LinkedList>{1, 2, 3, 4}", list.ToString());

        // Step 2: Insert X at the head (X=10)
        Console.WriteLine("\n" + new string('-', 60));
        Console.WriteLine("Operation 1: Insert X at the head (X=10)");
        list.InsertHead(10);
        Console.WriteLine($"  {list}");
        Console.WriteLine("  Visual: [10(X)] ↔ [1(A)] ↔ [2(B)] ↔ [3(C)] ↔ [4(D)]");

        Assert.AreEqual("<LinkedList>{10, 1, 2, 3, 4}", list.ToString());

        // Step 3: Insert Y between B and C (Y=20)
        Console.WriteLine("\n" + new string('-', 60));
        Console.WriteLine("Operation 2: Insert Y between B and C (Y=20)");
        list.InsertAfter(2, 20); // Insert 20(Y) after 2(B)
        Console.WriteLine($"  {list}");
        Console.WriteLine("  Visual: [10(X)] ↔ [1(A)] ↔ [2(B)] ↔ [20(Y)] ↔ [3(C)] ↔ [4(D)]");

        Assert.AreEqual("<LinkedList>{10, 1, 2, 20, 3, 4}", list.ToString());

        // Step 4: Remove D (the tail)
        Console.WriteLine("\n" + new string('-', 60));
        Console.WriteLine("Operation 3: Remove D (the tail, value=4)");
        list.RemoveTail();
        Console.WriteLine($"  {list}");
        Console.WriteLine("  Visual: [10(X)] ↔ [1(A)] ↔ [2(B)] ↔ [20(Y)] ↔ [3(C)]");

        Assert.AreEqual("<LinkedList>{10, 1, 2, 20, 3}", list.ToString());

        // Step 5: Remove B
        Console.WriteLine("\n" + new string('-', 60));
        Console.WriteLine("Operation 4: Remove B (value=2)");
        list.Remove(2);
        Console.WriteLine($"  {list}");
        Console.WriteLine("  Visual: [10(X)] ↔ [1(A)] ↔ [20(Y)] ↔ [3(C)]");

        Assert.AreEqual("<LinkedList>{10, 1, 20, 3}", list.ToString());

        Console.WriteLine("\n" + new string('=', 60));
        Console.WriteLine("Final List: {10(X), 1(A), 20(Y), 3(C)}");
        Console.WriteLine("Activity Complete!");
        Console.WriteLine(new string('=', 60) + "\n");
    }
}
