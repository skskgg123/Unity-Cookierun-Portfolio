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

    //����
    public AudioSource lobbyBgm;
    public AudioSource clickBgm;

    public GameObject myCookie;


    private void Start()
    {
        // ������ �� ������ �ִϸ��̼� ����
        PlayRandomAnimation();
        AudioManager.aInstance.PlayBgm("Bgm01");

    }

    private void PlayRandomAnimation()
    {
        // animator �迭�� ��� ��ҿ� ���� ������ �ִϸ��̼� ���
        foreach (Animator anim in animators)
        {
            int clipIndex = Random.Range(0, anim.runtimeAnimatorController.animationClips.Length);
            anim.Play(anim.runtimeAnimatorController.animationClips[clipIndex].name);
        }

        // ���� �ִϸ��̼� ����� ���� ������ �ð����� PlayRandomAnimation �Լ� ȣ��
        float interval = Random.Range(minInterval, maxInterval);
        Invoke("PlayRandomAnimation", interval);
    }

    public void PlayButton()
    {
        clickBgm.Play();
        StartCoroutine(LoadSceneWithDelay(clickBgm.clip.length, "PlayScene_1"));
    }

    //��ư �Ҹ��� ������ ��� �ϱ� ���� �ڷ�ƾ
    public IEnumerator LoadSceneWithDelay(float delay, string sceneName)
    {
        // ������
        yield return new WaitForSeconds(delay);

        // �� �ε�
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
