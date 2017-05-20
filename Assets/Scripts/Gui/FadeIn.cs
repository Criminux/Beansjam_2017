using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {

    // Public variables
    public float secondsToFadeIn;

    // Private GameObjects
    private Image fadePanel;
    private Color currentColor = Color.black;

    // To automatically assign the GameObjects
    void Start () {
        fadePanel = GetComponent<Image>();
    }

    // to change the alpha channel of the panel for a fade in and disable it after that
    void Update () {
        if(Time.timeSinceLevelLoad < secondsToFadeIn)
        {
            float alphaChange = Time.deltaTime / secondsToFadeIn;
            currentColor.a -= alphaChange;
            fadePanel.color = currentColor;
        }
        else
        {
            gameObject.SetActive(false);
        }
	}
}
