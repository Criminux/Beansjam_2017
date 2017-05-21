using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.GameObjects;
using GloriousWhale.BeansJam17.Assets.Scripts.Constants;
using UnityEngine;
using UnityEngine.UI;


namespace GloriousWhale.BeansJam17.Assets.Scripts.Gui
{
	public class ExtensionDropdownController : MonoBehaviour
	{

		[SerializeField]
		private SlotMapping slot;

		private Dropdown dropdown;
		private ExtensionManager playerExtensionManager;
		private CargoHold playerCargoHold;


		// Use this for initialization
		void Start()
		{
			dropdown = GetComponent<Dropdown>();
			dropdown.onValueChanged.AddListener(OnDropdownSelect);

			var player = GameObject.FindGameObjectWithTag(Tags.Player);
			playerCargoHold = player.GetComponent<CargoHold>();
			playerExtensionManager = player.GetComponent<ExtensionManager>();
		}

		private void OnDropdownSelect(int index)
		{
			var selectedDisplayname = dropdown.options[index].text;
			var selectedType = ItemType.Values.First(type => type.DisplayName == selectedDisplayname);
			playerExtensionManager.Equip(selectedType);
		}

		public void Refresh()
		{
			dropdown.ClearOptions();
			var type = TypeForMapping(slot);

			var optionsForSelectableExtensions = ItemType.Values
				.Where(item => item.SlotType == type)
				.Where(item => playerCargoHold.GetAmountOf(item) > 0)
				.Select(itemType => new Dropdown.OptionData {text = itemType.DisplayName})
				.ToList();

			dropdown.AddOptions(optionsForSelectableExtensions);
		}

		public enum SlotMapping
		{
			SHIELD, THRUSTER, WEAPON
		}

		private static SlotType TypeForMapping(SlotMapping mapping)
		{
			if(mapping == SlotMapping.SHIELD)
				return SlotType.Shield;
			else if(mapping == SlotMapping.THRUSTER)
				return SlotType.Thruster;
			else if(mapping == SlotMapping.WEAPON)
				return SlotType.Weapon;
			else 
				return SlotType.None;
		}
	}

}
