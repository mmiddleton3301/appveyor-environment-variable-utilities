// ----------------------------------------------------------------------------
// <copyright file="VerbosityOption.cs" company="MTCS (Matt Middleton)">
// Copyright (c) Meridian Technology Consulting Services (Matt Middleton).
// All rights reserved.
// </copyright>
// ----------------------------------------------------------------------------

namespace Meridian.AppVeyorEvu.Console
{
    /// <summary>
    /// Describes the various levels of logging verbosity available.
    /// Used by <see cref="Options" />. Pretty much mirrors NLog's logging
    /// levels. <see cref="System.Enum" /> created for easy parsing by
    /// <c>CommandLine</c>.
    /// </summary>
    public enum VerbosityOption
    {
        /// <summary>
        /// The verbosity option "Off".
        /// </summary>
        Off = 1,

        /// <summary>
        /// The verbosity option "Debug".
        /// </summary>
        Debug = 2,

        /// <summary>
        /// The verbosity option "Info".
        /// </summary>
        Info = 3,

        /// <summary>
        /// The verbosity option "Warn".
        /// </summary>
        Warn = 4,

        /// <summary>
        /// The verbosity option "Error".
        /// </summary>
        Error = 5,

        /// <summary>
        /// The verbosity option "Fatal".
        /// </summary>
        Fatal = 6
    }
}
