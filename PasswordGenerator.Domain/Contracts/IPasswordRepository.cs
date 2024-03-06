using PasswordGenerator.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator.Domain.Contracts
{
	public interface IPasswordRepository
	{
		Task<Password> GetByCaracter(int? caracterNumber);

		Task<Password> GetByDate(DateTimeOffset? createdOn);

		Task<IEnumerable<Password>> GetList();

		Task Add(Password password);

		void Update(Password password);

		void Remove(Password password);
	}
}
