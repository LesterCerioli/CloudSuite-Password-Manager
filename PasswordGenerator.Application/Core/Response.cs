﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator.Application.Core
{
	public class Response
	{
		private readonly IList<string> _messages = new List<string>();

		public IEnumerable<string> Errors { get; }
		public object Result { get; }

		public Response() => Errors = new ReadOnlyCollection<string>(_messages);

		public Response(object result) : this() => Result = result;

		public Response AddError(string message)
		{
			_messages.Add(message);
			return this;
		}
	}
}
