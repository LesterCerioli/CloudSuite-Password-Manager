// See https://aka.ms/new-console-template for more information
using System;

namespace GeradorSenhas
{
	class Program
	{
		static void Main(string[] args)
		{
			
			Console.WriteLine("Welcome to Complex Passwirds Management !");
			Console.WriteLine("Quantos caracteres você deseja que a senha tenha?");
			int tamanhoSenha;
			while (!int.TryParse(Console.ReadLine(), out tamanhoSenha) || tamanhoSenha <= 0)
			{
				Console.WriteLine("Por favor, insira um número inteiro positivo válido.");
			}

			string senha = GerarSenha(tamanhoSenha);
			Console.WriteLine($"Sua senha gerada é: {senha}");

			Console.WriteLine("\nPressione qualquer tecla para sair.");
			Console.ReadKey();
		}

		static string GerarSenha(int tamanho)
		{
			const string caracteresPermitidos = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+{}[]<>?:;/";
			Random rnd = new Random();
			char[] senha = new char[tamanho];

			for (int i = 0; i < tamanho; i++)
			{
				senha[i] = caracteresPermitidos[rnd.Next(caracteresPermitidos.Length)];
			}

			return new string(senha);
		}
	}
}