// ----------------------------------------------------------------------------
// <copyright file="AppVeyorValue.cs" company="MTCS (Matt Middleton)">
// Copyright (c) Meridian Technology Consulting Services (Matt Middleton).
// All rights reserved.
// </copyright>
// ----------------------------------------------------------------------------

namespace Meridian.AppVeyorEvu.Logic.Models
{
    /// <summary>
    /// Describes an AppVeyor value, which may or may not be encrypted.
    /// </summary>
    public class AppVeyorValue
    {
        /// <summary>
        /// Gets or sets a value indicating whether or not the value is
        /// encrypted.
        /// </summary>
        public bool IsEncrypted
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the raw <see cref="string" /> value.
        /// </summary>
        public string Value
        {
            get;
            set;
        }
    }
}