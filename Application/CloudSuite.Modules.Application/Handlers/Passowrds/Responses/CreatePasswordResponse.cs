﻿using CloudSuite.Modules.Application.Core;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Handlers.Passowrds.Responses
{
	public class CreatePasswordResponse : Response
	{
		public Guid RequestId { get; private set; }

		public CreatePasswordResponse(Guid requestId, ValidationResult result)
		{
			RequestId = requestId;
			foreach (var item in result.Errors)
			{
				this.AddError(item.ErrorMessage);
			}
		}

		public CreatePasswordResponse(Guid requestId, string falhaValidacao)
		{
			RequestId = requestId;
			this.AddError(falhaValidacao);
		}
	}
}
