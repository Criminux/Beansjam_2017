using GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.GameManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorUnlockerOnStart : MonoBehaviour {
    
	void Start ()
    {
        GameManager.UnlockCursor();
    }
	
	
}
