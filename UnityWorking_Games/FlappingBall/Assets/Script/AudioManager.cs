using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	//Değişkenler
	public AudioSource  AudioSource ;
	private float musicVolume = 1f ;
    // Start is called before the first frame update
    void Start()
    {
         AudioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
		AudioSource.volume = musicVolume;
        
    }
	// Arka Plan Müzik Ayarı
	public void uptadeVolume(float volume){
		musicVolume = volume ;
	}
}
