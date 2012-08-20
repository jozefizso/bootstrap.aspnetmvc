using System;
using System.Web.Mvc;

namespace Twitter.Bootstrap.Mvc
{
    public abstract class BootstrapWebViewPage : WebViewPage
    {
        public BootstrapHelper<object> Bootstrap { get; set; }

        public override void InitHelpers()
        {
            base.InitHelpers();

            this.Bootstrap = new BootstrapHelper<object>(this.Html);
        }
    }
}
