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

    //���� ó�� static���� ����
    public static PlayerDie playerDieType;

    public AudioSource playBgm;

    [Header("Moonlight")]
    //�޺����� ��Ű(Moonlight)
    public float countdown = 23f;
    private float currentCount;
    public Image fadePanel;         // ������ �г� �̹���
    public Image otherImage;        // �ٸ� �̹���
    

    public Image skillBar;

    private void Start()
    {
        //����� ���� �ʱ�ȭ
        //PlayerPrefs.DeleteAll();

        //����Ʈ ���ھ� �����տ� ������ �� �ҷ�����, ���� ������ ���� ���ٸ� 0���� ȣ��
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
            //1000�� ����
            int temp4 = DataManager.Instance.score / 1000;
            numberImage[3].GetComponent<Image>().sprite = number[temp4];

            //������ 100������ �����
            int temp = DataManager.Instance.score % 1000;
            temp = temp / 100;
            //int temp = DataManager.Instance.score / 100;
            numberImage[0].GetComponent<Image>().sprite = number[temp];

            //10�� ����
            int temp2 = DataManager.Instance.score % 100;

            temp2 = temp2 / 10;
            numberImage[1].GetComponent<Image>().sprite = number[temp2];

            //1�� ����
            int temp3 = DataManager.Instance.score % 10;
            numberImage[2].GetComponent<Image>().sprite = number[temp3];
        }

        if (!DataManager.Instance.playerDie)
        {
            //1�ʿ� 1�� �ð��� �ٵ��� 
            DataManager.Instance.playTimeCurrent -= 1 * Time.deltaTime;

            if (timeBar != null)
            {
                timeBar.fillAmount = DataManager.Instance.playTimeCurrent / DataManager.Instance.playTimeMax;
            }

            //�ð��� �� �Ǹ� ����ó��
            if(DataManager.Instance.playTimeCurrent < 0) //0���� �۾��� ���
            {
                DataManager.Instance.playerDie = true;
                Invoke("GameOver", 1.3f);
                AudioManager.aInstance.Play("Die");
            }

            //�ڼ� ������ �ð� ���̱�
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
                // �ð��� �� �ż� ���� ó��
                DataManager.Instance.BestScore();
                break;
            case PlayerDie.TRAPDIE:
                // ��ֹ��� �ε����� ���� ó��
                DataManager.Instance.BestScore();
                break;
            case PlayerDie.FALLDIE:
                // �󶥿� �������� ���� ó��
                DataManager.Instance.BestScore();
                break;
        }
    }

    //������ �ٽ� ������ ��� �ʱ�ȭ
    public void RestartGame()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        DataManager.Instance.Restart();
        Debug.Log("�ٽý���");
        SceneManager.LoadScene("PlayScene_1");
    }

    void Carrot()
    {
        Transform carrotTransform = transform.Find("Carrot");
        if (carrotTransform != null && DataManager.Instance.id == 2 || DataManager.Instance.id == 3)
        {
            carrotTransform.gameObject.SetActive(true);
            Debug.Log("��� ��ȯ");
        }
        else if (DataManager.Instance.id != 2 || DataManager.Instance.id !=3)
        {
            carrotTransform.gameObject.SetActive(false);
            Debug.Log("���� ����� �ƴմϴ�");
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
            // Ÿ�̸Ӱ� ����Ǿ��� �� ������ �ڵ�
            currentCount = countdown;  // Ÿ�̸� �缳��
        }

        if(skillBar != null)
        {
            skillBar.fillAmount = currentCount / countdown;
        }
    }

    //�޺�������Ű�� ��ų�� ���� �ٲ�� ���
    IEnumerator Blackout()
    {
        // ������ ȭ������ ����
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
        


        // ��ų ���ð�
        yield return new WaitForSeconds(7.0f);

        fadePanel.color = new Color(255, 255, 255, 255);

        DataManager.Instance.isMoon = false;
    }

}

//�״� ���
public enum PlayerDie
{
    TIMEDIE,
    TRAPDIE,
    FALLDIE,
}


