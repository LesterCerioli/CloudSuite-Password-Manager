using AutoMapper;
using NetDevPack.Mediator;
using PasswordGenerator.Application.Handlers.Passwords;
using PasswordGenerator.Application.Services.Contracts;
using PasswordGenerator.Application.ViewModels;
using PasswordGenerator.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator.Application.Services.Implementations
{
	public class PasswordAppService : IPasswordAppService
	{
		private readonly IPasswordRepository _passwordRepoisitory;
		private readonly IMediatorHandler _mediator;
		private readonly IMapper _mapper;

		public PasswordAppService(
			IPasswordRepository passwordRepository,
			IMediatorHandler mediator,
			IMapper mapper)
		{
			_passwordRepoisitory = passwordRepository;
			_mediator = mediator;
			_mapper = mapper;
		}


		public async Task<PasswordViewModel> GetByCaracter(int? caracterNumber)
		{
			return _mapper.Map<PasswordViewModel>(await _passwordRepoisitory.GetByCaracter(caracterNumber));
		}

		public async Task<PasswordViewModel> GetByDate(DateTimeOffset? createdOn)
		{
			return _mapper.Map<PasswordViewModel>(await _passwordRepoisitory.GetByDate(createdOn));
		}


		public async Task<string> GerarSenha()
		{
			const string caracteresPermitidos = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+{}[]<>?:;/";
			Random rnd = new Random();
			char[] senha = new char[24]; // Generaete a password with 24 characters

			for (int i = 0; i < 24; i++)
			{
				senha[i] = caracteresPermitidos[rnd.Next(caracteresPermitidos.Length)];
			}

			string senhaGerada = new string(senha);
			return senhaGerada;

			Console.WriteLine($"Senha gerada: {senhaGerada}");
		}

		public void Dispose()
		{
			GC.SuppressFinalize(this);
		}

		public async Task SaveAsync(CreatePasswordCommand commandCreate)
		{
			await _passwordRepoisitory.Add(commandCreate.GetEntity());
		}
	}
}
