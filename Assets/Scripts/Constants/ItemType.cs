using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Constants
{
	public class ItemType
	{

		public static readonly ItemType WeaponTier1 = new ItemType("weapon_tier_1", "Weapon Alpha", 10);
		public static readonly ItemType WeaponTier2 = new ItemType("weapon_tier_2", "Weapon Beta", 25);
        public static readonly ItemType WeaponTier3 = new ItemType("weapon_tier_3", "Weapon Gamma", 50);

        public static readonly ItemType ThrustTier1 = new ItemType("thrust_tier_1", "Thruster Alpha", 10);
        public static readonly ItemType ThrustTier2 = new ItemType("thrust_tier_2", "Thruster Beta", 25);
        public static readonly ItemType ThrustTier3 = new ItemType("thrust_tier_3", "Thruster Gamma", 50);

        public static readonly ItemType ShieldUpgrade = new ItemType("shield_upgrade", "Shield Upgrade", 25);

        public static readonly ItemType Asteroid_Material = new ItemType("asteroid_material", "Asteroid Material", 1);
        
        public static IEnumerable<ItemType> Values
		{
			get
			{
				yield return WeaponTier1;
				yield return WeaponTier2;
                yield return ThrustTier1;
                yield return ThrustTier2;
                yield return Asteroid_Material;
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
