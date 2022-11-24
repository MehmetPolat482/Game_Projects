using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSourceScript : MonoBehaviour
{
	//Oyundaki Ses Değişkenleri
	public AudioSource audioSource;
	private bool isOn;

	// SetMusic Fonksiyonuyla AnaMenüdeki Ses Ayarının Kapanıp Açılması
	public void SetMusic(bool isMusic){
		audioSource.mute = !isMusic;
	}
	
	// SetMusic Fonksiyonuyla DurdurmaMenüsündeki Ses Ayarının Kapanıp Açılması
	public void SetSound(bool onMusic){
		if(onMusic){
			
			audioSource.mute = !audioSource.mute;
		}
	}
	
	
}
