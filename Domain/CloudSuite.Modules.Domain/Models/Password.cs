using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Models
{
	public class Password : Entity, IAggregateRoot
	{
		public Password(int? sizePassword, string? generatedPassword)
		{
			SizePassword = sizePassword;
			GeneratedPassword = generatedPassword;
		}

		public int? SizePassword { get; private set; }

        public string? GeneratedPassword { get; private set; }
    }
}
