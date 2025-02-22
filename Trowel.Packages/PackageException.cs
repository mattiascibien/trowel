﻿using System;

namespace Trowel.Packages
{
    public class PackageException : Exception
    {
        public PackageException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public PackageException()
        {
        }

        public PackageException(string message) : base(message)
        {
        }
    }
}
