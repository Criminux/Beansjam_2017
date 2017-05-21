using System.Collections;
using System.Collections.Generic;
using GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.GameObjects;
using GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.Ship;
using UnityEngine;
using GloriousWhale.BeansJam17.Assets.Scripts.Constants;

public class SellProvider : TransactionProvider {

	void Start()
	{
		Init();
	}

	protected override bool MayTransact(CargoHold targetCargoHold, PlayerProperties playerProperties, ExtensionManager extensionManager)
    {
        if (Item.SlotType == SlotType.None)
        {
            return targetCargoHold.GetAmountOf(Item) > 0;
        }
        else
        {
            return (extensionManager.GetForSlot(Item.SlotType) != Item && targetCargoHold.GetAmountOf(Item) > 0) || targetCargoHold.GetAmountOf(Item) > 1;
        }
	}

	protected override void DoTransaction(CargoHold targetCargoHold, PlayerProperties playerProperties)
	{
		targetCargoHold.WithdrawItem(Item, 1);
		playerProperties.Money += Price;
	}
}
