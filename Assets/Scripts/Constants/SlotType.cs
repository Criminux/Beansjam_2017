using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GloriousWhale.BeansJam17.Assets.Scripts.Constants
{
	public class SlotType
	{
		public static readonly SlotType None = new SlotType("none", "none");
		public static readonly SlotType Weapon = new SlotType("weapon", "Weapon");
		public static readonly SlotType Thruster = new SlotType("thruster", "Thruster");
		public static readonly SlotType Shield = new SlotType("shield", "Shield");


		public static IEnumerable<SlotType> Values
		{
			get
			{
				yield return None;
				yield return Weapon;
				yield return Thruster;
				yield return Shield;
			}
		}

		private readonly string identifier;
		private readonly string displayName;

		private SlotType(string identifier, string displayName)
		{
			this.identifier = identifier;
			this.displayName = displayName;
		}

		public string Identifier
		{
			get { return identifier; }
		}

		public string DisplayName
		{
			get { return displayName; }
		}
	}
}
