using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Image[] numberImage;
    public Sprite[] number;

    public Image timeBar;

    //죽음 처리 static으로 설정
    public static PlayerDie playerDieType;

    public AudioSource playBgm;

    [Header("Moonlight")]
    //달빛술사 쿠키(Moonlight)
    public float countdown = 23f;
    private float currentCount;
    public Image fadePanel;         // 검은색 패널 이미지
    public Image otherImage;        // 다른 이미지
    

    public Image skillBar;

    private void Start()
    {
        //저장된 점수 초기화
        //PlayerPrefs.DeleteAll();

        //베스트 스코어 프리팹에 저장한 값 불러오기, 만약 저장한 값이 없다면 0으로 호출
        DataManager.Instance.bestScore = PlayerPrefs.GetInt("BestScore", 0);

        AudioManager.aInstance.PlayBgm("Bgm01");

        Carrot();

        if (DataManager.Instance.id == 4 || DataManager.Instance.id == 5)
        {
            currentCount = countdown;
            DataManager.Instance.isMoon = false;
        }


    }

    private void Update()
    {
        if (!DataManager.Instance.playerDie)
        {
            //1000의 단위
            int temp4 = DataManager.Instance.score / 1000;
            numberImage[3].GetComponent<Image>().sprite = number[temp4];

            //점수를 100단위로 띄우자
            int temp = DataManager.Instance.score % 1000;
            temp = temp / 100;
            //int temp = DataManager.Instance.score / 100;
            numberImage[0].GetComponent<Image>().sprite = number[temp];

            //10의 단위
            int temp2 = DataManager.Instance.score % 100;

            temp2 = temp2 / 10;
            numberImage[1].GetComponent<Image>().sprite = number[temp2];

            //1의 단위
            int temp3 = DataManager.Instance.score % 10;
            numberImage[2].GetComponent<Image>().sprite = number[temp3];
        }

        if (!DataManager.Instance.playerDie)
        {
            //1초에 1씩 시간이 줄도록 
            DataManager.Instance.playTimeCurrent -= 1 * Time.deltaTime;

            if (timeBar != null)
            {
                timeBar.fillAmount = DataManager.Instance.playTimeCurrent / DataManager.Instance.playTimeMax;
            }

            //시간이 다 되면 죽음처리
            if(DataManager.Instance.playTimeCurrent < 0) //0보다 작아질 경우
            {
                DataManager.Instance.playerDie = true;
                Invoke("GameOver", 1.3f);
                AudioManager.aInstance.Play("Die");
            }

            //자석 아이템 시간 줄이기
            if(DataManager.Instance.magnetCurrentTime > 0)
            {
                DataManager.Instance.magnetCurrentTime -= 1 * Time.deltaTime;
            }
        }


        if (DataManager.Instance.id == 4 || DataManager.Instance.id == 5)
        {
            MoonlightCookie();
        }

    }

    private void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void StopButton()
    {
        DataManager.Instance.playerDie = true;
        SceneManager.LoadScene("GameOver");
        Time.timeScale = 1;
    }

    public static void Death(PlayerDie playerDie)
    {
        switch (playerDieType)
        {
            case PlayerDie.TIMEDIE:
                // 시간이 다 돼서 죽음 처리
                DataManager.Instance.BestScore();
                break;
            case PlayerDie.TRAPDIE:
                // 장애물에 부딪혀서 죽음 처리
                DataManager.Instance.BestScore();
                break;
            case PlayerDie.FALLDIE:
                // 빈땅에 떨어져서 죽음 처리
                DataManager.Instance.BestScore();
                break;
        }
    }

    //게임을 다시 시작할 경우 초기화
    public void RestartGame()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        DataManager.Instance.Restart();
        Debug.Log("다시시작");
        SceneManager.LoadScene("PlayScene_1");
    }

    void Carrot()
    {
        Transform carrotTransform = transform.Find("Carrot");
        if (carrotTransform != null && DataManager.Instance.id == 2 || DataManager.Instance.id == 3)
        {
            carrotTransform.gameObject.SetActive(true);
            Debug.Log("당근 소환");
        }
        else if (DataManager.Instance.id != 2 || DataManager.Instance.id !=3)
        {
            carrotTransform.gameObject.SetActive(false);
            Debug.Log("나는 당근이 아닙니다");
        }
        else if (carrotTransform == null)
        {
            return;
        }
    }

    private void MoonlightCookie()
    {
        skillBar = GameObject.FindGameObjectWithTag("PlayerSkill").GetComponent<Image>();

        if (!DataManager.Instance.isMoon)
            currentCount -= Time.deltaTime;
        else
            currentCount = countdown;

        if (currentCount <= 0f)
        {
            StartCoroutine(Blackout());
            // 타이머가 종료되었을 때 실행할 코드
            currentCount = countdown;  // 타이머 재설정
        }

        if(skillBar != null)
        {
            skillBar.fillAmount = currentCount / countdown;
        }
    }

    //달빛술사쿠키가 스킬을 쓸때 바뀌는 배경
    IEnumerator Blackout()
    {
        // 검은색 화면으로 변경
        fadePanel.color = new Color(255, 255, 255, 1);
        //yield return new WaitForSeconds(0.3f);

        float t = 1.0f;

        while (t >= 0)
        {
            t -= Time.deltaTime;
            fadePanel.color = new Color(255, 255, 255, t);
            yield return 0;
            DataManager.Instance.isMoon = true;
        }
        


        // 스킬 사용시간
        yield return new WaitForSeconds(7.0f);

        fadePanel.color = new Color(255, 255, 255, 255);

        DataManager.Instance.isMoon = false;
    }

}

//죽는 방식
public enum PlayerDie
{
    TIMEDIE,
    TRAPDIE,
    FALLDIE,
}


