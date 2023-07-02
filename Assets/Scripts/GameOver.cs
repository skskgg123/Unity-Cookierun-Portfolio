using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    public AudioSource clickBgm;

    //������ �ٽ� ������ ��� �ʱ�ȭ
    public void RestartGame()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        DataManager.Instance.Restart();
        clickBgm.Play();
        StartCoroutine(LoadSceneWithDelay(clickBgm.clip.length, "PlayScene_1"));
    }

    public void MainButton()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        DataManager.Instance.Restart();
        clickBgm.Play();
        StartCoroutine(LoadSceneWithDelay(clickBgm.clip.length, "MainMenu"));
    }

    public IEnumerator LoadSceneWithDelay(float delay, string sceneName)
    {
        // ������
        yield return new WaitForSeconds(delay);

        // �� �ε�
        SceneManager.LoadScene(sceneName);
    }

}
