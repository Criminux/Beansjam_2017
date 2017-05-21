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

	public class InventoryController : MonoBehaviour
	{

		[SerializeField] private GameObject itemsCaptionObject;
		[SerializeField] private GameObject itemsListObject;
		[SerializeField] private float fadeInDuration = .6f;
		[SerializeField] private float fadeOutDuration = .3f;

		private GameObject objectToDisplayCargoFor;

		private Image image;
		private Text itemsCaptionObjectText;
		private Text itemsListObjectText;

		public bool IsShowing { get; private set; }

		void Start()
		{
			objectToDisplayCargoFor = GameObject.FindGameObjectWithTag(Tags.Player);

			image = GetComponent<Image>();
			this.itemsCaptionObjectText = itemsCaptionObject.GetComponent<Text>();
			this.itemsListObjectText = itemsListObject.GetComponent<Text>();

			CrossFadeAlphaChildren(0, 0, true);
			IsShowing = false;
		}


		void Update()
		{
			if (!IsShowing && UnityEngine.Input.GetKeyDown(KeyCode.I))
			{
				Show();
			}
			else if (IsShowing && UnityEngine.Input.GetKeyDown(KeyCode.Escape))
			{
				Hide();
			}
		}

		private void CrossFadeAlphaChildren(float target, float duration, bool ignoreTimeScale)
		{
			image.CrossFadeAlpha(target, duration, ignoreTimeScale);
			itemsCaptionObjectText.CrossFadeAlpha(target, duration, ignoreTimeScale);
			itemsListObjectText.CrossFadeAlpha(target, duration, ignoreTimeScale);
		}


		private void Show()
		{
			IsShowing = true;
			
			var cargoHoldToDisplay = objectToDisplayCargoFor.GetComponent<CargoHold>();

			UpdateItemsCaption(cargoHoldToDisplay);
			UpdateItemsList(cargoHoldToDisplay);

			CrossFadeAlphaChildren(1, fadeInDuration, false);
		}

		private void Hide()
		{
			IsShowing = false;
			CrossFadeAlphaChildren(0, fadeOutDuration, false);
		}


		private void UpdateItemsCaption(CargoHold cargoHoldToDisplay)
		{
			itemsCaptionObjectText.text = GetCargoHoldCaption(cargoHoldToDisplay);
		}

		private void UpdateItemsList(CargoHold cargoHoldToDisplay)
		{
			var lines = cargoHoldToDisplay.Content
				.Where(amountForItem => amountForItem.Value != 0)
				.Select(amountForItem => GetItemLineFor(amountForItem.Key, amountForItem.Value))
				.ToList();
			itemsListObjectText.text = string.Join("\n", lines.ToArray());
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