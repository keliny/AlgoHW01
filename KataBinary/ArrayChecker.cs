using System;
using System.Linq;

namespace KataBinary
{
    public class ArrayChecker
    {
        public void ValidateIndex(int index, bool[] array)
        {
            if (index > array.Length - 1 || index < 0)
                throw new Exception("Index is out of range.");
        }

        public void ValidateInsert(int length, bool[] array)
        {
            var count = array.Count(x => true);
            if (count == length)
                throw new Exception("Nowhere to insert, array is already full!");
            
        }
    }
}