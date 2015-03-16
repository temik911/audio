﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fusion.GIS.DataSystem.GeoObjectsSources;
using Fusion.GIS.GlobeMath;
using Fusion.Graphics;

#pragma warning disable 612

namespace Fusion.GIS.LayerSpace.Layers
{
    public partial class GlobeLayer
    {
	    List<GeoVert> chartsCPU;
		VertexBuffer chartsVB;


		public void UpdateCharts(List<GeoVert> charts)
		{
			chartsCPU = charts;

			if (chartsVB == null) {
				chartsVB = new VertexBuffer(Game.GraphicsDevice, typeof (GeoVert), chartsCPU.Count);
			}

			if (chartsVB.Capacity != chartsCPU.Count) {
				chartsVB.Dispose();
				chartsVB = new VertexBuffer(Game.GraphicsDevice, typeof(GeoVert), chartsCPU.Count);
			}

			chartsVB.SetData(chartsCPU.ToArray(), 0, chartsCPU.Count);
		}


		public void DrawCharts()
		{
			if (chartsCPU == null) return;

			shader.SetVertexShader((int)(GlobeFlags.DRAW_LINES | GlobeFlags.VERTEX_SHADER | GlobeFlags.USE_GEOCOORDS) );
			shader.SetPixelShader((int)GlobeFlags.DRAW_CHARTS);
			shader.SetGeometryShader((int)GlobeFlags.DRAW_CHARTS);

			Game.GraphicsDevice.BlendState			=	BlendState.Opaque;
			Game.GraphicsDevice.DepthStencilState	=	DepthStencilState.Default;

			
			Game.GraphicsDevice.VertexShaderConstants[1]	= dotsBuf;
			Game.GraphicsDevice.GeometryShaderConstants[1]	= dotsBuf;

			Game.GraphicsDevice.RasterizerState	= RasterizerState.CullCW;


			var VertInLayout	= new VertexInputLayout( Game.GraphicsDevice, typeof(GeoVert) );
			Game.GraphicsDevice.SetupVertexInput( VertInLayout, chartsVB, null );
			Game.GraphicsDevice.Draw(Primitive.PointList, chartsVB.Capacity, 0);

			Game.GraphicsDevice.GeometryShader = null;
		}

    }
}
