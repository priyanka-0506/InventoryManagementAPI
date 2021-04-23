using System;

namespace InventoryManagementAPI.Boundary.Exceptions
{
    public class DataConflictException : Exception
    {
        public DataConflictException()
        { }

        public DataConflictException(string message) : base(message)
        { }

        public DataConflictException(string message, Exception inner) : base(message, inner)
        { }
    }
}
