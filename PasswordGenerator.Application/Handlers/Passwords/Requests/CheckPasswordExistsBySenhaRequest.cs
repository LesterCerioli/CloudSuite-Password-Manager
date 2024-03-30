using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PasswordGenerator.Application.Handlers.Responses;

namespace PasswordGenerator.Application.Handlers.Passwords.Requests
{
	public class CheckPasswordExistsBySenhaRequest : IRequest<CheckPasswordExistsBySenhaResponse>
	{
		public Guid Id {get; private set;}

		public string? Senha { get; set; }

		public CheckPasswordExistsBySenhaRequest(string senha) 
		{
			Id = Guid.NewGuid();
			Senha = senha;

		}
	
	}
}
