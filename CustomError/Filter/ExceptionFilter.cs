using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomError.Filter
{
    public class ExceptionFilter:ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            ViewResult results = new ViewResult();
            results.ViewName = "/Views/Shared/ErrorMessage.cshtml";
            results.ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(),new ModelStateDictionary());
            results.ViewData.Model = context.Exception;
            results.ViewData["Controller"] = context.RouteData.Values["controller"];
            results.ViewData["Action"] = (string)context.RouteData.Values["action"];
            context.Result = results;
            context.ExceptionHandled = true;
        }
    }
}
