using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Imaging;
using Microsoft.VisualStudio.ProjectSystem.Utilities;
using Microsoft.VisualStudio.ProjectSystem.Designers;
using Microsoft.VisualStudio.ProjectSystem.Utilities.Designers;

namespace cake_vs
{
    using System.IO;

    [Export(typeof(IProjectTreeModifier))]
    [AppliesTo("Cake")]
    internal class CakeProjectTreeModifier : IProjectTreeModifier
    {
        public IProjectTree ApplyModifications(IProjectTree tree, IProjectTreeProvider projectTreeProvider)
        {
            // Only set the icon for the root project node.  We could choose to set different icons for nodes based
            // on various criteria, not just Capabilities, if we wished.
            if (tree.Capabilities.Contains(ProjectTreeCapabilities.ProjectRoot))
            {
                tree = tree.SetIcon(KnownMonikers.JSProjectNode.ToProjectSystemType());
            }
            else if (tree.Capabilities.Contains(ProjectTreeCapabilities.FileOnDisk))
            {
                var extension = Path.GetExtension(tree.FilePath);
                if (extension != null)
                {
                    var ext = extension.ToLowerInvariant();
                    if (ext == ".cake")
                    {
                        tree = tree.SetIcon(CakeImagesMonikers.ProjectIconImageMoniker.ToProjectSystemType());
                    }
                }
            }

            return tree;
        }
    }
}