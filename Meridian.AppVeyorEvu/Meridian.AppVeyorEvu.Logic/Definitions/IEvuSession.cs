// ----------------------------------------------------------------------------
// <copyright file="IEvuSession.cs" company="MTCS (Matt Middleton)">
// Copyright (c) Meridian Technology Consulting Services (Matt Middleton).
// All rights reserved.
// </copyright>
// ----------------------------------------------------------------------------

namespace Meridian.AppVeyorEvu.Logic.Definitions
{
    /// <summary>
    /// Describes the operations provided by the environment variable utilities
    /// session.
    /// </summary>
    public interface IEvuSession
    {
        /// <summary>
        /// The main entry point for the session. Name subject to change.
        /// </summary>
        /// <param name="apiToken">
        /// The AppVeyor API token to be used.
        /// </param>
        /// <returns>
        /// Returns true if the process completed with success, otherwise
        /// false.
        /// </returns>
        bool Run(string apiToken);
    }
}