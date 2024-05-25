namespace ArcwaveConsole.PackageReader
{
    using Sitecore.Install.Framework;
    using Sitecore.Install.Utils;
    using System;
    using ArcwaveConsole.PackageReader.Managers;
    using Sitecore.Install;

    public class Program
    {
        public static void Main(string[] args)
        {
            var filePath = $@"Update filepath of the Package.zip";

            ISource<PackageEntry> source = new Sitecore.Install.Zip.PackageReader(filePath);

            var packageSinkHelper = new PackageSinkManager();

            packageSinkHelper.Initialize(Installer.CreatePreviewContext());
            
            new EntrySorter(source).Populate(packageSinkHelper);

            Console.ReadKey();

        }
    }
}
