using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    //최고 점수 송출
    public TextMeshProUGUI bestScoreText;
    //
    public GameObject newRecord;

    public bool isBestScore = false;

    // Start is called before the first frame update
    void Start()
    {
        bestScoreText.text = DataManager.Instance.bestScore.ToString();

        scoreText.text = DataManager.Instance.score.ToString();

        if(isBestScore)
        {
            AudioManager.aInstance.Play("Bgm02");
        }    
        else
        {
            AudioManager.aInstance.Play("Bgm01");
        }
    }

    private void Awake()
    {
        if (DataManager.Instance.score >= DataManager.Instance.bestScore)
        {
            newRecord.SetActive(true);
            isBestScore = true;
        }
        else
        {
            newRecord.SetActive(false);
            isBestScore = false;
        }

        if (newRecord.activeSelf)
        {
            return;
        }
    }

}
