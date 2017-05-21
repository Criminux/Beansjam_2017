using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GloriousWhale.BeansJam17.Assets.Scripts.Constants;

namespace Assets.Scripts.Constants
{
	/// <summary>
	/// ExtensionDefault - as the <see cref="ExtensionManager"/> uses the values right now - needs to provide one extension for each slot type.
	/// </summary>
	public class ExtensionDefault
	{
		public static IEnumerable<ExtensionDefault> Values
		{
			get
			{
				yield return new ExtensionDefault(ItemType.ThrustTier1);
				yield return new ExtensionDefault(ItemType.WeaponTier1);
				yield return new ExtensionDefault(ItemType.ShieldTier1);
			}
		}
		
		private ItemType item;

		public ExtensionDefault(ItemType item)
		{
			this.item = item;
		}
		public ItemType Item
		{
			get { return item; }
		}
	}
}
