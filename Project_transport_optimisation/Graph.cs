﻿//using Neo4j.Driver;
using Neo4j.Driver.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_transport_optimisation
{
	class Graph : IDisposable
	{
		private readonly IDriver _driver;

		public Graph(string uri, string user, string password)
		{
			_driver = GraphDatabase.Driver(uri, AuthTokens.Basic(user, password));
		}

		public void PrintGreeting(string message)
		{
			using (var session = _driver.Session())
			{
				var greeting = session.WriteTransaction(tx =>
				{
					var result = tx.Run("CREATE (a:Greeting) " +
					   "SET a.message = $message " +
					   "RETURN a.message + ', from node ' + id(a)",
					new { message });
					return result.Single()[0].As<string>();
				});
				Console.WriteLine(greeting);
			}
		}

		public void Dispose()
		{
			_driver?.Dispose();
		}

		//public static void Main()
		//{
		//	using (var greeter = new Graph("bolt://localhost:7687", "neo4j", "password"))
		//	{
		//		greeter.PrintGreeting("hello, world");
		//	}
		//}
	}
}