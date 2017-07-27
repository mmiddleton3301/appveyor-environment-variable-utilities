// ----------------------------------------------------------------------------
// <copyright file="ICsvProvider.cs" company="MTCS (Matt Middleton)">
// Copyright (c) Meridian Technology Consulting Services (Matt Middleton).
// All rights reserved.
// </copyright>
// ----------------------------------------------------------------------------

namespace Meridian.AppVeyorEvu.Logic.Definitions
{
    using System.IO;

    /// <summary>
    /// Describes the operations provided by the CSV provider.
    /// </summary>
    public interface ICsvProvider
    {
        /// <summary>
        /// Writes a 2-dimensional array of <see cref="string" /> values to
        /// the specified <paramref name="destinationLocation" /> as a
        /// CSV file.
        /// </summary>
        /// <param name="destinationLocation">
        /// The destination location for the CSV file, as a
        /// <see cref="FileInfo" /> instance.
        /// </param>
        /// <param name="values">
        /// An array of an array of <see cref="string" /> values.
        /// </param>
        void WriteCsv(FileInfo destinationLocation, string[][] values);
    }
}