using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GloriousWhale.BeansJam17.Assets.Scripts.Constants
{
	public class ItemType
	{

		public static readonly ItemType WeaponTier1 = new ItemType("weapon_tier_1", "Weapon Alpha", 10, SlotType.Weapon);
		public static readonly ItemType WeaponTier2 = new ItemType("weapon_tier_2", "Weapon Beta", 25, SlotType.Weapon);
        public static readonly ItemType WeaponTier3 = new ItemType("weapon_tier_3", "Weapon Gamma", 50, SlotType.Weapon);

        public static readonly ItemType ThrustTier1 = new ItemType("thrust_tier_1", "Stock Thruster", 10, SlotType.Thruster);
        public static readonly ItemType ThrustTier2 = new ItemType("thrust_tier_2", "Upgraded Thruster", 25, SlotType.Thruster);
        public static readonly ItemType ThrustTier3 = new ItemType("thrust_tier_3", "Fusion Thruster", 50, SlotType.Thruster);

		public static readonly ItemType ShieldTier1 = new ItemType("shield_tier_1", "Shield", 20, SlotType.Shield);
        public static readonly ItemType ShieldTier2 = new ItemType("shield_tier_2", "Super Shield", 25, SlotType.Shield);

        public static readonly ItemType Asteroid_Material = new ItemType("asteroid_material", "Asteroid Material", 1, SlotType.None);
        
        public static IEnumerable<ItemType> Values
		{
			get
			{
				yield return WeaponTier1;
				yield return WeaponTier2;
				yield return WeaponTier3;

                yield return ThrustTier1;
                yield return ThrustTier2;
				yield return ThrustTier3;

				yield return ShieldTier2;

                yield return Asteroid_Material;
            }
		}

		private readonly String identifier;
		private readonly String displayName;
		private readonly int size;
		private readonly SlotType slotType;

		private ItemType(string identifier, string displayName, int size, SlotType slotType)
		{
			this.identifier = identifier;
			this.displayName = displayName;
			this.size = size;
			this.slotType = slotType;
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

		public SlotType SlotType
		{
			get { return slotType; }
		}
	}
}
