using MediatR;
using Microsoft.Extensions.Logging;
using PasswordGenerator.Application.Handlers.Passwords.Responses;
using PasswordGenerator.Application.Validations;
using PasswordGenerator.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PasswordGenerator.Application.Handlers.Passwords
{
	public class CreatePasswordHandler : IRequestHandler<CreatePasswordCommand, CreatePasswordResponse>
    {
        private readonly IPasswordRepository _passwordRepository;
        private readonly ILogger<CreatePasswordHandler> _logger;

        public CreatePasswordHandler(IPasswordRepository passwordRepository, ILogger<CreatePasswordHandler> logger)
        {
            _passwordRepository = passwordRepository;
            _logger = logger;
        }

        public async Task<CreatePasswordResponse> Handle(CreatePasswordCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CreatePasswordCommand: {JsonSerializer.Serialize(command)}");

            var validator = new CreatePasswordCommandValidator(); // Assuming CreatePasswordCommandValidator is your validation class
            var validationResult = validator.Validate(command);

            if (validationResult.IsValid)
            {
                try
                {
                    var passwordSenha = await _passwordRepository.GetByCaracter(command.CaracterNumber);

                    if (passwordSenha != null)
                    {
                        return new CreatePasswordResponse(command.Id, "Password already exists.");
                    }

                    await _passwordRepository.Add(command.GetEntity());
                    return new CreatePasswordResponse(command.Id, validationResult);
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return new CreatePasswordResponse(command.Id, "Unable to process your request.");
                }
            }

            return new CreatePasswordResponse(command.Id, validationResult);
        }
    }

    internal class CreatePasswordCommandValidator
    {
        public CreatePasswordCommandValidator()
        {
        }
    }
}
