using System.Collections.Generic;

namespace Trowel.BspEditor.Environment
{
    public class SerialisedEnvironment
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public Dictionary<string, string> Properties { get; set; } = new Dictionary<string, string>();
    }
}