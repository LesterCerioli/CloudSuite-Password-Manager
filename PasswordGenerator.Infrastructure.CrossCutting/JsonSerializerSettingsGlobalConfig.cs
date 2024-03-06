using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace PasswordGenerator.Infrastructure.CrossCutting
{
	public static class JsonSerializerSettingsGlobalConfig
	{
		public static JsonSerializerOptions Settings { get; } = new JsonSerializerOptions
		{
			PropertyNameCaseInsensitive = true,
			PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
			NumberHandling = JsonNumberHandling.AllowReadingFromString,
			DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
			Converters = {

				new JsonStringEnumConverter(JsonNamingPolicy.CamelCase, allowIntegerValues: false) }
		};
	}
}
