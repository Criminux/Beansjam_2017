
using System;
using GloriousWhale.BeansJam17.Assets.Scripts.Constants;
using UnityEngine;

namespace GloriousWhale.BeansJam17.Assets.Scripts.Behaviour
{

	public class AreaCheck : MonoBehaviour
	{
	
		/// <summary>
		/// Is triggered when the object left the legal area. Typically, a warning needs to get displayed.
		/// </summary>
		public event LeftLegalAreaHandler LeftLegalArea;

		/// <summary>
		/// Is triggered when the object reentered the legal area. Typically, the in <see cref="LeftLegalArea"/> displayed warning needs to get hidden again.
		/// </summary>
		public event ReenteredLegalAreaHandler ReenteredLegalArea;

		/// <summary>
		/// Is triggered when the object left the warning area. Typically, it needs to get destroyed or warped to back to the legal area now.
		/// </summary>
		public event LeftWarningAreaHandler LeftWarningArea;

		void OnTriggerExit(Collider collider)
		{
			if (collider.tag == Tags.LegalArea)
			{
				if (LeftLegalArea != null) LeftLegalArea();
				Debug.Log(gameObject.name + " left the legal area");
			}
			else if (collider.tag == Tags.WarningArea)
			{
				if (LeftWarningArea != null) LeftWarningArea();
				Debug.Log(gameObject.name + " left the warning area");
			}

		}

		void OnTriggerEnter(Collider collider)
		{
			if (collider.tag == Tags.LegalArea)
			{
				if (ReenteredLegalArea != null) ReenteredLegalArea();
				Debug.Log(gameObject.name + " reentered the legal area");
			}
		}

		public delegate void LeftLegalAreaHandler();
		public delegate void ReenteredLegalAreaHandler();
		public delegate void LeftWarningAreaHandler();
	}
}