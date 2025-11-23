public class ActivityDemo
{
    public static void RunActivity()
    {
        Console.WriteLine("Doubly-Linked List Activity Demo");
        Console.WriteLine("=================================\n");

        // Step 1: Begin with a list containing A B C D
        var list = new LinkedList();
        // Note: Using integers to represent letters (65=A, 66=B, 67=C, 68=D)
        // For simplicity, let's use simple values: A=1, B=2, C=3, D=4
        list.InsertTail(1); // A
        list.InsertTail(2); // B
        list.InsertTail(3); // C
        list.InsertTail(4); // D

        Console.WriteLine("Initial List (A=1, B=2, C=3, D=4):");
        Console.WriteLine(list);
        Console.WriteLine("Visual: [1(A)] ↔ [2(B)] ↔ [3(C)] ↔ [4(D)]\n");

        // Step 2: Insert X at the head (X=10)
        Console.WriteLine("Operation 1: Insert X at the head (X=10)");
        list.InsertHead(10);
        Console.WriteLine(list);
        Console.WriteLine("Visual: [10(X)] ↔ [1(A)] ↔ [2(B)] ↔ [3(C)] ↔ [4(D)]\n");

        // Step 3: Insert Y between B and C (Y=20)
        Console.WriteLine("Operation 2: Insert Y between B and C (Y=20)");
        list.InsertAfter(2, 20); // Insert 20(Y) after 2(B)
        Console.WriteLine(list);
        Console.WriteLine("Visual: [10(X)] ↔ [1(A)] ↔ [2(B)] ↔ [20(Y)] ↔ [3(C)] ↔ [4(D)]\n");

        // Step 4: Remove D (the tail)
        Console.WriteLine("Operation 3: Remove D (the tail)");
        list.RemoveTail();
        Console.WriteLine(list);
        Console.WriteLine("Visual: [10(X)] ↔ [1(A)] ↔ [2(B)] ↔ [20(Y)] ↔ [3(C)]\n");

        // Step 5: Remove B
        Console.WriteLine("Operation 4: Remove B (value 2)");
        list.Remove(2);
        Console.WriteLine(list);
        Console.WriteLine("Visual: [10(X)] ↔ [1(A)] ↔ [20(Y)] ↔ [3(C)]\n");

        Console.WriteLine("Final List:");
        Console.WriteLine(list);
        Console.WriteLine("\nActivity Complete!");
    }
}
