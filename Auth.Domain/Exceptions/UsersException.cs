using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Domain.Exceptions
{
    public class UsersException : Exception
    {
        public UsersException(string error) : base(error) { }
        public static void When(bool hasError, string error)
        {
            if (hasError)
            {
                throw new UsersException(error);
            }
        }
    }
}