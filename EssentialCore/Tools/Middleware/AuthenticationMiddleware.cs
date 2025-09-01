using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Security.Service;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialCore.Tools.Middleware
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public IUserService userService { get; set; }

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;

            this.userService = new UserService();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var userName = context.User.Identity.Name;

            UserCredit userCredit = null;

            if (!string.IsNullOrEmpty(userName))
            {
                var userCreditResult = this.userService.RetrieveByUserName(userName);

                userCredit = userCreditResult.Result.IsSucceeded ? userCreditResult.Result.Data : null;
            }

            context.Items.Add("userCredit", userCredit);

            // Call the next delegate/middleware in the pipeline.
            await _next(context);
        }
    }
}
