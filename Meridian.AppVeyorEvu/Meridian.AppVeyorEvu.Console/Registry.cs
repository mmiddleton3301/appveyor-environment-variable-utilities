// ----------------------------------------------------------------------------
// <copyright file="Registry.cs" company="MTCS (Matt Middleton)">
// Copyright (c) Meridian Technology Consulting Services (Matt Middleton).
// All rights reserved.
// </copyright>
// ----------------------------------------------------------------------------

namespace Meridian.AppVeyorEvu.Console
{
    using StructureMap.Graph;

    /// <summary>
    /// Local registry implementation, inheriting from
    /// <see cref="StructureMap.Registry" />.
    /// </summary>
    public class Registry : StructureMap.Registry
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="Registry" />
        /// class.
        /// </summary>
        public Registry()
        {
            this.Scan(this.DoScan);
        }

        /// <summary>
        /// Performs a scan to automatically map interfaces to concrete types.
        /// </summary>
        /// <param name="assemblyScanner">
        /// An instance of <see cref="IAssemblyScanner" />.
        /// </param>
        private void DoScan(IAssemblyScanner assemblyScanner)
        {
            // Always create concrete instances based on usual DI naming
            // convention
            // i.e. Search for class name "Concrete" when "IConcrete" is
            //      requested.
            assemblyScanner.WithDefaultConventions();

            // Scan the calling assembly.
            assemblyScanner.TheCallingAssembly();

            // And all other Meridian assemblies.
            assemblyScanner.AssembliesFromApplicationBaseDirectory(
                x => x.FullName.StartsWith("Meridian"));
        }
    }
}