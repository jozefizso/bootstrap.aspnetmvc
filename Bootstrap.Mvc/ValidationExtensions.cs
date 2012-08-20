using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace Twitter.Bootstrap.Mvc
{
    public static class ValidationExtensions
    {
        public static IHtmlString ValidationMessageFor<TModel, TProperty>(this BootstrapHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression)
        {
            return ValidationMessageFor(helper, expression, null /* validationMessage */, new RouteValueDictionary());
        }

        public static IHtmlString ValidationMessageFor<TModel, TProperty>(this BootstrapHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, string validationMessage)
        {
            return ValidationMessageFor(helper, expression, validationMessage, new RouteValueDictionary());
        }

        public static IHtmlString ValidationMessageFor<TModel, TProperty>(this BootstrapHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, string validationMessage, object htmlAttributes)
        {
            return ValidationMessageFor(helper, expression, validationMessage, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static IHtmlString ValidationMessageFor<TModel, TProperty>(this BootstrapHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, string validationMessage, IDictionary<string, object> htmlAttributes)
        {
            return ValidationMessageHelper(helper.Html, expression, validationMessage, htmlAttributes);
        }

        private static IHtmlString ValidationMessageHelper<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string validationMessage, IDictionary<string, object> htmlAttributes)
        {
            TagBuilder builder = new TagBuilder("span");
            builder.MergeAttributes(htmlAttributes);
            builder.AddCssClass("help-inline");

            builder.InnerHtml = htmlHelper.ValidationMessageFor(expression).ToString();
            return builder.ToHtmlString();
        }

        internal static bool HasModelError<TModel, TProperty>(HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            string expressionText = ExpressionHelper.GetExpressionText(expression);
            string modelName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(expressionText);

            if (!htmlHelper.ViewData.ModelState.ContainsKey(modelName))
            {
                return false;
            }

            ModelState modelState = htmlHelper.ViewData.ModelState[modelName];
            ModelErrorCollection modelErrors = (modelState == null) ? null : modelState.Errors;
            ModelError modelError = (((modelErrors == null) || (modelErrors.Count == 0)) ? null : modelErrors.FirstOrDefault(m => !String.IsNullOrEmpty(m.ErrorMessage)) ?? modelErrors[0]);

            return (modelError != null);
        }
    }
}
