using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace ConsoleApplication1
{
	class Program
	{
		/// <summary>
		/// static instance of a mongo client.  This is threadsafe so should be good here
		/// </summary>
		static MongoClient _mongo;

		static void Main(string[] args)
		{
			var myProgram = new Program();
		}

		static Program()
		{
			//connect to the mongodb server
			_mongo = new MongoClient();
		}

		public Program()
		{
			//connect to our database
			var server = _mongo.GetServer();
			var database = server.GetDatabase("profiling");

			//get the collection we want
			var collection = database.GetCollection<Request>("requests");

			//clean out the database
			collection.RemoveAll();

			//make up a request
			var myRequest = new Request
			{
				Url = "http:\\google.com",
				Ip = "127.0.0.1",
				RequestType = "put",
				PostData = "test",
				UserKey = "Dude",
				Start = DateTime.MinValue,
				End = DateTime.MaxValue,
				Actions = new List<Action>()
			};

			//add an action
			var myAction = new Action()
			{
				Type = "action type1",
				Name = "action name1",
				Start = DateTime.MinValue,
				End = DateTime.Now,
				Actions = new List<Action>()
			};

			myRequest.Actions.Add(myAction);

			//add some sub-actions
			for (int i = 0; i < 3; i++)
			{
				myAction.Actions.Add(new Action()
				{
					Type = "action type" + i.ToString(),
					Name = "action name" + i.ToString(),
					Start = DateTime.MinValue,
					End = DateTime.Now,
					Actions = new List<Action>()
				});
			}

			//let's give him to mongoooo
			collection.Save(myRequest);
		}
	}
}
