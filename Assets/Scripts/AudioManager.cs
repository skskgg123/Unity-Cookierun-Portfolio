using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    //싱글톤
    public static AudioManager aInstance;

    public Sound[] sounds;

    //현재 플레이되고 있는 Bgm Name
    private string bgmName;

    public AudioMixer audioMixer;

    private void Awake()
    {
        if (aInstance != null)
        {
            Destroy(gameObject);
            return;
        }
        aInstance = this;
        //DontDestroyOnLoad(gameObject);

        //오디오
        //"Master"에 속해있는 그룹들이 배열로 들어옴
        AudioMixerGroup[] audioMixerGroups = audioMixer.FindMatchingGroups("Master");

        foreach (var s in sounds)
        {
            s.source = this.gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

            if (s.loop)
                s.source.outputAudioMixerGroup = audioMixerGroups[1]; //BGM
            else
                s.source.outputAudioMixerGroup = audioMixerGroups[2]; //SFX
        }

    }

    public void Play(string name)
    {
        //같은 이름의 사운드 찾기
        Sound sound = null;
        foreach (var s in sounds)
        {
            //플레이할 name과 현재 이름이 같을 경우
            if (s.name == name)
            {
                sound = s;
                break;
            }
        }

        if (sound == null)
        {
            Debug.Log(name + " File not Found!!!");
            return;
        }

        sound.source.Play();
    }

    public void Stop(string name)
    {
        //같은 이름의 사운드 찾기
        Sound sound = null;
        foreach (var s in sounds)
        {
            //플레이할 name과 현재 이름이 같을 경우
            if (s.name == name)
            {
                sound = s;
                break;
            }
        }

        if (sound == null)
        {
            return;
        }

        sound.source.Stop();
    }


    public void PlayBgm(string name)
    {
        //현재 플레이 되고 있는 Bgm과 같은 이름 체크
        if (bgmName == name)
        {
            return;
        }

        Stop(bgmName);

        //같은 이름의 사운드 찾기
        Sound sound = null;
        foreach (var s in sounds)
        {
            //플레이할 name과 현재 이름이 같을 경우
            if (s.name == name)
            {
                bgmName = name;
                sound = s;
                break;
            }
        }

        if (sound == null)
        {
            Debug.Log(name + "File not Found!!!");
            return;
        }
        sound.source.Play();

    }

    public void StopBgm()
    {
        Stop(bgmName);
    }
}
