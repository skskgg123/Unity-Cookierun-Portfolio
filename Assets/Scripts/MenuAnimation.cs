using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuAnimation : MonoBehaviour
{
    public Animator[] animators;
    public Animator optionAnim;
    public float minInterval = 2f;
    public float maxInterval = 15f;

    //사운드
    public AudioSource lobbyBgm;
    public AudioSource clickBgm;

    public GameObject myCookie;


    private void Start()
    {
        // 시작할 때 랜덤한 애니메이션 선택
        PlayRandomAnimation();
        AudioManager.aInstance.PlayBgm("Bgm01");

    }

    private void PlayRandomAnimation()
    {
        // animator 배열의 모든 요소에 대해 랜덤한 애니메이션 재생
        foreach (Animator anim in animators)
        {
            int clipIndex = Random.Range(0, anim.runtimeAnimatorController.animationClips.Length);
            anim.Play(anim.runtimeAnimatorController.animationClips[clipIndex].name);
        }

        // 다음 애니메이션 재생을 위해 일정한 시간마다 PlayRandomAnimation 함수 호출
        float interval = Random.Range(minInterval, maxInterval);
        Invoke("PlayRandomAnimation", interval);
    }

    public void PlayButton()
    {
        clickBgm.Play();
        StartCoroutine(LoadSceneWithDelay(clickBgm.clip.length, "PlayScene_1"));
    }

    //버튼 소리를 끝까지 듣게 하기 위한 코루틴
    public IEnumerator LoadSceneWithDelay(float delay, string sceneName)
    {
        // 딜레이
        yield return new WaitForSeconds(delay);

        // 씬 로드
        SceneManager.LoadScene(sceneName);
    }

    public void OpenOption()
    {
        clickBgm.Play();
        optionAnim.SetBool("isOption", true);
    }

    public void CloseOption()
    {
        clickBgm.Play();
        optionAnim.SetBool("isOption", false);
    }

    public void Title()
    {
        SceneManager.LoadScene("Title");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void CookieButton()
    {
        clickBgm.Play();
        myCookie.SetActive(true);
    }

    public void MenuButton()
    {
        clickBgm.Play();
        myCookie.SetActive(false);
    }

}
