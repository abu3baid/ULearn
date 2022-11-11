﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotificationsFactory.cs" company="JustProtect">
//   Copyright (C) 2017. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using CSVWorker.Notifications.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace CSVWorker.Notifications.Factory
{
    public static class NotificationsFactory
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddScoped<IEmailSender, EmailSender>();
        }
    }
}