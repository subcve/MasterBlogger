using System;

namespace MB.Domain.Exceptions
{
    public class DuplicatedRecordException : Exception
    {
        public DuplicatedRecordException()
        {
            
        }

        public DuplicatedRecordException(string message) : base(message)
        {
            
        }
    }
}
