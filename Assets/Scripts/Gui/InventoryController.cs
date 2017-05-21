using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Constants;
using GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.GameObjects;
using GloriousWhale.BeansJam17.Assets.Scripts.Constants;
using UnityEngine;
using UnityEngine.UI;

namespace GloriousWhale.BeansJam17.Assets.Scripts.Gui
{

	public class InventoryController : MonoBehaviour
	{
		
		[SerializeField] private GameObject itemsListObject;
		[SerializeField] private float fadeInDuration = .6f;
		[SerializeField] private float fadeOutDuration = .3f;

		private Image image;
		private GameObject objectToDisplayCargoFor;
		private Text itemsListObjectText;

		public bool IsShowing { get; private set; }

		void Start()
		{
			image = GetComponent<Image>();
			objectToDisplayCargoFor = GameObject.FindGameObjectWithTag(Tags.Player);
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


		private void Show()
		{
			IsShowing = true;

			var itemsText = this.itemsListObjectText;
			var cargoHoldToDisplay = objectToDisplayCargoFor.GetComponent<CargoHold>();

			var lines = cargoHoldToDisplay.Content
				.Where(amountForItem => amountForItem.Value != 0)
				.Select(amountForItem => GetTextFor(amountForItem.Key, amountForItem.Value))
				.ToList();
			itemsText.text = string.Join("\n", lines.ToArray());

			CrossFadeAlphaChildren(1, fadeInDuration, false);
		}

		private void Hide()
		{
			IsShowing = false;
			CrossFadeAlphaChildren(0, fadeOutDuration, false);
		}

		private void CrossFadeAlphaChildren(float target, float duration, bool ignoreTimeScale)
		{
			image.CrossFadeAlpha(target, duration, ignoreTimeScale);
			itemsListObjectText.CrossFadeAlpha(target, duration, ignoreTimeScale);
		}

		private string GetTextFor(ItemType item, int amount)
		{
			return string.Format("[{0} Slots] \t{1}x\t{2}", item.Size * amount, amount, item.DisplayName);
		}
	}
}