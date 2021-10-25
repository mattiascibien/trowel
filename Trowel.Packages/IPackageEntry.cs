using System.IO;

namespace Trowel.Packages
{
    public interface IPackageEntry
    {
        string Name { get; }
        string FullName { get; }
        string ParentPath { get; }
        long Length { get; }
        Stream Open();
    }
}