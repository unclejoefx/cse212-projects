using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items with different priorities and dequeue them
    // Expected Result: Items should be dequeued in order of priority (highest first): "High", "Medium", "Low"
    // Defect(s) Found: Loop boundary error - last item in queue is not checked due to condition (index < _queue.Count - 1).
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 3);
        priorityQueue.Enqueue("High", 5);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with the same priority and verify FIFO behavior
    // Expected Result: With same priority, first enqueued should be dequeued first: "First", "Second", "Third"
    // Defect(s) Found: Using >= instead of > causes LAST item with highest priority to be selected instead of FIRST (violates FIFO).
    // Also items are never removed from queue, and last item not checked.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 5);
        priorityQueue.Enqueue("Second", 5);
        priorityQueue.Enqueue("Third", 5);

        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to dequeue from an empty queue
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: None - Exception handling works correctly.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                string.Format("Unexpected exception of type {0} caught: {1}",
                              e.GetType(), e.Message)
            );
        }
    }

    [TestMethod]
    // Scenario: Enqueue items where the last item has the highest priority
    // Expected Result: The last item should be dequeued first: "LastButHighest"
    // Defect(s) Found: Loop boundary error - last item is never checked, so "Medium" is returned instead of "LastButHighest".
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 3);
        priorityQueue.Enqueue("LastButHighest", 10);

        Assert.AreEqual("LastButHighest", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Verify items are actually removed from the queue
    // Expected Result: After dequeuing once, next dequeue should get the next highest priority item
    // Defect(s) Found: Items are never removed from the queue - _queue.RemoveAt() is not called, so same item returned repeatedly.
    public void TestPriorityQueue_5()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 5);
        priorityQueue.Enqueue("Second", 3);
        priorityQueue.Enqueue("Third", 1);

        var first = priorityQueue.Dequeue();
        Assert.AreEqual("First", first);

        var second = priorityQueue.Dequeue();
        Assert.AreEqual("Second", second);

        var third = priorityQueue.Dequeue();
        Assert.AreEqual("Third", third);
    }

    [TestMethod]
    // Scenario: Complex scenario with mixed priorities and same priorities
    // Expected Result: Should dequeue in order: "A" (7), "B" (7), "C" (5), "D" (3), "E" (3)
    // Defect(s) Found: FIFO violation - >= causes "B" to be selected instead of "A" when both have priority 7.
    // Also items not removed and last item not checked.
    public void TestPriorityQueue_6()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("D", 3);
        priorityQueue.Enqueue("C", 5);
        priorityQueue.Enqueue("A", 7);
        priorityQueue.Enqueue("B", 7);
        priorityQueue.Enqueue("E", 3);

        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("D", priorityQueue.Dequeue());
        Assert.AreEqual("E", priorityQueue.Dequeue());
    }

    // Add more test cases as needed below.
}