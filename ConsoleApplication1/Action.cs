using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
	public class Action
	{
		public IList<Action> Actions { get; set; }
		public string Type { get; set; }
		public string Name { get; set; }
		public DateTime Start { get; set; }
		public DateTime End { get; set; }
	}
}
