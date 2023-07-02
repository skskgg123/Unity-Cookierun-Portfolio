using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    //�̱���
    public static AudioManager aInstance;

    public Sound[] sounds;

    //���� �÷��̵ǰ� �ִ� Bgm Name
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

        //�����
        //"Master"�� �����ִ� �׷���� �迭�� ����
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
        //���� �̸��� ���� ã��
        Sound sound = null;
        foreach (var s in sounds)
        {
            //�÷����� name�� ���� �̸��� ���� ���
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
        //���� �̸��� ���� ã��
        Sound sound = null;
        foreach (var s in sounds)
        {
            //�÷����� name�� ���� �̸��� ���� ���
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
        //���� �÷��� �ǰ� �ִ� Bgm�� ���� �̸� üũ
        if (bgmName == name)
        {
            return;
        }

        Stop(bgmName);

        //���� �̸��� ���� ã��
        Sound sound = null;
        foreach (var s in sounds)
        {
            //�÷����� name�� ���� �̸��� ���� ���
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
