// ----------------------------------------------------------------------------
// <copyright file="CsvProvider.cs" company="MTCS (Matt Middleton)">
// Copyright (c) Meridian Technology Consulting Services (Matt Middleton).
// All rights reserved.
// </copyright>
// ----------------------------------------------------------------------------

namespace Meridian.AppVeyorEvu.Console
{
    using System.IO;
    using CsvHelper;
    using Meridian.AppVeyorEvu.Logic.Definitions;

    /// <summary>
    /// Implements <see cref="ICsvProvider" />.
    /// </summary>
    public class CsvProvider : ICsvProvider
    {
        /// <summary>
        /// Implements
        /// <see cref="ICsvProvider.WriteCsv(FileInfo, string[][])" />.
        /// </summary>
        /// <param name="destinationLocation">
        /// The destination location for the CSV file, as a
        /// <see cref="FileInfo" /> instance.
        /// </param>
        /// <param name="values">
        /// An array of an array of <see cref="string" /> values.
        /// </param>
        public void WriteCsv(FileInfo destinationLocation, string[][] values)
        {
            using (FileStream fileStream = destinationLocation.Open(FileMode.OpenOrCreate, FileAccess.Write))
            {
                using (TextWriter textWriter = new StreamWriter(fileStream))
                {
                    using (CsvWriter csvWriter = new CsvWriter(textWriter))
                    {
                        foreach (string[] line in values)
                        {
                            foreach (string value in line)
                            {
                                csvWriter.WriteField(value);
                            }

                            csvWriter.NextRecord();
                        }
                    }
                }
            }
        }
    }
}