using MediatR;
using PasswordGenerator.Application.Handlers.Passwords.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordEntity = PasswordGenerator.Domain.Models.Password;

namespace PasswordGenerator.Application.Handlers.Passwords
{
	public class CreatePasswordCommand : IRequest<CreatePasswordResponse>
	{

        public Guid Id { get; private set; }

		public string? Senha { get; set; }

		public int? CaracterNumber { get; set; }

		public DateTimeOffset? CreatedOn { get; set; }

		public CreatePasswordCommand()
		{
			Id = Guid.NewGuid();
		}

		public PasswordEntity GetEntity()
		{
			return new PasswordEntity(
				this.CaracterNumber,
				this.Senha,
				this.CreatedOn);
		}
	}
}
