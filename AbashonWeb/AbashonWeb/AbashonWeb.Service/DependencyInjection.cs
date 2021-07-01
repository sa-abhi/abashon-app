using AbashonWeb.Domain.Auth;
using AbashonWeb.Domain.Common;
using AbashonWeb.Domain.Settings;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Reflection;
using System.Text;

namespace AbashonWeb.Service
{
    public static class DependencyInjection
    {
        public static void AddServiceLayer(this IServiceCollection services)
        {            
            services.AddMediatR(Assembly.GetExecutingAssembly());            
        }
    }
}

