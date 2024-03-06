using Microsoft.Extensions.DependencyInjection;
using PasswordGenerator.Application.Services.Contracts;
using PasswordGenerator.Application.Services.Implementations;
using PasswordGenerator.Domain.Contracts;
using PasswordGenerator.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator.Infrastructure.CrossCutting
{
	public class NativeInjectorBootStrapper
	{
		public static void RegisterServices(IServiceCollection services)
		{
			services.AddScoped<IPasswordRepository>();
			services.AddScoped<PasswordDbContext>();

			services.AddScoped<IPasswordAppService, PasswordAppService>();
		}
	}
}
