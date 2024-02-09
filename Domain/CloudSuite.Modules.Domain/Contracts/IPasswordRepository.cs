using CloudSuite.Modules.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Contracts
{
	public interface IPasswordRepository
	{
		Task<Password> GetBySizePassword(int sizePassword);

		Task<Password> GetByGeneratedPassword(string generatedPassword);

		Task Add(Password password);

		void Update(Password password);

		void Remove(Password password);
		Task<bool> GetBySizePassword(int? sizePassword);
	}
}
