﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX;
using SharpDX.Direct3D;
using SharpDX.Direct3D11;
using SharpDX.Windows;
using SharpDX.DXGI;
using D3D = SharpDX.Direct3D11;
using DXGI = SharpDX.DXGI;
using Drawing = System.Drawing;
using Forms = System.Windows.Forms;
using NvApiWrapper;
using Device = SharpDX.Direct3D11.Device;
using System.IO;
using Fusion.Graphics;
using Fusion.Graphics.Display;
using Fusion.Mathematics;


namespace Fusion.Graphics {

	public class GraphicsResource : DisposableBase {

		/// <summary>
		/// Gets the GraphicsDevice associated with this GraphicsResource.
		/// </summary>
		public GraphicsDevice GraphicsDevice {
			get {
				return device;
			}
		}				


		protected readonly GraphicsDevice device;


		/// <summary>
		/// 
		/// </summary>
		/// <param name="device"></param>
		public GraphicsResource ( GraphicsDevice device )
		{
			this.device	=	device;
		}



		/// <summary>
		/// 
		/// </summary>
		/// <param name="disposing"></param>
		protected override void Dispose ( bool disposing )
		{
			base.Dispose( disposing );
		}
	}
}
