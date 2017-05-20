using System.Collections;
using System.Collections.Generic;
using GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.Player;
using GloriousWhale.BeansJam17.Assets.Scripts.Constants;
using UnityEngine;
using UnityEngine.UI;

public class DemageIndicatorController : MonoBehaviour
{

	[SerializeField] private float flashDuration_seconds = .5f;

	private Image image;

	private float timer = 0;

	void Start ()
	{
		image = GetComponent<Image>();
		image.CrossFadeAlpha(0, 0, true);

		var player = GameObject.FindGameObjectWithTag(Tags.Player);
		var playerHealth = player.GetComponent<ObjectHealth>();

		playerHealth.HealthChanged += (oldHealth, newHealth) =>
		{
			if (newHealth < oldHealth) FlashUp();
		};

	}

	void Update()
	{
		if (timer >= 0)
		{
			timer += Time.deltaTime;

			if (timer > flashDuration_seconds)
			{
				image.CrossFadeAlpha(0, Mathf.Round(flashDuration_seconds / 2f), false);
				// Stop the timer from updating
				timer = -1;
			}
		}
	}

	void FlashUp()
	{
		timer = 0;
		image.CrossFadeAlpha(1, Mathf.Round(flashDuration_seconds / 2f), false);
	}
}
