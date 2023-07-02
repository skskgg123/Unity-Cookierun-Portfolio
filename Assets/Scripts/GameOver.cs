using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    public AudioSource clickBgm;

    //게임을 다시 시작할 경우 초기화
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
        // 딜레이
        yield return new WaitForSeconds(delay);

        // 씬 로드
        SceneManager.LoadScene(sceneName);
    }

}
