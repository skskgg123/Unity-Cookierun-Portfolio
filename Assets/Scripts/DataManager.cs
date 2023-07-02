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

    //점수 저장
    public int score = 0;

    //최고 점수
    public int bestScore = 0;

    //죽음
    public bool playerDie = false;

    //게임 플레이 시간 
    public float playTimeCurrent;
    public float playTimeMax;

    //다시 시작할때 점수 초기화
    public void Restart()
    {
        playTimeCurrent = playTimeMax;
        score = 0;
        playerDie = false;
        isMoon = false;
    }

    //베스트 스코어
    public void BestScore()
    {
        if(score > bestScore)
        {
            bestScore = score;
        }

        //프리팹에 저장
        PlayerPrefs.SetInt("BestScore", DataManager.Instance.bestScore);
        PlayerPrefs.Save();
    }

    //코인
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

