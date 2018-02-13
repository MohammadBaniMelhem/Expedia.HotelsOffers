using Expedia.CodingExercise.DataType.Models;
using Expedia.CodingExercise.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Expedia.CodingExercise.DataType.Models.JSONResult;

namespace Expedia.CodingExercise.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        public JSONResult JSONResult;
        private List<string> ErrorMessages;

        public void AddErrorMessage(eResponseCode responseCode)
        {
            if (ErrorMessages == null)
                ErrorMessages = new List<string>();
            ErrorMessages.Add(responseCode.Message());
        }
        public void AddErrorMessage(string message)
        {
            if (ErrorMessages == null)
                ErrorMessages = new List<string>();
            ErrorMessages.Add(message);
        }
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            ErrorMessages = null;
            base.Initialize(requestContext);
        }
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            ModelState.Clear();
            if (ErrorMessages != null && ErrorMessages.Count() > 0)
            {
                if (Request.IsAjaxRequest())
                {
                    Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                    filterContext.Result = new JsonResult()
                    {
                        ContentType = "application/json",
                        Data = new { Message = ErrorMessages.ToSingleLine() },
                    };
                    filterContext.ExceptionHandled = true;
                    filterContext.HttpContext.Response.StatusCode = 500;
                    filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
                }
                else
                {
                    TempData["Message"] = ErrorMessages.ToSingleLine();
                    filterContext.Controller.ViewData.Model = null;
                    filterContext.Result = new ViewResult
                    {
                        ViewName = "Error",
                        MasterName = "_Layout",
                        ViewData = this.ViewData,
                        TempData = filterContext.Controller.TempData,
                        ViewEngineCollection = null

                    };
                    filterContext.ExceptionHandled = true;
                }
            }

            base.OnActionExecuted(filterContext);
        }
        public void AddValidationError(string Message)
        {
            if (ErrorMessages == null)
                ErrorMessages = new List<string>();
            ErrorMessages.Add(Message);
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            AddValidationError(eResponseCode.General_Error.Message());

            if (Utilities.GetConfigurationValue("Expedia.CodingExercise.ShowOriginalException", false))
            {
                ErrorMessages[0] = filterContext.Exception.Message;
                if (filterContext.Exception.InnerException != null)
                    ErrorMessages[0] += filterContext.Exception.InnerException.Message;
            }
            if (Request.IsAjaxRequest())
            {
                JSONResult.Message.Text = ErrorMessages[0];
                JSONResult.Message.Type = ResultMessageType.Warning.ToString();
                Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                filterContext.Result = new JsonResult()
                {
                    ContentType = "application/json",
                    Data = JSONResult,
                };
                filterContext.ExceptionHandled = true;
                filterContext.HttpContext.Response.StatusCode = 500;
                filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
            }
            else
            {
                TempData["Message"] = ErrorMessages[0];
                filterContext.Controller.ViewData.Model = null;
                filterContext.Result = new ViewResult
                {
                    ViewName = "Error",
                    MasterName = "_Layout",
                    ViewData = this.ViewData,
                    TempData = filterContext.Controller.TempData,
                    ViewEngineCollection = null

                };
                filterContext.ExceptionHandled = true;
            }

            base.OnException(filterContext);
        }
        protected override IAsyncResult BeginExecute(System.Web.Routing.RequestContext requestContext, AsyncCallback callback, object state)
        {
            JSONResult = new JSONResult();
            return base.BeginExecute(requestContext, callback, state);
        }
    }
}