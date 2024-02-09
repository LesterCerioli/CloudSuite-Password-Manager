using CloudSuite.Modules.Application.Handlers.Passowrds.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Handlers.Passowrds
{
	public class CreatePasswordHandler : IRequestHandler<CreatePasswordCommand, CreatePasswordResponse>
	{
		public async Task<CreatePasswordResponse> Handle(CreatePasswordCommand request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
