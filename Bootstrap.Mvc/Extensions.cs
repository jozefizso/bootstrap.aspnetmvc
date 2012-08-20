using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Twitter.Bootstrap.Mvc
{
    public static class Extensions
    {
        public static IHtmlString ToHtmlString(this TagBuilder tag)
        {
            if (tag == null)
                throw new ArgumentNullException("tag");
            return new HtmlString(tag.ToString(TagRenderMode.Normal));
        }
    }
}
