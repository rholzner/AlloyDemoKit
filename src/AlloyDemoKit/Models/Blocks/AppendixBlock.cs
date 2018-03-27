using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AlloyDemoKit.PropertyDefinition;
using EPiServer;
using EPiServer.Cms.Shell.UI.ObjectEditing.EditorDescriptors;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;

namespace AlloyDemoKit.Models.Blocks
{
    [ContentType(GUID = "cb788228-13ce-4cae-aee3-9e08261ccc8f")]
    [ImageUrl("~/UI/epi-thumbs/add.svg")]
    public class AppendixBlock : SiteBlockData
    {
        [CultureSpecific]
        [Display(Order = 100, GroupName = SystemTabNames.Content)]
        public virtual string Heading { get; set; }

        public virtual Url Url { get; set; }


        [Required]
        [CultureSpecific]
        [EditorDescriptor(EditorDescriptorType = typeof(CollectionEditorDescriptor<AppendixValueItem>))]
        [Display(Order = 200, GroupName = SystemTabNames.Content)]
        public virtual IList<AppendixValueItem> AppendixItems { get; set; }

        public bool HasHeading => !string.IsNullOrEmpty(Heading);
    }
}