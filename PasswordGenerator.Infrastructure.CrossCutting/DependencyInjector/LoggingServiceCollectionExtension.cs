﻿using Microsoft.Extensions.DependencyInjection;
using PasswordGenerator.Infrastructure.CrossCutting.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator.Infrastructure.CrossCutting.DependencyInjector
{
	public static class LoggingServiceCollectionExtension
	{
		public static IServiceCollection AddLogger(this IServiceCollection services)
		{
			var logger = LoggerManager.CreateLogger();
			services.AddSingleton(logger);
			return services;
		}
	}
}
