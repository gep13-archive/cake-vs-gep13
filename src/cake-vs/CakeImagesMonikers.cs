using System;
using Microsoft.VisualStudio.Imaging.Interop;

namespace cake_vs
{
    public static class CakeImagesMonikers
    {
        private static readonly Guid ManifestGuid = new Guid("23caf834-d26c-422b-9b25-666746a71591");

        private const int ProjectIcon = 0;

        public static ImageMoniker ProjectIconImageMoniker
        {
            get
            {
                return new ImageMoniker { Guid = ManifestGuid, Id = ProjectIcon };
            }
        }
    }
}
