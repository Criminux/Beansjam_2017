using System.Collections;
using System.Collections.Generic;
using GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.GameObjects;
using GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.Ship;
using UnityEngine;

public class SellProvider : TransactionProvider {

	void Start()
	{
		Init();
	}

	protected override bool MayTransact(CargoHold targetCargoHold, PlayerProperties playerProperties)
	{
		return targetCargoHold.GetAmountOf(Item) > 0;
	}

	protected override void DoTransaction(CargoHold targetCargoHold, PlayerProperties playerProperties)
	{
		targetCargoHold.WithdrawItem(Item, 1);
		playerProperties.Money += Price;
	}
}
