using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryAutomationSystem.Entity;
using LibraryAutomationSystem.DAL;

namespace LibraryAutomationSystem.App_Start
{
    public class CustomExceptionFilter : FilterAttribute, IExceptionFilter//inherit the filter attribute
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled && filterContext.Exception is NullReferenceException)
            {
                ExceptionLogger logger = new ExceptionLogger()
                {
                    ExceptionMessage = filterContext.Exception.Message,//set the exception message
                    ExceptionStackTrack = filterContext.Exception.StackTrace,//set the exception occured place
                    ControllerName = filterContext.RouteData.Values["controller"].ToString(),//set the control name where excetion occured
                    ActionName = filterContext.RouteData.Values["action"].ToString(),//set the control action name
                    ExceptionLogTime = DateTime.Now//set the exception time when exception ocurred
                };
                using (DBConnection dbConnection = new DBConnection())
                {
                    dbConnection.ExceptionLogger.Add(logger);//add the exception to the database
                    dbConnection.SaveChanges();//update the savechanges
                }

                filterContext.ExceptionHandled = true;
                filterContext.Result = new ViewResult()
                {
                    ViewName = "Error"//if any exception occur==>automatically control transfer to Error handled view
                };
            }
        }
    }
}
