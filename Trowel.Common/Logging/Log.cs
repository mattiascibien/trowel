﻿using LogicAndTrick.Oy;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Trowel.Common.Logging
{
    /// <summary>
    /// A static log interface. Just a shortcut to publish Log messages.
    /// </summary>
    public static class Log
    {
        /// <summary>
        /// Send an arbitrary log message.
        /// </summary>
        /// <param name="type">The type of log message</param>
        /// <param name="source">The source of the message</param>
        /// <param name="message">The message to log</param>
        /// <param name="ex">The exception associated with the log, if any</param>
        /// <returns>Completion task</returns>
        private static void Send(string type, string source, string message, Exception ex)
        {
            Task.Run(async () => await Oy.Publish("Log", new LogMessage(type, source, message, ex)));
        }

        /// <summary>
        /// Log a fatal error message
        /// </summary>
        /// <param name="source">The source of the message</param>
        /// <param name="message">The message to log</param>
        /// <param name="ex">The exception associated with the log</param>
        public static void Fatal(string source, string message, Exception ex)
        {
            Send(LogMessage.Fatal, source, message, ex);
        }

        /// <summary>
        /// Log a regular error message
        /// </summary>
        /// <param name="source">The source of the message</param>
        /// <param name="message">The message to log</param>
        /// <param name="ex">The exception associated with the log</param>
        public static void Error(string source, string message, Exception ex)
        {
            Send(LogMessage.Error, source, message, ex);
        }

        /// <summary>
        /// Log a warning message
        /// </summary>
        /// <param name="source">The source of the message</param>
        /// <param name="message">The message to log</param>
        /// <param name="ex">The exception associated with the log, if any</param>
        public static void Warning(string source, string message, Exception ex = null)
        {
            Send(LogMessage.Warning, source, message, ex);
        }

        /// <summary>
        /// Log an informational message
        /// </summary>
        /// <param name="source">The source of the message</param>
        /// <param name="message">The message to log</param>
        public static void Info(string source, string message)
        {
            Send(LogMessage.Info, source, message, null);
        }

        /// <summary>
        /// Log a debug message
        /// </summary>
        /// <param name="source">The source of the message</param>
        /// <param name="message">The message to log</param>
        [Conditional("DEBUG")]
        public static void Debug(string source, string message)
        {
            Send(LogMessage.Debug, source, message, null);
        }
    }
}