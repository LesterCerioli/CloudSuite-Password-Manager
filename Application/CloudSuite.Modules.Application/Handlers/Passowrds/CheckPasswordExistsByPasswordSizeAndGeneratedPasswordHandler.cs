using CloudSuite.Modules.Application.Handlers.Passowrds.Responses;
using CloudSuite.Modules.Application.Handlers.Requests;
using CloudSuite.Modules.Application.Validations.Passwords;
using CloudSuite.Modules.Domain.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Handlers.Passowrds
{
	public class CheckPasswordExistsByPasswordSizeAndGeneratedPasswordHandler : IRequestHandler<CheckPasswordExistsByPasswordSizeAndGeneratedPasswordRequest, CheckPasswordExistsByPasswordSizeAndGeneratedPasswordResponse>
	{
		private readonly IPasswordRepository _passwordRepository;
		private readonly ILogger<CheckPasswordExistsByPasswordSizeAndGeneratedPasswordHandler> _logger;

		public CheckPasswordExistsByPasswordSizeAndGeneratedPasswordHandler(IPasswordRepository passwordRepository, ILogger<CheckPasswordExistsByPasswordSizeAndGeneratedPasswordHandler> logger)
		{
			_passwordRepository = passwordRepository;
			_logger = logger;

		}

		public async Task<CheckPasswordExistsByPasswordSizeAndGeneratedPasswordResponse> Handle(CheckPasswordExistsByPasswordSizeAndGeneratedPasswordRequest request, CancellationToken cancellationToken)
		{
			_logger.LogInformation($"CheckPasswordExistsByPasswordSizeAndGeneratedPasswordRequest:{JsonSerializer.Serialize(request)}");
			var validationResult = new CheckPasswordExistsByPasswordSizeAndGeneratedPasswordRequestValidation().Validate(request);

			if (validationResult.IsValid)
			{
				try
				{
					var sizePassword = await _passwordRepository.GetBySizePassword(request.SizePassword);
					var generatedPassword = await _passwordRepository.GetByGeneratedPassword(request.GeneratedPassword);
					if (sizePassword && generatedPassword != null)
					{
						return await Task.FromResult(new CheckPasswordExistsByPasswordSizeAndGeneratedPasswordResponse(request.Id, true, validationResult));
					}
				}
				catch (Exception ex)
				{
					_logger.LogCritical(ex.Message);
					return await Task.FromResult(new CheckPasswordExistsByPasswordSizeAndGeneratedPasswordResponse(request.Id, "Failed to process the request."));
				}
			}

			return await Task.FromResult(new CheckPasswordExistsByPasswordSizeAndGeneratedPasswordResponse(request.Id, false, validationResult));
		}
	}
}
