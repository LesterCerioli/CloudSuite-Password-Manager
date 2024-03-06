using MediatR;
using PasswordGenerator.Application.Handlers.Passwords.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator.Application.Handlers.Passwords
{
	public class CreatePasswordHandler : IRequestHandler<CreatePasswordCommand, CreatePasswordResponse>
	{
		public async Task<CreatePasswordResponse> Handle(CreatePasswordCommand request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
