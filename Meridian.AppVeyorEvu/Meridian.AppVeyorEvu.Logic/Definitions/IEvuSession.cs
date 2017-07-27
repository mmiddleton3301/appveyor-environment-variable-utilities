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
        /// Compares environment variables for a given list of AppVeyor
        /// environments.
        /// </summary>
        /// <param name="apiToken">
        /// The AppVeyor API token to be used.
        /// </param>
        /// <param name="environments">
        /// A list of environment names, as they appear in AppVeyor.
        /// </param>
        /// <returns>
        /// Returns true if the process completed with success, otherwise
        /// false.
        /// </returns>
        bool CompareEnvironmentVariables(
            string apiToken,
            string[] environments);
    }
}