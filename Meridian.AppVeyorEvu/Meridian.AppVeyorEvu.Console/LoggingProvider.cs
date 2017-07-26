// ----------------------------------------------------------------------------
// <copyright file="LoggingProvider.cs" company="MTCS (Matt Middleton)">
// Copyright (c) Meridian Technology Consulting Services (Matt Middleton).
// All rights reserved.
// </copyright>
// ----------------------------------------------------------------------------

namespace Meridian.AppVeyorEvu.Console
{
    using System;
    using Meridian.AppVeyorEvu.Logic.Definitions;
    using NLog;

    /// <summary>
    /// Implements <see cref="ILoggingProvider" />. 
    /// </summary>
    public class LoggingProvider : ILoggingProvider
    {
        /// <summary>
        /// The wrapped NLog <see cref="Logger" /> instance. 
        /// </summary>
        private readonly Logger logger;

        /// <summary>
        /// The <see cref="Type" /> of this <see cref="Logger" /> instance
        /// wrapper class.
        /// </summary>
        private readonly Type loggingProviderType;

        /// <summary>
        /// Initialises a new instance of the <see cref="LoggingProvider" />
        /// class.
        /// </summary>
        public LoggingProvider()
        {
            this.logger = LogManager.GetCurrentClassLogger();
            this.loggingProviderType = this.GetType();
        }

        /// <summary>
        /// Implements <see cref="ILoggingProvider.Debug(string)" />.
        /// </summary>
        /// <param name="msg">The message to log.</param>
        public void Debug(string msg)
        {
            this.Log(LogLevel.Debug, msg);
        }

        /// <summary>
        /// Implements <see cref="ILoggingProvider.Error(string)" />. 
        /// </summary>
        /// <param name="msg">The message to log.</param>
        public void Error(string msg)
        {
            this.Error(msg, null);
        }

        /// <summary>
        /// Implements
        /// <see cref="ILoggingProvider.Error(string, Exception)" />. 
        /// </summary>
        /// <param name="msg">The message to log.</param>
        /// <param name="exception">The exception to log.</param>
        public void Error(string msg, Exception exception)
        {
            this.Log(LogLevel.Error, msg, exception);
        }

        /// <summary>
        /// Implements <see cref="ILoggingProvider.Fatal(string)" />. 
        /// </summary>
        /// <param name="msg">The message to log.</param>
        public void Fatal(string msg)
        {
            this.Fatal(msg, null);
        }

        /// <summary>
        /// Implements
        /// <see cref="ILoggingProvider.Fatal(string, Exception)" />. 
        /// </summary>
        /// <param name="msg">The message to log.</param>
        /// <param name="exception">The exception to log.</param>
        public void Fatal(string msg, Exception exception)
        {
            this.Log(LogLevel.Fatal, msg, exception);
        }

        /// <summary>
        /// Implements <see cref="ILoggingProvider.Info(string)" />. 
        /// </summary>
        /// <param name="msg">The message to log.</param>
        public void Info(string msg)
        {
            this.Log(LogLevel.Info, msg);
        }

        /// <summary>
        /// Implements <see cref="ILoggingProvider.Warn(string)" />. 
        /// </summary>
        /// <param name="msg">The message to log.</param>
        public void Warn(string msg)
        {
            this.Warn(msg, null);
        }

        /// <summary>
        /// Implements
        /// <see cref="ILoggingProvider.Warn(string, Exception)" />. 
        /// </summary>
        /// <param name="msg">The message to log.</param>
        /// <param name="exception">The exception to log.</param>
        public void Warn(string msg, Exception exception)
        {
            this.Log(LogLevel.Warn, msg, exception);
        }

        /// <summary>
        /// Logs an event with a specified <paramref name="level" /> to
        /// NLog.
        /// </summary>
        /// <param name="level">The level of the logging event.</param>
        /// <param name="message">
        /// The log message including any parameter placeholders.
        /// </param>
        private void Log(LogLevel level, string message)
        {
            this.Log(level, message, null);
        }

        /// <summary>
        /// Logs an event with a specified <paramref name="level" /> to
        /// NLog.
        /// </summary>
        /// <param name="level">The level of the logging event.</param>
        /// <param name="message">
        /// The log message including any parameter placeholders.
        /// </param>
        /// <param name="exception">
        /// The <see cref="Exception" /> information.
        /// </param>
        private void Log(LogLevel level, string message, Exception exception)
        {
            LogEventInfo logEventInfo = new LogEventInfo()
            {
                Level = level,
                Message = message,
                Exception = exception
            };

            this.logger.Log(this.loggingProviderType, logEventInfo);
        }
    }
}