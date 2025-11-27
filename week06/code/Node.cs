public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else if (value > Data)
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
        // If value == Data, do nothing (no duplicates allowed)
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2

        // Base case: found the value
        if (value == Data)
            return true;

        // Search left subtree
        if (value < Data)
        {
            if (Left is null)
                return false;
            return Left.Contains(value);
        }

        // Search right subtree
        if (value > Data)
        {
            if (Right is null)
                return false;
            return Right.Contains(value);
        }

        return false;
    }

    public int GetHeight()
    {
        // TODO Start Problem 4

        // Get height of left and right subtrees
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;

        // Return 1 plus the maximum of the two subtree heights
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}