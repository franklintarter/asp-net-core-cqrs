using System;

namespace AspNetCore.CQRS.SharedKernel
{
    public static class Guard
    {
        public static void NullArgument(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentException("Argument cannot be null");
            }
        }
    }
}
