using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordGenerator.Application.Core;
using FluentValidation.Results;

namespace PasswordGenerator.Application.Handlers.Passwords.Responses
{
	public class CheckPasswordExistsBySenhaResponse : Response
	{
		public Guid RequestId {get; private set;}

		public bool Exists { get; set; }

		public CheckPasswordExistsBySenhaResponse(Guid requestId, bool exists, ValidationResult result)
		{
			RequestId = requestId;
            Exists = exists;
            foreach (var item in result.Errors)
            {
                this.AddError(item.ErrorMessage);
            }

		}

		public CheckPasswordExistsBySenhaResponse(Guid requestId, string failValidation)
		{
			RequestId = requestId;
            Exists = false;
            this.AddError(failValidation);
		}

	}
}


