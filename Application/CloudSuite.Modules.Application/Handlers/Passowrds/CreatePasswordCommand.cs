using CloudSuite.Modules.Application.Handlers.Passowrds.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordEntity = CloudSuite.Modules.Domain.Models.Password;

namespace CloudSuite.Modules.Application.Handlers.Passowrds
{
	public class CreatePasswordCommand : IRequest<CreatePasswordResponse>
	{
		public Guid Id { get; private set; }

		public int? SizePassword { get; set; }

		public string? GeneratedPassword { get; set; }

		public CreatePasswordCommand()
		{
			Id = Guid.NewGuid();
		}

		public PasswordEntity GetEntity()
		{
			return new PasswordEntity(
				this.SizePassword,
				this.GeneratedPassword);
		}

	}
}
