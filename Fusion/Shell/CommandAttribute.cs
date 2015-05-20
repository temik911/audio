﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fusion.Shell {
	
	/// <summary>
	/// Shell command attribute
	/// </summary>
	public sealed class CommandAttribute : Attribute {

		/// <summary>
		/// Command name
		/// </summary>
		public string Name { get; private set; }


		/// <summary>
		///
		/// </summary>
		/// <param name="name"></param>
		public CommandAttribute ( string name )
		{
			this.Name = name;
		}

	}
}