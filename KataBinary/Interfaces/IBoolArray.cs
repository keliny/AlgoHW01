namespace KataBinary.Interfaces
{
    public interface IBoolArray
    {
        //Get by index - returns a value
        bool Getter(int index);

        // Set a bool value at desired index - returns the value
        bool Setter(int index, bool value);

        // Insert a bool value into an array - returns array
        // If the index is > then length -1 throws an exception (that's in the HW description)
        bool[] Insert(int index, bool value);

        // Remove a value at the index - returns removed value
        bool Remove(int index);

        // Appends a value to the array - returns an array
        bool[] Append(bool value);

        // Prepends the value to the array - returns an array
        bool[] Prepend(bool value);

        // Find an value in a BIT array......... return first index
        int? Find(bool value);

    }
}