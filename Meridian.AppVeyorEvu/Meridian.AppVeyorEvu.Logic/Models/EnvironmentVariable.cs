// ----------------------------------------------------------------------------
// <copyright file="EnvironmentVariable.cs" company="MTCS (Matt Middleton)">
// Copyright (c) Meridian Technology Consulting Services (Matt Middleton).
// All rights reserved.
// </copyright>
// ----------------------------------------------------------------------------

namespace Meridian.AppVeyorEvu.Logic.Models
{
    /// <summary>
    /// Describes the structure of a <see cref="EnvironmentVariable" />
    /// value.
    /// </summary>
    public class EnvironmentVariable
    {
        /// <summary>
        /// Gets or sets the name of the <see cref="EnvironmentVariable" />.
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the value of the <see cref="EnvironmentVariable" />.
        /// </summary>
        public AppVeyorValue Value
        {
            get;
            set;
        }
    }
}