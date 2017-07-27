// ----------------------------------------------------------------------------
// <copyright
//      file="SingleEnvironmentWrapper.cs"
//      company="MTCS (Matt Middleton)">
// Copyright (c) Meridian Technology Consulting Services (Matt Middleton).
// All rights reserved.
// </copyright>
// ----------------------------------------------------------------------------

namespace Meridian.AppVeyorEvu.Logic.Models
{
    /// <summary>
    /// Acts as a wrapper for the <see cref="Models.EnvironmentDetail" />
    /// class, in the case where we are pulling back single instances from the
    /// AppVeyor API.
    /// </summary>
    public class SingleEnvironmentWrapper
    {
        /// <summary>
        /// Gets or sets an instance of
        /// <see cref="Models.EnvironmentDetail" />.
        /// </summary>
        public EnvironmentDetail Environment
        {
            get;
            set;
        }
    }
}