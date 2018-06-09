using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class settingsMenu : MonoBehaviour
{

	public Slider volume;
	public Slider volumee;

	public AudioSource myMusic;

	private void Start()
	{
		volume = volume.GetComponent<Slider>();

		volumee = volumee.GetComponent<Slider>();

		myMusic = myMusic.GetComponent<AudioSource>();
	}

	void Update()
	{

		myMusic.volume = volume.value;
		volumee.value = volume.value;
		

	}
}
