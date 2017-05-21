using GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.GameObjects;
using GloriousWhale.BeansJam17.Assets.Scripts.Constants;
using UnityEngine;
using UnityEngine.UI;

namespace GloriousWhale.BeansJam17.Assets.Scripts.Gui
{

    public class SpaceStationNotifyer : MonoBehaviour
    {
        [SerializeField]
        private float FadingDuration_seconds = 1.0f;

        private Text text;
        
        void Start()
		{
			text = GetComponent<Text>();
			text.CrossFadeAlpha(0, 0, true);

			var player = GameObject.FindGameObjectWithTag(Tags.Player);
			var areaCheck = player.GetComponent<AreaCheck>();

			areaCheck.EnterBarArea += OnEnterBarArea;
			areaCheck.LeftBarArea += OnLeftBarArea;
		}

		private void OnLeftBarArea()
		{
			text.CrossFadeAlpha(0, FadingDuration_seconds, false);
		}

		private void OnEnterBarArea()
		{
			text.CrossFadeAlpha(1.0f, FadingDuration_seconds, false);
		}
    }

}
