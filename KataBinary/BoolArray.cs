using System;
using System.Linq;
using KataBinary.Interfaces;

namespace KataBinary
{
    public class BoolArray : IBoolArray
    {
        private readonly int _length;
        private static bool[] Booleans { get; set; }
        private readonly ArrayChecker _arrayChecker;
        private static bool[] Mask { get; set; }

        public BoolArray(int length)
        {
            _length = length;
            Booleans = new bool[length];
            _arrayChecker = new ArrayChecker();
            Mask = new bool[length];
        }

        public void DisplayArray()
        {
            foreach (var b in Booleans.Reverse())
            {
                Console.Write(b ? 1 : 0);
            }

            Console.WriteLine();
        }

        public bool Getter(int index)
        {
            _arrayChecker.ValidateIndex(index, Booleans);

            return Booleans[index];
        }

        public bool Setter(int index, bool value)
        {
            _arrayChecker.ValidateIndex(index, Booleans);


            // Setter for true
            if (value)
            {
                MaskSetter(true, index);

                for (var i = 0; i < _length; i++)
                {
                    Booleans[i] = Booleans[i] | Mask[i];
                }
            }
            // setter for false
            else
            {
                MaskSetter(false, index);

                for (var i = 0; i < _length; i++)
                {
                    Booleans[i] = Booleans[i] & Mask[i];
                }
            }

            return value;
        }

        public bool[] Insert(int index, bool value)
        {
            // Insert a value into the array. If the array is full last value will be deleted.
            _arrayChecker.ValidateIndex(index, Booleans);

            var backupArray = CopyArray();

            for (var i = 0; i < _length; i++)
            {
                if (i == index)
                {
                    Setter(i, value);
                }
                else if (i > index)
                {
                    Setter(i, backupArray[i - 1]);
                }
            }

            return Booleans;
        }

        public bool Remove(int index)
        {
            _arrayChecker.ValidateIndex(index, Booleans);

            var backupArray = CopyArray();

            for (var i = 0; i < _length; i++)
            {
                if (i ==_length - 1)
                {
                    Setter(i, false);
                }
                else if (i >= index)
                {
                    Setter(i, backupArray[i + 1]);
                }
            }

            return backupArray[index];
        }

        public bool[] Append(bool value)
        {
            var backupArray = CopyArray();

            for (var i = 0; i < _length; i++)
            {
                if (i == _length -1)
                {
                    Setter(i, value);
                    continue;
                }
                
                Setter(i, backupArray[i + 1]);
            }
            return Booleans;
        }

        public bool[] Prepend(bool value)
        {
            var backupArray = CopyArray();

            for (var i = 0; i < _length; i++)
            {
                if (i == 0)
                {
                    Setter(i, value);
                    continue;
                }

                Setter(i, backupArray[i - 1]);
            }
            return Booleans;
        }

        public int? Find(bool value)
        {
            var index = -1;
            // finder for true
            if (value)
            {
                

                for (var i = 0; i < _length; i++)
                {
                    MaskSetter(true, i);
                    if (Booleans[i] & Mask[i])
                    {
                        index = i;
                        break;
                    }
                }
            }
            // finder for false
            else
            {
                MaskSetter(false, index);

                for (var i = 0; i < _length; i++)
                {
                    Booleans[i] = Booleans[i] & Mask[i];
                }
            }

            int? res;
            if (index == -1)
            {
                 res = index;
            }
            else
            {
                 res = null;
            }
            Console.WriteLine($"Your value was found at index {res}");
            return res;
        }

        public void MaskSetter(bool val, int index)
        {
            for (var i = 0; i < Booleans.Length; i++)
            {
                if (i == index)
                {
                    Mask[i] = val;
                }
                else
                {
                    Mask[i] = !val;
                }
            }
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"length is {_length}");

            Console.WriteLine($"Mask is ");
            foreach (var b in Mask.Reverse())
            {
                Console.Write(b ? "1" : "0");
            }

            Console.WriteLine();

            Console.WriteLine($"Array is");
            foreach (var b in Booleans.Reverse())
            {
                Console.Write(b ? 1 : 0);
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        // Deep copy the array
        public bool[] CopyArray()
        {
            var arrCopy = new bool[_length];
            for (var i = 0; i < _length; i++)
            {
                arrCopy[i] = Booleans[i];
            }

            return arrCopy;
        }
    }
}