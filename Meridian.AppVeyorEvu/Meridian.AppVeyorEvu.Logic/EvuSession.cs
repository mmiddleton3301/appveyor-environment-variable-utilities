// ----------------------------------------------------------------------------
// <copyright file="EvuSession.cs" company="MTCS (Matt Middleton)">
// Copyright (c) Meridian Technology Consulting Services (Matt Middleton).
// All rights reserved.
// </copyright>
// ----------------------------------------------------------------------------

namespace Meridian.AppVeyorEvu.Logic
{
    using Meridian.AppVeyorEvu.Logic.Definitions;

    /// <summary>
    /// Implements <see cref="IEvuSession" />.
    /// </summary> 
    public class EvuSession : IEvuSession
    {
        /// <summary>
        /// An instance of <see cref="ILoggingProvider" />.
        /// </summary>
        private readonly ILoggingProvider loggingProvider;

        /// <summary>
        /// Initialises a new instance of the <see cref="EvuSession" /> class.
        /// </summary>
        /// <param name="loggingProvider">
        /// An instance of <see cref="ILoggingProvider" />.
        /// </param>
        public EvuSession(ILoggingProvider loggingProvider)
        {
            this.loggingProvider = loggingProvider;
        }
            
        /// <summary>
        /// Implements <see cref="IEvuSession.Run()" />.
        /// </summary> 
        /// <returns>
        /// Returns true if the process completed with success, otherwise
        /// false.
        /// </returns>
        public bool Run()
        {
            bool toReturn = default(bool);

            // TODO: Implement the main method.
            this.loggingProvider.Warn("This is a test log message.");

            toReturn = true;

            return toReturn;
        }
    }
}