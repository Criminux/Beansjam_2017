using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.GameObjects;
using GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.Ship;
using GloriousWhale.BeansJam17.Assets.Scripts.Constants;
using UnityEngine;
using UnityEngine.UI;

public abstract class TransactionProvider : MonoBehaviour
{
	[SerializeField] private string itemIdentifier;
	[SerializeField] private float price;
	[SerializeField] private GameObject associatedLabel;

	public event AfterTransactionHandler AfterTransaction;
	private ItemType item;

	private PlayerProperties playerProperties;
	private CargoHold playerCargoHold;
    private ExtensionManager playerExtensionManager;
	private Text associatedLabelText;

	public float Price
	{
		get { return price; }
	}

	public ItemType Item
	{
		get { return item; }
	}

	protected void Init()
	{
		item = ItemType.Values.First(type => type.Identifier == itemIdentifier);
		associatedLabelText = associatedLabel.GetComponent<Text>();

		associatedLabelText.text = string.Format("{0} ({1:F2} Cr)", item.DisplayName, price);
		GetComponent<Button>().onClick.AddListener(TryTransact);

		var player = GameObject.FindGameObjectWithTag(Tags.Player);
		playerProperties = player.GetComponent<PlayerProperties>();
		playerCargoHold= player.GetComponent<CargoHold>();
        playerExtensionManager = player.GetComponent<ExtensionManager>();
	}

	protected void TryTransact()
	{
		if (MayTransact(playerCargoHold, playerProperties, playerExtensionManager))
		{
			DoTransaction(playerCargoHold, playerProperties);
			if (AfterTransaction != null) AfterTransaction();
		}

	}

	protected abstract bool MayTransact(CargoHold targetCargoHold, PlayerProperties playerProperties, ExtensionManager extensionManager);

	protected abstract void DoTransaction(CargoHold targetCargoHold, PlayerProperties playerProperties);

	public AfterTransactionHandler GetInstanceAfterTransactionHandler()
	{
		return Refresh;
	}

	public void Refresh()
	{
		var targetColor = MayTransact(playerCargoHold, playerProperties, playerExtensionManager) ? Color.black : Color.red;
		associatedLabelText.color = targetColor;
	}

	public delegate void AfterTransactionHandler();

}
