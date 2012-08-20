using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Twitter.Bootstrap.Mvc
{
    public class BootstrapHelper
    {
        public BootstrapHelper(HtmlHelper htmlHelper)
        {
            if (htmlHelper == null)
                throw new ArgumentNullException("htmlHelper");

            this.Html = htmlHelper;
        }

        public HtmlHelper Html { get; set; }

        #region HTML Forms
        /// <summary>
        /// Stacked, left-aligned labels over controls.
        /// </summary>
        /// <returns>.form-vertical</returns>
        public MvcForm BeginForm()
        {
            return this.BeginBootstrapForm("form-vertical");
        }
        /// <summary>
        /// Float left, right-aligned labels on same line as controls.
        /// </summary>
        /// <returns>.form-horizontal</returns>
        public MvcForm BeginHorizontalForm()
        {
            return this.BeginBootstrapForm("form-horizontal");
        }

        /// <summary>
        /// Left-aligned label and inline-block controls for compact style.
        /// </summary>
        /// <returns>.form-inline</returns>
        public MvcForm BeginInlineForm()
        {
            return this.BeginBootstrapForm("form-inline");
        }

        /// <summary>
        /// Extra-rounded text input for a typical search aesthetic.
        /// </summary>
        /// <returns>.form-search</returns>
        public MvcForm BeginSearchForm()
        {
            return this.BeginBootstrapForm("form-search");
        }

        private MvcForm BeginBootstrapForm(string cssClass)
        {
            return this.Html.BeginForm(null, null, FormMethod.Post, new { @class = cssClass });
        }
        #endregion
    }
}
