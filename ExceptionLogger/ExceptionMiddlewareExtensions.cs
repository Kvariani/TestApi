﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;
using Serilog.Formatting;
using System.Collections.Generic;
using System.Linq;

namespace PersonDirectory.Api.Extensions
{
    public static partial class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, IConfiguration Configuration)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File("Log.txt")
                .WriteTo.MSSqlServer(Configuration.GetConnectionString("DefaultConnection"), tableName: "ExceptionLog", autoCreateSqlTable: true)
                .CreateLogger();

            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}