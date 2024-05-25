namespace ArcwaveConsole.PackageReader.Managers
{
    using Sitecore.Globalization;
    using Sitecore.Install;
    using Sitecore.Install.Framework;
    using Sitecore.Install.Utils;
    using System;
    using System.Text;

    public class PackageSinkManager : BaseSink<PackageEntry>
    {
        public override void Put(PackageEntry entry)
        {
            Console.WriteLine($"Key: {entry.Key}. Source: {PackageUtils.TryGetValue(entry.Properties, "source")}.");
        }

        private string FormatInstallOptions(BehaviourOptions options)
        {
            if (!options.IsDefined)
            {
                return Translate.Text("Undefined");
            }
                
            InstallMode itemMode = options.ItemMode;

            if (itemMode == InstallMode.Undefined)
            {
                return Translate.Text("Ask User");
            }

            var stringBuilder = new StringBuilder(50);
            
            stringBuilder.Append(Translate.Text(itemMode.ToString()));
            
            if (itemMode == InstallMode.Merge)
            {
                stringBuilder.Append(" / ");

                stringBuilder.Append(Translate.Text(options.ItemMergeMode.ToString()));
            }
            
            return stringBuilder.ToString();
        }
    }
}
