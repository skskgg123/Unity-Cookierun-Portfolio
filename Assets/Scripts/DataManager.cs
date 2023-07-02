using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    static DataManager instance;

    public float magnetCurrentTime = 0f;
    public float magnetMaxTime = 5f;
    public float itemMoveSpeed = 15f;


    public static DataManager Instance
    {
        get
        {
            return instance;
        }
    }


    private void Awake()
    {
        if(instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

       
    }

    //���� ����
    public int score = 0;

    //�ְ� ����
    public int bestScore = 0;

    //����
    public bool playerDie = false;

    //���� �÷��� �ð� 
    public float playTimeCurrent;
    public float playTimeMax;

    //�ٽ� �����Ҷ� ���� �ʱ�ȭ
    public void Restart()
    {
        playTimeCurrent = playTimeMax;
        score = 0;
        playerDie = false;
        isMoon = false;
    }

    //����Ʈ ���ھ�
    public void BestScore()
    {
        if(score > bestScore)
        {
            bestScore = score;
        }

        //�����տ� ����
        PlayerPrefs.SetInt("BestScore", DataManager.Instance.bestScore);
        PlayerPrefs.Save();
    }

    //����
    public int coin = 0;


    public int id;

    public bool isMoon;

    public void SaveId(int _id)
    {
        id = _id;
        PlayerPrefs.SetInt("SaveId", DataManager.Instance.id);
        PlayerPrefs.Save();
    }

    private void Start()
    {
        id = PlayerPrefs.GetInt("SaveId");
        isMoon = false;

    }
    

}

