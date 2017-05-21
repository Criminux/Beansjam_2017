using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Constants;
using GloriousWhale.BeansJam17.Assets.Scripts.Constants;
using UnityEngine;

public class ExtensionManager : MonoBehaviour
{

	private Dictionary<SlotType, ItemType> typeForSlot = new Dictionary<SlotType, ItemType>();

	public event EquippedHandler Equipped;

	void Start()
	{
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
	}

	public ItemType GetForSlot(SlotType slotType)
	{
		return typeForSlot[slotType];
	}

	public delegate void EquippedHandler(ItemType itemType);


}