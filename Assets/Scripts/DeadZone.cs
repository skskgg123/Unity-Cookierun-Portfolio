using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!DataManager.Instance.playerDie)
        {
            if(collision.gameObject.tag.CompareTo("Player") == 0)
            {
                GameManager.Death(PlayerDie.FALLDIE);
                DataManager.Instance.playerDie = true;
                Invoke("GameOver", 1.3f);
                AudioManager.aInstance.Play("Die");
            }
        }
    }

    private void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

}
