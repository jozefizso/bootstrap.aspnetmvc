using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Twitter.Bootstrap.Mvc
{
    public static class ButtonExtensions
    {
        /// <summary>
        /// Bootstrap button.
        /// </summary>
        /// <returns>.btn</returns>
        public static IHtmlString Button(this BootstrapHelper helper, string text)
        {
            return Button(helper, text, null);
        }

        public static IHtmlString PrimaryButton(this BootstrapHelper helper, string text)
        {
            return Button(helper, text, "primary");
        }

        /// <summary>
        /// Bootstrap button.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="bootstrapType">One of the values: primary, info, success, warning, danger or inverse.</param>
        /// <returns>.btn [.btn-primary] [.btn-info] [.btn-success] [.btn-warning] [.btn-danger] [.btn-inverse].</returns>
        public static IHtmlString Button(this BootstrapHelper helper, string text, string bootstrapType)
        {
            TagBuilder tag = new TagBuilder("input");
            tag.Attributes.Add("type", "submit");
            tag.AddCssClass("btn");
            if (bootstrapType != null)
                tag.AddCssClass("btn-" + bootstrapType);

            tag.Attributes.Add("value", text);

            return tag.ToHtmlString();
        }

    }
}
