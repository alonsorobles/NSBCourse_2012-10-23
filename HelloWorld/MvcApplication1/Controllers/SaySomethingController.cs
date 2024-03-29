﻿using System.Globalization;
using System.Web.Mvc;
using Messages;

namespace MvcApplication1.Controllers
{
    public class SaySomethingController : AsyncController
    {
        [AsyncTimeout(50000)]
        public void IndexAsync(string s)
        {
            MvcApplication.Bus.Send<RequestWithResponse>(m => m.SaySomething = "Say 'WebApp'. " + s)
                .Register<int>(
                    response => AsyncManager.Parameters["response"] = response.ToString(CultureInfo.InvariantCulture));
        }

        public ActionResult IndexCompleted(string response)
        {
            return new ContentResult {Content = "Response from server - " + response};
        }
    }
}