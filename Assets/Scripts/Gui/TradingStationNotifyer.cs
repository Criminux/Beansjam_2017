using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.GameObjects;
using GloriousWhale.BeansJam17.Assets.Scripts.Constants;

public class TradingStationNotifyer : MonoBehaviour {

    [SerializeField]
    private float FadingDuration_seconds = 1.0f;

    private Text text;

    void Start()
    {
        text = GetComponent<Text>();
        text.CrossFadeAlpha(0, 0, true);

        var player = GameObject.FindGameObjectWithTag(Tags.Player);
        var areaCheck = player.GetComponent<AreaCheck>();

        areaCheck.EnterTradingArea += OnEnterTradingArea;
        areaCheck.LeftTradingArea += OnLeftTradingArea;
    }

    private void OnLeftTradingArea()
    {
        text.CrossFadeAlpha(0, FadingDuration_seconds, false);
    }

    private void OnEnterTradingArea()
    {
        text.CrossFadeAlpha(1.0f, FadingDuration_seconds, false);
    }
}
