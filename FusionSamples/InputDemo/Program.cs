﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Fusion;
using Fusion.Mathematics;

namespace InputDemo {
	class Program {
		
		[STAThread]
		static void Main ( string[] args )
		{
			Trace.Listeners.Add( new ColoredTraceListener() );

			using ( var game = new InputDemo() ) {
				if (Fusion.Development.DevCon.Prepare(game, @"..\..\..\Content\Content.xml", "Content")) {
					game.Run(args);
				}
			}
		}
	}
}
