// ----------------------------------------------------------------------------
// <copyright file="ILoggingProvider.cs" company="MTCS (Matt Middleton)">
// Copyright (c) Meridian Technology Consulting Services (Matt Middleton).
// All rights reserved.
// </copyright>
// ----------------------------------------------------------------------------

namespace Meridian.AppVeyorEvu.Logic.Definitions
{
    using System;

    /// <summary>
    /// Describes the operations of the logging provider.
    /// </summary>
    public interface ILoggingProvider
    {
        /// <summary>
        /// Logs a debug message.
        /// </summary>
        /// <param name="msg">
        /// The message to log.
        /// </param>
        void Debug(string msg);

        /// <summary>
        /// Logs an error.
        /// </summary>
        /// <param name="msg">
        /// The message to log.
        /// </param>
        void Error(string msg);

        /// <summary>
        /// Logs an error.
        /// </summary>
        /// <param name="msg">
        /// The message to log.
        /// </param>
        /// <param name="exception">
        /// The exception to log.
        /// </param>
        void Error(string msg, Exception exception);

        /// <summary>
        /// Logs a fatal event.
        /// </summary>
        /// <param name="msg">
        /// The message to log.
        /// </param>
        void Fatal(string msg);

        /// <summary>
        /// Logs a fatal event.
        /// </summary>
        /// <param name="msg">
        /// The message to log.
        /// </param>
        /// <param name="exception">
        /// The exception to log.
        /// </param>
        void Fatal(string msg, Exception exception);

        /// <summary>
        /// Logs an informational message.
        /// </summary>
        /// <param name="msg">
        /// The message to log.
        /// </param>
        void Info(string msg);

        /// <summary>
        /// Logs a message as a warning.
        /// </summary>
        /// <param name="msg">
        /// The message to log.
        /// </param>
        void Warn(string msg);

        /// <summary>
        /// Logs a message as a warning.
        /// </summary>
        /// <param name="msg">
        /// The message to log.
        /// </param>
        /// <param name="exception">
        /// The exception to log.
        /// </param>
        void Warn(string msg, Exception exception);
    }
}
