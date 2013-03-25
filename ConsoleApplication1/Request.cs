﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
	public class Request
	{
		public Guid Id { get; set; }
		public string Url { get; set; }
		public string Ip { get; set; }
		public string RequestType { get; set; }
		public string PostData { get; set; }
		public string UserKey { get; set; }
		public IList<Action> Actions { get; set; }
		public DateTime Start { get; set; }
		public DateTime End { get; set; }
	}
}
