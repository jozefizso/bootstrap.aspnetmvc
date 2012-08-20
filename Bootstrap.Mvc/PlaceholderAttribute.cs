using System;
using System.Web.Mvc;

namespace Twitter.Bootstrap.Mvc
{
    public class PlaceholderAttribute : Attribute, IMetadataAware
    {
        public PlaceholderAttribute()
        {
        }

        public PlaceholderAttribute(string placeholder)
        {
            this.Placeholder = placeholder;
        }

        public string Placeholder { get; set; }

        public void OnMetadataCreated(ModelMetadata metadata)
        {
            // Placeholder attribute was applied but no user text
            // was provided so we will default to the DisplayName value.
            string placeholderText = this.Placeholder ?? metadata.DisplayName;
            if (placeholderText != null)
                metadata.AdditionalValues["placeholder"] = placeholderText;
        }
    }
}
