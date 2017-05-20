using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Constants
{
	public class ItemType
	{

		public static readonly ItemType WeaponTier1 = new ItemType("weapon_tier_1", "Weapon Alpha", 5);
		public static readonly ItemType WeaponTier2 = new ItemType("weapon_tier_2", "Weapon Beta", 5);

		public static IEnumerable<ItemType> Values
		{
			get
			{
				yield return WeaponTier1;
				yield return WeaponTier2;
			}
		}

		private readonly String identifier;
		private readonly String displayName;
		private readonly int size;

		private ItemType(string identifier, string displayName, int size)
		{
			this.identifier = identifier;
			this.displayName = displayName;
			this.size = size;
		}

		public string Identifier
		{
			get { return identifier; }
		}

		public string DisplayName
		{
			get { return displayName; }
		}

		public int Size
		{
			get { return size; }
		}
	}
}
