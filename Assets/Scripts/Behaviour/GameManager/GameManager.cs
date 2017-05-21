using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.GameManager
{

	public class GameManager : MonoBehaviour
	{
		private int _openModalWindows = 0;

		public event ModalWindowActivationChangedHandler ModalWindowActivationChanged;

        public bool ModalWindowActive
        {
            get { return (_openModalWindows > 0); }
        }

		void Start()
		{
			LockCursor();
			ModalWindowActivationChanged += active =>
			{
				if (active)
					UnlockCursor();
				else
					LockCursor();
			};
		}

		public void RegisterModalWindow()
		{
			bool oldModalWindowActivationState = _openModalWindows > 0;
			_openModalWindows++;
			bool newModalWindowActivationState = _openModalWindows > 0;
			if (oldModalWindowActivationState != newModalWindowActivationState)
				if (ModalWindowActivationChanged != null) ModalWindowActivationChanged(_openModalWindows > 0);
		}

		public void UnregisterModalWindow()
		{
			//TODO: Copy-paste
			bool oldModalWindowActivationState = _openModalWindows > 0;
			_openModalWindows--;
			bool newModalWindowActivationState = _openModalWindows > 0;
			if (oldModalWindowActivationState != newModalWindowActivationState)
				if (ModalWindowActivationChanged != null) ModalWindowActivationChanged(_openModalWindows > 0);

		}

		private static void UnlockCursor()
		{
			Debug.Log("unlocking cursor...");
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}

		private static void LockCursor()
		{
			Debug.Log("locking cursor...");
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}


		public delegate void ModalWindowActivationChangedHandler(bool active);
	}
}