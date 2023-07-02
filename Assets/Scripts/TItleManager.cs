using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TItleManager : MonoBehaviour
{
    public string SceneToLoad;
    public Button startButton;

    private void Start()
    {
        AudioManager.aInstance.PlayBgm("Bgm01");
        startButton.interactable = false; // ��ư ��Ȱ��ȭ
        Invoke("EnableButton", 2f); // 2�� �Ŀ� ��ư Ȱ��ȭ
        Invoke("GoMain", 3f); // 3�� �Ŀ� ���θ޴��� �̵�
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && startButton.interactable)
        {
            SceneManager.LoadScene(SceneToLoad);
        }
    }

    private void EnableButton()
    {
        startButton.interactable = true; // ��ư Ȱ��ȭ
    }

    private void GoMain()
    {
        SceneManager.LoadScene(SceneToLoad);
    }

}
