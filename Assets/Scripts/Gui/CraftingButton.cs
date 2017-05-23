using GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.GameObjects;
using GloriousWhale.BeansJam17.Assets.Scripts.Constants;
using GloriousWhale.BeansJam17.Assets.Scripts.Gui;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingButton : MonoBehaviour {

    [SerializeField]
    Button button;

    [SerializeField]
    int asteroidMaterialPrice, addedFueldAmount;

    [SerializeField]
    InventoryController inventoryController;

    CargoHold playerCargoHold;

	void Start ()
    {
        playerCargoHold = GameObject.FindGameObjectWithTag(Tags.Player).GetComponent<CargoHold>();
    }
	
	void Update ()
    {
		if(playerCargoHold.GetAmountOf(ItemType.Asteroid_Material) < 50)
        {
            button.enabled = false;
        }
        else
        {
            button.enabled = true;
        }
	}

    public void OnClickCraft()
    {
        playerCargoHold.WithdrawItem(ItemType.Asteroid_Material, asteroidMaterialPrice);
        playerCargoHold.AddItem(ItemType.Fuel, addedFueldAmount);
        inventoryController.UpdateItemsList(playerCargoHold);
    }
}
