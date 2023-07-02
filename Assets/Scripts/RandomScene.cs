using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomScene : MonoBehaviour
{
    public string[] sceneNames = { "Scene2", "Scene3", "Scene4" };

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            NextScene();
        }
    }

    public void NextScene()
    {
        int randomIndex = Random.Range(0, sceneNames.Length);
        string randomSceneName = sceneNames[randomIndex];
        SceneManager.LoadScene(randomSceneName);
    }
}