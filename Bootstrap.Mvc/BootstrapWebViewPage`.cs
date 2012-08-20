using System;
using System.Web.Mvc;

namespace Twitter.Bootstrap.Mvc
{
    public abstract class BootstrapWebViewPage<TModel> : WebViewPage<TModel>
    {
        public BootstrapHelper<TModel> Bootstrap { get; set; }

        public override void InitHelpers()
        {
            base.InitHelpers();

            this.Bootstrap = new BootstrapHelper<TModel>(this.Html);
        }
    }
}
