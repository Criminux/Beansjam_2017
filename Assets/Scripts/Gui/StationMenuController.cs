using GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.GameObjects;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.GameManager;
using GloriousWhale.BeansJam17.Assets.Scripts.Constants;
using UnityEngine;

public class StationMenuController : MonoBehaviour
{
	[SerializeField] private float fadeInDuration = .6f;
	[SerializeField] private float fadeOutDuration = .3f;
	[SerializeField] private GameObject[] buyButtonObjects;
	[SerializeField] private GameObject[] sellButtonObjects;

	private GameObject objectToInteractWith;
	private GameManager gameManager;

	private RectTransform rectTransform;
	private List<BuyProvider> buyProviders;
	private List<SellProvider> sellProviders;

	public bool IsShowing { get; private set; }

	void Start()
	{
		rectTransform = GetComponent<RectTransform>();
		gameManager = GameObject.FindGameObjectWithTag(Tags.GameController).GetComponent<GameManager>();

		buyProviders = buyButtonObjects.Select(o => o.GetComponent<BuyProvider>()).ToList();
		sellProviders = sellButtonObjects.Select(o => o.GetComponent<SellProvider>()).ToList();

		buyProviders.ForEach(eventSource =>
		{
			buyProviders.ForEach(eventTarget => eventSource.AfterTransaction += eventTarget.GetInstanceAfterTransactionHandler());
			sellProviders.ForEach(eventTarget => eventSource.AfterTransaction += eventTarget.GetInstanceAfterTransactionHandler());
		});
		sellProviders.ForEach(eventSource =>
		{
			buyProviders.ForEach(eventTarget => eventSource.AfterTransaction += eventTarget.GetInstanceAfterTransactionHandler());
			sellProviders.ForEach(eventTarget => eventSource.AfterTransaction += eventTarget.GetInstanceAfterTransactionHandler());
		});
		SetScale(0, 0);
	}

	void Update()
	{
		if(IsShowing && UnityEngine.Input.GetKeyDown(KeyCode.Escape))
			Hide();
	}

	public void Show()
	{
		IsShowing = true;

		buyProviders.ForEach(provider => provider.Refresh());
		sellProviders.ForEach(provider => provider.Refresh());

		SetScale(1, fadeInDuration);
		gameManager.RegisterModalWindow();
	}


	public void Hide()
	{
		IsShowing = false;
		SetScale(0, fadeOutDuration);

		gameManager.UnregisterModalWindow();
	}

	private void SetScale(float target, float duration)
	{
		rectTransform.localScale = new Vector3(target, target, target);
	}
}
