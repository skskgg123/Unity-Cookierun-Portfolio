using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

//���� ��� ������ ���� Ŭ����
[System.Serializable]
public class Sound 
{
    public string name;

    public AudioClip clip;
    [Range(0, 1f)]
    public float volume;
    [Range(0.1f, 3f)]
    public float pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource source;


}
