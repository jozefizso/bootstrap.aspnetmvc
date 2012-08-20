using System;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Twitter.Bootstrap.Mvc
{
    public class BootstrapHelper<TModel> : BootstrapHelper
    {
        public BootstrapHelper(HtmlHelper<TModel> htmlHelper)
            : base(htmlHelper)
        {
            this.Html = htmlHelper;
        }

        public new HtmlHelper<TModel> Html { get; set; }

        public IHtmlString LabelFor<TValue>(Expression<Func<TModel, TValue>> expression)
        {
            return this.Html.LabelFor(expression);
        }

        public IHtmlString TextBoxFor<TValue>(Expression<Func<TModel, TValue>> expression)
        {
            return this.TextBoxFor(expression, null);
        }

        public IHtmlString TextBoxFor<TValue>(Expression<Func<TModel, TValue>> expression, string placeholderText)
        {
            if (placeholderText == null)
            {
                ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, this.Html.ViewData);
                if (metadata.AdditionalValues.ContainsKey("placeholder"))
                    placeholderText = (string)metadata.AdditionalValues["placeholder"];
            }

            return this.Html.TextBoxFor(expression, new { placeholder = placeholderText });
        }

        public IHtmlString CheckBoxFor(Expression<Func<TModel, bool>> expression, string labelText = null)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, this.Html.ViewData);
            string resolvedLabelText = labelText ?? metadata.DisplayName ?? metadata.PropertyName;
            if (String.IsNullOrEmpty(resolvedLabelText))
            {
                return MvcHtmlString.Empty;
            }

            IHtmlString checkbox = this.Html.CheckBoxFor(expression);

            TagBuilder label = new TagBuilder("label");
            label.AddCssClass("checkbox");
            label.InnerHtml = checkbox.ToString() + " " + resolvedLabelText;

            return label.ToHtmlString();
        }

        public IHtmlString TextBoxWithLabelFor<TValue>(Expression<Func<TModel, TValue>> expression)
        {
            TagBuilder outer = new TagBuilder("div");
            outer.AddCssClass("control-group");
            if (ValidationExtensions.HasModelError(this.Html, expression))
            {
                outer.AddCssClass("error");
            }

            outer.InnerHtml = this.LabelFor(expression) + "\n"
                            + this.TextBoxFor(expression) + "\n"
                            + this.ValidationMessageFor(expression);

            return outer.ToHtmlString();
        }
    }
}
