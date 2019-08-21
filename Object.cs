using System;

namespace Core
{
    public class Object
    {
        public readonly DateTime CreationDate = DateTime.Now;

        public readonly long UID = ++Increment;

        private static long Increment = 0;
    }
}
