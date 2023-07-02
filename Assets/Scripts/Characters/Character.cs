using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float jump = 10f;
    public float jump2 = 12f;

    public int jumpCount = 0;

    public Animator playerAnim;

    public SpriteRenderer pRenderer;
    //죽으면 더이상 처리하지 않도록하기
    public bool isDie;

    //무적
    public bool isHit = false;

    public int maxJump = 2;

    public float health;

    private void Start()
    {
        //다음씬으로 갔을때 체력이 초기화 되지 않고 현재 체력을 가져가도록 하는 선언
        if (DataManager.Instance.playTimeCurrent == DataManager.Instance.playTimeMax)
        {
            DataManager.Instance.playTimeCurrent = health;
            DataManager.Instance.playTimeMax = health;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag.CompareTo("Ground") == 0)
        {
            jumpCount = 0;
            playerAnim.SetInteger("pJump", 0);
        }



        /*if(collision.gameObject.tag.CompareTo("Block") == 0)
        {
            StartCoroutine(HitEffect());
            playerAnim.SetInteger("pJump", 5);
            DataManager.Instance.playTimeCurrent -= 2f;
        }*/

    }

    //피격이 됐을경우
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.CompareTo("Block") == 0 && !DataManager.Instance.isMoon)
        {
            //무적 판정
            if (!isHit)
            {
                AudioManager.aInstance.Play("Hit");
                DataManager.Instance.playTimeCurrent -= 2f;
                //StartCoroutine(HitEffect());
            }
            StartCoroutine(PlayerHit());

        }


    }

    //장애물에 닿았을 경우 깜빡 거리는 효과 및 무적
    IEnumerator PlayerHit()
    {
        int countTime = 0;


        while (countTime < 10)
        {
            isHit = true;
            if (countTime % 2 == 0)
                pRenderer.color = new Color32(255, 255, 255, 90);
            else
                pRenderer.color = new Color32(255, 255, 255, 180);

            yield return new WaitForSeconds(0.2f);

            countTime++;
        }

        pRenderer.color = new Color32(255, 255, 255, 255);

        isHit = false;

        yield return null;

    }

}
