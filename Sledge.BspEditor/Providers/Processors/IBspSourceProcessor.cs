using Sledge.BspEditor.Documents;
using System.Threading.Tasks;

namespace Sledge.BspEditor.Providers.Processors
{
    public interface IBspSourceProcessor
    {
        string OrderHint { get; }
        Task AfterLoad(MapDocument document);
        Task BeforeSave(MapDocument document);
    }
}
