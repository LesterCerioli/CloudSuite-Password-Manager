using PasswordGenerator.Application.Handlers.Passwords;
using PasswordGenerator.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator.Application.Services.Contracts
{
	public interface IPasswordAppService
	{
		Task<PasswordViewModel> GetByCaracter(int? caracterNumber);

		Task<PasswordViewModel> GetByDate(DateTimeOffset? createdOn);

		Task SaveAsync(CreatePasswordCommand commandCreate);
	}
}
