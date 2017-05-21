using System.Collections;
using System.Collections.Generic;
using GloriousWhale.BeansJam17.Assets.Scripts.Constants;
using UnityEngine;


namespace GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.GameObjects
{
	public class CargoHold : MonoBehaviour
	{

		private Dictionary<ItemType, int> content = new Dictionary<ItemType, int>();

		[SerializeField] private int size;


		public Dictionary<ItemType, int> Content
		{
			get { return content; }
		}

		public int OccupiedSpace { get; private set; }

		public int Size
		{
			get { return size; }
		}


		/// <summary>
		///  Withdraws the item from this CargoHold and adds them to target.
		/// </summary>
		/// <param name="target"></param>
		/// <param name="item"></param>
		/// <param name="amount"></param>
		public void TransferTo(CargoHold target, ItemType item, int amount)
		{
			var withdrawnAmount = WithdrawItem(item, amount);
			var addedAmount = target.AddItem(item, amount);

			// if not all withdrawn itemTypes could be added, add them back
			AddItem(item, withdrawnAmount - addedAmount);
		}

		/// <summary>
		/// Withdraws the item from target and adds them to this CargoHold (actually calls transferTo at the target).
		/// </summary>
		/// <param name="supplier"></param>
		/// <param name="item"></param>
		/// <param name="amount"></param>
		public void TransferFrom(CargoHold supplier, ItemType item, int amount)
		{
			supplier.TransferTo(this, item, amount);
		}

		/// <summary>
		/// Adds the item to the cargo
		/// </summary>
		/// <param name="item"></param>
		/// <param name="amount"></param>
		/// <returns>the amount which was actually added</returns>
		public int AddItem(ItemType item, int amount)
		{
			// Register item
			if (!content.ContainsKey(item))
				content[item] = 0;

			// Calculate how much can actually be added
			var remainingSpace = Size - OccupiedSpace;
			var addableAmount = Mathf.FloorToInt((float) remainingSpace / (float) item.Size);

			// Don't add too much
			int addedAmount = Mathf.Min(amount, addableAmount);

			// Update the item's value by addming the addedAmount to the previous value.
			content[item] = content[item] + addedAmount;
			OccupiedSpace += addedAmount * item.Size;

			return addedAmount;
		}

		/// <summary>
		/// Removes the item from the cargo.
		/// </summary>
		/// <param name="item"></param>
		/// <param name="amount"></param>
		/// <returns>the amount which was actually removed</returns>
		public int WithdrawItem(ItemType item, int amount)
		{
			// If ther item is not available, nothing is withdrawn.
			int withdrawnAmount = 0;

			if (content.ContainsKey(item))
			{
				int amountInCargo = content[item];
				amountInCargo -= amount;
				if (amountInCargo < 0)
				{
					// Example: 20 itemTypes shall be withdrawn, but there are only 10 available.
					// amountInCargoHold now is -10, so all remaining itemTypes (10) are withdrawn which equals to 20 (desired amount) + -10 ("remaining")
					withdrawnAmount = amount + amountInCargo;
					amountInCargo = 0;
				}
				else
				{
					withdrawnAmount = amount;
				}

				content[item] = amountInCargo;
				OccupiedSpace -= item.Size * withdrawnAmount;
			}

			return withdrawnAmount;
		}

		public int GetAmountOf(ItemType item)
		{
			int amount;
			var isPresent = content.TryGetValue(item, out amount);
			if (!isPresent)
				return 0;
			else
				return amount;
		}

		public int GetSpaceOccupiedBy(ItemType item)
		{
			return GetAmountOf(item) * item.Size;
		}

        public void SetAmount(ItemType item, int amount)
        {
            var difference = GetAmountOf(item) - amount;
            if (difference < 0)
                AddItem(item, -difference);
            else
                WithdrawItem(item, difference);
        }
	}
}