using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Option : MonoBehaviour
{
    public AudioMixer audioMixer;

    //슬라이더
    public Slider bgmSlider;
    public Slider sfxSlider;

    private void Start()
    {
        float bgmVolume = PlayerPrefs.GetFloat("BgmVolume", 1f);
        bgmSlider.value = bgmVolume;
        SetBgmVolume();

        float sfxVolume = PlayerPrefs.GetFloat("SfxVolume", 1f);
        sfxSlider.value = sfxVolume;
        SetSfxVolume();
    }

    public void SetBgmVolume()
    {
        audioMixer.SetFloat("Bgm", Mathf.Log10(bgmSlider.value) * 20);
        PlayerPrefs.SetFloat("BgmVolume", bgmSlider.value);
        PlayerPrefs.Save();
    }

    public void SetSfxVolume()
    {
        audioMixer.SetFloat("Sfx", Mathf.Log10(sfxSlider.value) * 20);
        PlayerPrefs.SetFloat("SfxVolume", sfxSlider.value);
        PlayerPrefs.Save();

    }

}
