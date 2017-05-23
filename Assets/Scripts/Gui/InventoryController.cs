using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.GameManager;
using GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.GameObjects;
using GloriousWhale.BeansJam17.Assets.Scripts.Constants;
using UnityEngine;
using UnityEngine.UI;

namespace GloriousWhale.BeansJam17.Assets.Scripts.Gui
{

	public class InventoryController : MonoBehaviour
	{

		[SerializeField] private GameObject itemsCaptionObject;
		[SerializeField] private GameObject itemsListObject;
		[SerializeField] private GameObject[] extensionDropdownObjects;
		[SerializeField] private float fadeInDuration = .6f;
		[SerializeField] private float fadeOutDuration = .3f;

		private GameObject objectToDisplayCargoFor;
		private GameManager gameManager;

		private Image image;
		private RectTransform rectTransform;
		private Text itemsCaptionObjectText;
		private Text itemsListObjectText;
		private List<ExtensionDropdownController> extensionDropdownObjectControllers;


		public bool IsShowing { get; private set; }

		void Start()
		{
			objectToDisplayCargoFor = GameObject.FindGameObjectWithTag(Tags.Player);
			gameManager = GameObject.FindGameObjectWithTag(Tags.GameController).GetComponent<GameManager>();

			rectTransform = GetComponent<RectTransform>();
			image = GetComponent<Image>();
			this.itemsCaptionObjectText = itemsCaptionObject.GetComponent<Text>();
			this.itemsListObjectText = itemsListObject.GetComponent<Text>();
			this.extensionDropdownObjectControllers = extensionDropdownObjects
				.Select(o => o.GetComponent<ExtensionDropdownController>())
				.ToList();

			SetScale(0, 0);
			IsShowing = false;
		}


		void Update()
		{
			if (!IsShowing && UnityEngine.Input.GetKeyDown(KeyCode.I))
			{
				Show();
			}
			else if (IsShowing && UnityEngine.Input.GetKeyDown(KeyCode.I))
			{
				Hide();
			}
		}

		private void SetScale(float target, float duration)
		{
			rectTransform.localScale = new Vector3(target, target, target);
		}


		private void Show()
		{
			IsShowing = true;
			
			var cargoHoldToDisplay = objectToDisplayCargoFor.GetComponent<CargoHold>();

			UpdateItemsCaption(cargoHoldToDisplay);
			UpdateItemsList(cargoHoldToDisplay);
			UpdateExtensionControllers();

			SetScale(1, fadeInDuration);

			gameManager.RegisterModalWindow();
		}


		private void Hide()
		{
			IsShowing = false;
			SetScale(0, fadeOutDuration);

			gameManager.UnregisterModalWindow();
		}


		public void UpdateItemsCaption(CargoHold cargoHoldToDisplay)
		{
			itemsCaptionObjectText.text = GetCargoHoldCaption(cargoHoldToDisplay);
		}

		public void UpdateItemsList(CargoHold cargoHoldToDisplay)
		{
			var lines = cargoHoldToDisplay.Content
				.Where(amountForItem => amountForItem.Value != 0)
				.Select(amountForItem => GetItemLineFor(amountForItem.Key, amountForItem.Value))
				.ToList();
			itemsListObjectText.text = string.Join("\n", lines.ToArray());
		}
		private void UpdateExtensionControllers()
		{
			foreach (var extensionDropdownObjectController in extensionDropdownObjectControllers)
				extensionDropdownObjectController.Refresh();
		}

		private string GetCargoHoldCaption(CargoHold cargoHold)
		{
			return string.Format("Cargo Hold [{0} Occupied Slots / {1} Total Slots]", cargoHold.OccupiedSpace, cargoHold.Size);
		}

		private string GetItemLineFor(ItemType item, int amount)
		{
			return string.Format("[{0:00} Slots] \t{1}x\t{2}", (item.Size * amount), amount, item.DisplayName);
		}
	}
}