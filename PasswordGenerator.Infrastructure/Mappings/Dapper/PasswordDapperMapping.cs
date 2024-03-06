using Dapper;
using PasswordGenerator.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator.Infrastructure.Mappings.Dapper
{
	public class PasswordDapperMapping
	{
		private readonly IDbConnection _connection;

		public PasswordDapperMapping(IDbConnection connection)
		{
			_connection = connection;
		}

		public async Task<IEnumerable<Password>> GetAllPasswordAsync()
		{
			var query = @"
				SELECT
					Id,
					Caracter,
					CreateOn
				FROM
					Passwords";
			return await _connection.QueryAsync<Password>(query);
		}

		

	}
}
