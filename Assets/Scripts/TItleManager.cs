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
        startButton.interactable = false; // 버튼 비활성화
        Invoke("EnableButton", 2f); // 2초 후에 버튼 활성화
        Invoke("GoMain", 3f); // 3초 후에 메인메뉴로 이동
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
        startButton.interactable = true; // 버튼 활성화
    }

    private void GoMain()
    {
        SceneManager.LoadScene(SceneToLoad);
    }

}
