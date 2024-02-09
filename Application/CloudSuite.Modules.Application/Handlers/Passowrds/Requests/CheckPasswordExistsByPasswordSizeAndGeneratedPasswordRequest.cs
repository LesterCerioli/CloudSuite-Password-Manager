using CloudSuite.Modules.Application.Handlers.Passowrds.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Handlers.Requests
{
	public class CheckPasswordExistsByPasswordSizeAndGeneratedPasswordRequest : IRequest<CheckPasswordExistsByPasswordSizeAndGeneratedPasswordResponse>
	{
		public CheckPasswordExistsByPasswordSizeAndGeneratedPasswordRequest(string? generatedpassword, int? sizePassword)
		{
			GeneratedPassword = generatedpassword;
			SizePassword = sizePassword;
		}

		public Guid Id { get; private set; }

        public string? GeneratedPassword { get; set; }

		public int? SizePassword { get; set; }

		
	}
}
