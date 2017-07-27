// ----------------------------------------------------------------------------
// <copyright file="Settings.cs" company="MTCS (Matt Middleton)">
// Copyright (c) Meridian Technology Consulting Services (Matt Middleton).
// All rights reserved.
// </copyright>
// ----------------------------------------------------------------------------

namespace Meridian.AppVeyorEvu.Logic.Models
{
    /// <summary>
    /// Describes the structure of settings against an
    /// <see cref="EnvironmentDetail" />.
    /// </summary>
    public class Settings
    {
        /// <summary>
        /// Gets or sets an array of <see cref="EnvironmentVariable" />
        /// instances.
        /// </summary>
        public EnvironmentVariable[] EnvironmentVariables
        {
            get;
            set;
        }
    }
}