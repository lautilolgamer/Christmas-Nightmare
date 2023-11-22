using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOnOff : MonoBehaviour {

	public AudioClip TurnOnOffFlashlight;
	private AudioSource FlashlightClick;
	Light Flashlight;
	void Start () {
		Flashlight = GetComponent <Light> ();
		FlashlightClick = GetComponent<AudioSource>();
	}
	

	void Update () {
		if (Input.GetKeyDown (KeyCode.F)) {
			Flashlight.enabled = !Flashlight.enabled;
			FlashlightClick.PlayOneShot (TurnOnOffFlashlight, 1.0f);
	
		}

	}
}
