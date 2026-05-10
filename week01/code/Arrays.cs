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

        // Step 1: Create a new array of doubles with the size of length
        double[] result = new double[length];

        // Step 2: Create a loop that will run length number of times
        for (int i = 0; i < length; i++)
        {
            // Step 3: Calculate the multiple
            // Step 4: Save the calculated value into the current position of the array
            result[i] = number * (i + 1);
        }   

        // Step 5: Return the filled array
        return result; // replace this return statement with your own
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

        // Step 1: Create a new list for the rotated values
        List<int> rotated = new List<int>(data.Count);

        // Step 2: Calculate the starting index
        int startIndex = data.Count - amount;

        // Step 3: Copy the last 'amount' elements to the beginning of the rotated list
        for (int i = 0; i < amount; i++)
        {
            rotated.Add(data[startIndex + i]);
        }

        // Step 4: Copy the remaining elements
        for (int i = amount; i < data.Count; i++)
        {
            rotated.Add(data[i - amount]);
        }

        // Step 5: Clear the original list and add all elements from the rotated list
        data.Clear();
        data.AddRange(rotated);
    }
}
