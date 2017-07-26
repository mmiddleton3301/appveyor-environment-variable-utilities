// ----------------------------------------------------------------------------
// <copyright file="Environment.cs" company="MTCS (Matt Middleton)">
// Copyright (c) Meridian Technology Consulting Services (Matt Middleton).
// All rights reserved.
// </copyright>
// ----------------------------------------------------------------------------

namespace Meridian.AppVeyorEvu.Logic.Models
{
    /// <summary>
    /// Describes an environment in AppVeyor.
    /// </summary>
    public class Environment
    {
        /// <summary>
        /// Gets or sets the deployment environment id.
        /// </summary>
        public int DeploymentEnvironmentId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the name of the environment.
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Overrides <see cref="object.ToString()" />.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            string toReturn =
                $"Environment (" +
                $"{nameof(this.DeploymentEnvironmentId)} = {this.DeploymentEnvironmentId}, " +
                $"{nameof(this.Name)} = \"{this.Name}\")";

            return toReturn;
        }
    }
}