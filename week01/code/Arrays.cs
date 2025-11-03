public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // PLAN:
        // Step 1: Create a new array of doubles with size equal to 'length'
        //         This will hold all the multiples we calculate
        // Step 2: Loop through each index position from 0 to length-1
        // Step 3: For each position i, calculate the multiple:
        //         - The first multiple (i=0) should be number * 1
        //         - The second multiple (i=1) should be number * 2
        //         - The third multiple (i=2) should be number * 3
        //         - Pattern: multiply number by (i + 1)
        // Step 4: Store the calculated multiple in the array at position i
        // Step 5: After the loop completes, return the array containing all multiples

        // IMPLEMENTATION:
        // Step 1: Create array to hold the multiples
        double[] multiples = new double[length];

        // Step 2-4: Loop through and calculate each multiple
        for (int i = 0; i < length; i++)
        {
            // Step 3: Calculate the multiple (number times the multiplier)
            // Multiplier is (i + 1) because array indices start at 0
            // but we want the 1st, 2nd, 3rd, etc. multiples
            multiples[i] = number * (i + 1);
        }

        // Step 5: Return the completed array
        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // PLAN:
        //
        // UNDERSTANDING THE PROBLEM:
        // Rotating right by 'amount' means taking the last 'amount' elements from the end
        // of the list and moving them to the front.
        // Example: {1, 2, 3, 4, 5, 6, 7, 8, 9} rotated right by 3
        //   - Last 3 elements: {7, 8, 9}
        //   - Remaining elements: {1, 2, 3, 4, 5, 6}
        //   - Result: {7, 8, 9, 1, 2, 3, 4, 5, 6}
        //
        // ALGORITHM:
        // Step 1: Calculate the split point where we divide the list
        //         splitPoint = data.Count - amount
        //         This tells us where the "rotation point" is in the list
        //         Elements from splitPoint to the end will move to the front
        //         Elements from 0 to splitPoint-1 will move to the back
        //
        // Step 2: Extract the "right portion" (elements that will move to the front)
        //         Use GetRange(splitPoint, amount) to get the last 'amount' elements
        //         Store these in a temporary variable
        //         Example: For {1,2,3,4,5,6,7,8,9} with amount=3, splitPoint=6
        //                  Right portion = GetRange(6, 3) = {7, 8, 9}
        //
        // Step 3: Extract the "left portion" (elements that will move to the back)
        //         Use GetRange(0, splitPoint) to get the first 'splitPoint' elements
        //         Store these in a temporary variable
        //         Example: Left portion = GetRange(0, 6) = {1, 2, 3, 4, 5, 6}
        //
        // Step 4: Clear the original list
        //         Use data.Clear() to remove all elements
        //         We'll rebuild it in the correct order
        //
        // Step 5: Add the right portion first (what was at the end goes to the front)
        //         Use data.AddRange(rightPortion)
        //         Example: data becomes {7, 8, 9}
        //
        // Step 6: Add the left portion second (what was at the beginning goes to the end)
        //         Use data.AddRange(leftPortion)
        //         Example: data becomes {7, 8, 9, 1, 2, 3, 4, 5, 6}
        //
        // The list is now rotated right by 'amount' positions!

        // IMPLEMENTATION:

        // Step 1: Calculate where to split the list
        // If we have 9 elements and rotate right by 3, split at index 6
        // Elements at indices 6, 7, 8 move to the front
        int splitPoint = data.Count - amount;

        // Step 2: Extract the right portion (last 'amount' elements)
        // These elements will move to the front of the list
        List<int> rightPortion = data.GetRange(splitPoint, amount);

        // Step 3: Extract the left portion (first 'splitPoint' elements)
        // These elements will move to the back of the list
        List<int> leftPortion = data.GetRange(0, splitPoint);

        // Step 4: Clear the original list to rebuild it
        data.Clear();

        // Step 5: Add the right portion first (what was at end, now at front)
        data.AddRange(rightPortion);

        // Step 6: Add the left portion second (what was at start, now at end)
        data.AddRange(leftPortion);

        // The list has been successfully rotated right!
    }
}
