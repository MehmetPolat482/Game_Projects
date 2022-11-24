using UnityEngine.Audio;
using UnityEngine;

public class SettingMenu : MonoBehaviour
{
    public  AudioMixer mainMixer;

    public void SetFullScreen(bool isFullscreen){
        Screen.fullScreen = isFullscreen;
    }
    public void SetQuality(int qualityIndex){
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetVolume(float volume){
        mainMixer.SetFloat("volume" , volume);
    }
}
