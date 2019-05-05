using System.Threading.Tasks;


using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Runtime.Serialization;

using ReLogic.Graphics;

using Terraria;
using Terraria.UI;
using Terraria.ID;
using Terraria.IO;
using Terraria.GameInput;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.Localization;
using Terraria.ModLoader.IO;
using Terraria.GameContent.UI;
using Terraria.DataStructures;
using Terraria.Graphics.Effects;
using Terraria.GameContent.Dyes;
using Terraria.Graphics.Shaders;
using Terraria.World.Generation;
using Terraria.GameContent.Generation;
//using Terraria.ModLoader.Config;
//using Terraria.ModLoader.Config.UI;


namespace omnishot
{
	public class omnishot : Mod
	{
		public static ModHotKey ST;
		
		public override void Load()
		{
			ST = RegisterHotKey("Switch ammo types", "G");
		}
		
		public override void Unload()
		{
			ST = null;
		}
	}
	
	public class Text : ModPlayer
	{
		public static int ammoType;
		/*public static bool switchTypes;
		
		public override void SetControls()
		{
			if (omnishot.ST.JustPressed)
			{
				if (switchTypes)
				{
					switchTypes = false;
				} else {
					switchTypes = true;
				}
			}
			if (omnishot.ST.JustReleased)
				switchTypes = false;
		}*/
	}
	
	public class AmmoSwitcher : GlobalItem
	{
		public override void UpdateInventory(Item item, Player player)
		{
			if (item.ammo != AmmoID.None)
				if (Text.ammoType != AmmoID.None)
					item.ammo = Text.ammoType;
		}
				/*if (item.ammo == AmmoID.Arrow)
				{
					item.ammo = AmmoID.Bullet;
				} else if (item.ammo == AmmoID.Bullet)
				{
					item.ammo = AmmoID.Dart;
				} else if (item.ammo == AmmoID.Dart)
				{
					item.ammo = AmmoID.Solution;
				} else if (item.ammo == AmmoID.Solution)
				{
					item.ammo = AmmoID.Gel;
				} else if (item.ammo == AmmoID.Gel)
				{
					item.ammo = AmmoID.Arrow;
				}*/
		
			public override void HoldItem(Item item, Player player)
			{
				float a = item.useAmmo;
				//if (item.useAmmo = AmmoID.Bullet)
					//item.useAmmo = AmmoID.Bullet
				if (a != AmmoID.None)
					Text.ammoType = item.useAmmo;
			}

		public override void PostDrawInInventory
		(
			Item item,
			SpriteBatch spriteBatch,
			Vector2 position,
			Rectangle frame,
			Color drawColor,
			Color itemColor,
			Vector2 origin,
			float scale
		)
		{
			drawColor = Color.White;
			Vector2 pos = position - new Vector2(5,5);
			Texture2D texture = Terraria.ModLoader.ModLoader.GetTexture("omnishot/NotAmmo");
			if (item.ammo == AmmoID.Arrow)
				texture = Terraria.ModLoader.ModLoader.GetTexture("omnishot/Wooden_Arrow");
			
			Rectangle sourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
			origin = sourceRectangle.Size() / 2f;
			
			Main.spriteBatch.Draw
			(
				texture, 
				pos + new Vector2
				(
					0f,
					0f
				), 
				sourceRectangle,
				drawColor * (1/2),
				0f,
				origin, 
				.5f,
				SpriteEffects.None,
				0f
			);
		}
	}
}