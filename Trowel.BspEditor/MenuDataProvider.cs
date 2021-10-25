using Trowel.Common.Shell.Menu;
using Trowel.Common.Translations;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace Trowel.BspEditor
{
    [AutoTranslate]
    [Export(typeof(IMenuMetadataProvider))]
    public class MenuDataProvider : IMenuMetadataProvider
    {
        public string Window { get; set; }

        public IEnumerable<MenuSection> GetMenuSections()
        {
            yield return new MenuSection("Window", Window, "T");
        }

        public IEnumerable<MenuGroup> GetMenuGroups()
        {
            yield return new MenuGroup("Window", "", "Layout", "B");
        }
    }
}