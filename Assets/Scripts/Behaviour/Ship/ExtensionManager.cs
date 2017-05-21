using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Constants;
using GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.GameObjects;
using GloriousWhale.BeansJam17.Assets.Scripts.Constants;
using UnityEngine;

public class ExtensionManager : MonoBehaviour
{

	private Dictionary<SlotType, ItemType> typeForSlot = new Dictionary<SlotType, ItemType>();
	private CargoHold cargoHold;

	public event EquippedHandler Equipped;

	void Start()
	{
		cargoHold = GetComponent<CargoHold>();

		foreach (var extensionDefault in ExtensionDefault.Values)
			Equip(extensionDefault.Item);
	}

	/// <summary>
	/// Equips the given item in the item's slotType.
	/// </summary>
	/// <param name="itemType"></param>
	public void Equip(ItemType itemType)
	{
		typeForSlot[itemType.SlotType] = itemType;
		if (Equipped != null) Equipped(itemType);

		// Add to player in case he not already got it (i.e. default Extensions)
		if (cargoHold.GetAmountOf(itemType) == 0)
			cargoHold.AddItem(itemType, 1);
	}

	public ItemType GetForSlot(SlotType slotType)
	{
		return typeForSlot[slotType];
	}

	public delegate void EquippedHandler(ItemType itemType);


}