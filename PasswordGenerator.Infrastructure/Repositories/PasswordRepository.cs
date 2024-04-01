using Microsoft.EntityFrameworkCore;
using PasswordGenerator.Domain.Contracts;
using PasswordGenerator.Domain.Models;
using PasswordGenerator.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator.Infrastructure.Repositories
{
	public class PasswordRepository : IPasswordRepository
	{
		protected readonly PasswordDbContext Db;
		protected readonly DbSet<Password> DbSet;


		public PasswordRepository(PasswordDbContext context)
		{
			Db = context;
			DbSet = context.Passwords;
		}

		

		public async Task Add(Password password)
		{
			await Task.Run(() =>
			{
				DbSet.Add(password);
				Db.SaveChangesAsync();
			});
		}

		public async Task<Password> GetByCaracter(int? caracterNumber)
		{
			return await DbSet.FirstOrDefaultAsync(a => a.CaracterNumber == caracterNumber);
		}

		public async Task<Password> GetByDate(DateTimeOffset? createdOn)
		{
			return await DbSet.FirstOrDefaultAsync(a => a.CreatedOn == createdOn);
		}

		public async Task<IEnumerable<Password>> GetList()
		{
			return await DbSet.ToListAsync();
		}

        public async Task<Password> GetBySenha(string senha)
        {
            return await DbSet.FirstOrDefaultAsync(a => a.Senha == senha);
        }

        public void Remove(Password password)
		{
			DbSet?.Remove(password);
		}

		public void Update(Password password)
		{
			DbSet.Update(password);
		}

		public void Dispose()
		{
			Db.Dispose();
		}

        
    }
}
