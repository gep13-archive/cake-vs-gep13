using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Utilities;

namespace cake_vs.ContentType
{
    public class CakeContentTypeDefinition
    {
        [Export(typeof(FileExtensionToContentTypeDefinition))]
        [ContentType("CSharp")]
        [FileExtension(".cake")]
        public FileExtensionToContentTypeDefinition CakeFileExtension { get; set; }
    }
}