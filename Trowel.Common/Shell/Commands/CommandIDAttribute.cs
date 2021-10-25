﻿using System;

namespace Trowel.Common.Shell.Commands
{
    /// <summary>
    /// Used to specify a command ID rather than using the default.
    /// </summary>
    public class CommandIDAttribute : Attribute
    {
        public string ID { get; }

        public CommandIDAttribute(string id)
        {
            ID = id;
        }
    }
}