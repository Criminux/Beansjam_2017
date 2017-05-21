using System.Collections;
using System.Collections.Generic;
using GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.GameObjects;
using GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.Ship;
using UnityEngine;
using UnityEngine.UI;

public class BuyProvider : TransactionProvider { 
	

	void Start()
	{
		Init();
	}


	protected override void DoTransaction(CargoHold targetCargoHold, PlayerProperties playerProperties)
	{
		targetCargoHold.AddItem(Item, 1);
		playerProperties.Money -= Price;
	}


	protected override bool MayTransact(CargoHold targetCargoHold, PlayerProperties playerProperties)
	{
		var enoughSpace = (targetCargoHold.Size - targetCargoHold.OccupiedSpace) >= Item.Size;
		var enoughMoney = playerProperties.Money > Price;
		return enoughMoney && enoughSpace;
	}
}
