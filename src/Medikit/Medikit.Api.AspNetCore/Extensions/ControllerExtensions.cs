﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Medikit.Api.AspNetCore.Extensions
{
    public static class ControllerExtensions
    {
        public static IActionResult ToError(this Controller controller, ICollection<KeyValuePair<string, string>> errors, HttpStatusCode statusCode, HttpRequest request)
        {
            var problemDetails = new ValidationProblemDetails
            {
                Instance = request.Path,
                Status = (int)statusCode,
                Detail = "Please refer to the errors property for additional details."
            };
            foreach (var kvp in errors.GroupBy(e => e.Key))
            {
                problemDetails.Errors.Add(kvp.Key, kvp.Select(s => s.Value).ToArray());
            }

            return new BadRequestObjectResult(problemDetails)
            {
                StatusCode = (int)statusCode
            };
        }
    }
}
