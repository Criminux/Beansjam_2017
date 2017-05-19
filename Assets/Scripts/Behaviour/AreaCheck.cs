
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

		void OnCollisionExit(Collision collision)
		{
			if (collision.gameObject.tag.Equals(Tags.LegalArea))
				LeftLegalArea();
			else if (collision.gameObject.tag.Equals(Tags.WarningArea))
				LeftWarningArea();
		}

		void OnCollisionEnter(Collision collision)
		{
			if (collision.gameObject.tag.Equals(Tags.LegalArea))
				ReenteredLegalArea();
		}

		public delegate void LeftLegalAreaHandler();
		public delegate void ReenteredLegalAreaHandler();
		public delegate void LeftWarningAreaHandler();
	}
}