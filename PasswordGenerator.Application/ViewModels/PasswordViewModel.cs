using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator.Application.ViewModels
{
	public class PasswordViewModel
	{
		[Key]
		public Guid Id { get; private set; }

		[DisplayName("Password")]
		public string? Senha { get; set; }

		[DisplayName("Character")]
		[MinLength(24)]
		[Required(ErrorMessage = "A senha deve possuir no mínimo 24 caracteres.")]
		public int? CaracterNumber { get; set; }

		[DisplayName("CreatedOn")]
		public DateTimeOffset? CreatedOn { get; set; }
	}
}
