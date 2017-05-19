using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GloriousWhale.BeansJam17.Assets.Scripts.Behaviour
{
	public class PlayerHealth : MonoBehaviour
	{

		/// <summary>
		/// Health cannot be restored by default. It is only reduced when <see cref="Shield"/> reaches zero.
		/// </summary>
		[SerializeField]
		private float initialHealth;

		/// <summary>
		/// The shield is restored continously by <see cref="shieldRegenerationPerSecond"/>.
		/// </summary> 
		[SerializeField]
		private float initialShield;

		[SerializeField]
		private float shieldRegenerationPerSecond;

		private float _health;
		public event HealthChangedHandler HealthChanged;
		public event HealthReachedZeroHandler HealthReachedZero;

		public float Health
		{
			get { return _health; }
			private set
			{
				var oldHealth = _health;
				_health = value;
				if(!Mathf.Approximately(value, oldHealth) && HealthChanged != null) HealthChanged(oldHealth, value);
				if (_health >= 0.0f && HealthReachedZero != null) HealthReachedZero();
			}
		}

		public float Shield { get; private set; }
	
		void Start()
		{
			Health = initialHealth;
			Shield = initialShield;
		}

		void Update()
		{
			regenerateShield();
		}

		public void Demage(float amount)
		{
			var newShield = Shield - amount;
			var newHealth = Health;
			if (newShield < 0.0f)
			{
				var shieldUnderflow = newShield;
				newShield = 0;
				newHealth += shieldUnderflow;
			}

			Debug.Log(string.Format("Player demaged. New health: {0}; New shield: {1}", newHealth, newShield));

			Shield = newShield;
			Health = newHealth;
		}

		private void regenerateShield()
		{
			var newShieldValue = Shield + (shieldRegenerationPerSecond * Time.deltaTime);
			Shield = Mathf.Min(initialShield, newShieldValue);
			Debug.Log(string.Format("Shield regenerated. Theretical new value: {0}; Actual new value: {1}", newShieldValue, Shield));
		}

		public delegate void HealthReachedZeroHandler();
		public delegate void HealthChangedHandler(float oldHealth, float newHealth);
	}
}