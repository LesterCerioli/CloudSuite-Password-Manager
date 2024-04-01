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
            var validationResult = new CreatePasswordCommandValidation().Validate(command);

            if (validationResult.IsValid)
            {
                try
                {
                    var passwordSenha = await _passwordRepository.GetBySenha(command.Senha);
                    if (passwordSenha != null)
                    {
                        return await Task.FromResult(new CreatePasswordResponse(command.Id, "Senha já cadastrados já cadastrado."));
                    }
                    await _passwordRepository.Add(command.GetEntity());
                    return await Task.FromResult(new CreatePasswordResponse(command.Id, validationResult));
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CreatePasswordResponse(command.Id, "It`s not possible to process your solicitation."));
                }
            }

            return await Task.FromResult(new CreatePasswordResponse(command.Id, validationResult));
        }
    }
}
