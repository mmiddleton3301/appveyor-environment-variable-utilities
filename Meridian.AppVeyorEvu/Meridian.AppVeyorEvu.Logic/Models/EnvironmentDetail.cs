// ----------------------------------------------------------------------------
// <copyright file="EnvironmentDetail.cs" company="MTCS (Matt Middleton)">
// Copyright (c) Meridian Technology Consulting Services (Matt Middleton).
// All rights reserved.
// </copyright>
// ----------------------------------------------------------------------------

namespace Meridian.AppVeyorEvu.Logic.Models
{
    /// <summary>
    /// A more detailed version of <see cref="Models.Environment" />.
    /// </summary>
    public class EnvironmentDetail : Environment
    {
        /// <summary>
        /// Gets or sets a <see cref="Models.Settings" /> instance, belonging
        /// to the <see cref="Environment" />.
        /// </summary>
        public Settings Settings
        {
            get;
            set;
        }
    }
}