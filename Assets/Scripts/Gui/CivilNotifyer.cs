using GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.GameObjects;
using GloriousWhale.BeansJam17.Assets.Scripts.Constants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CivilNotifyer : MonoBehaviour {

    [SerializeField]
    private float FadingDuration_seconds = 1.0f;

    private Text text;

    void Start()
    {
        text = GetComponent<Text>();
        text.CrossFadeAlpha(0, 0, true);

        var player = GameObject.FindGameObjectWithTag(Tags.Player);
        var areaCheck = player.GetComponent<AreaCheck>();

        areaCheck.EnterCivilArea += OnEnterCivilArea;
        areaCheck.LeftCivilArea += OnLeftCivilArea;
    }

    private void OnLeftCivilArea()
    {
        text.CrossFadeAlpha(0, FadingDuration_seconds, false);
    }

    private void OnEnterCivilArea()
    {
        text.CrossFadeAlpha(1.0f, FadingDuration_seconds, false);
    }
}
