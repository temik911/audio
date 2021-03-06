﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fusion.GIS.DataSystem.GeoObjectsSources;
using Fusion.GIS.DataSystem.MapSources.Projections;
using Fusion.GIS.LayerSpace.Layers;
using Fusion.Graphics;
using Fusion.Input;
using Fusion.Mathematics;


namespace Fusion.GIS
{

	public class LayerService : GameService
	{
		public MapLayer				MapLayer			{ get; protected set; }
		public GlobeLayer			GlobeLayer			{ get; protected set; }
		public GeoObjectsLayer		GeoObjectsLayer		{ get; protected set; }
		public ElevationLayer		ElevationLayer		{ get; protected set; }
		public OpenStreetMapSource	OpenStreetMapSource { get; protected set; }
		public WikiMapiaSource		WikiMapiaSource		{ get; protected set; }

		[Config]
		public LayerServiceConfig Config { set; get; }



		public LayerService(Game game) : base(game)
		{
			Config = new LayerServiceConfig();
		}


		public override void Initialize()
		{
			MapLayer		= new MapLayer(Game, Config);
			//ElevationLayer = new ElevationLayer(Game, Config);
			OpenStreetMapSource = new OpenStreetMapSource(Game, MapLayer);
			//GeoObjectsLayer = new GeoObjectsLayer(Game, Config);
			GlobeLayer		= new GlobeLayer(Game, Config);

			WikiMapiaSource = new WikiMapiaSource(Game, MapLayer);
		}


		public override void Update(GameTime gameTime)
		{
			MapLayer.Update(gameTime);
			GlobeLayer.Update(gameTime);
		}


		public override void Draw(GameTime gameTime, StereoEye stereoEye)
		{
			GlobeLayer.Draw(gameTime);
		}


		public void DrawInRenderTarget(GameTime gameTime, DepthStencil2D ds, RenderTarget2D target, Viewport viewport)
		{			
			GlobeLayer.DrawInRenderTarget(gameTime, ds, target, viewport);
		}


		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				GlobeLayer.Dispose();
				MapLayer.Dispose();
			}
			base.Dispose(disposing);
		}

	}



	public class ConstBufferGeneric<T> : ConstantBuffer where T: struct
	{
		public T Data;

		public ConstBufferGeneric( GraphicsDevice device ) : base( device, typeof(T) )
		{
		}


		public void UpdateCBuffer ()
		{
			SetData( Data );
		}
	}
}
