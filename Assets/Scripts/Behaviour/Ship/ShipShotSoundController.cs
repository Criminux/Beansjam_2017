using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GloriousWhale.BeansJam17.Assets.Scripts.Behaviour.Ship
{
	public class ShipShotSoundController : MonoBehaviour
	{

		[SerializeField] AudioSource audioSource;

		[SerializeField] AudioClip[] clips;

		[SerializeField] float minVolume;
		[SerializeField] float maxVolume;

		public void PlayOneShot()
		{
			int toPlayIndex = Random.Range(0, clips.Length);
			float playVolume = Random.Range(minVolume, maxVolume);
			audioSource.PlayOneShot(clips[toPlayIndex], playVolume);
		}
	}
}