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
    //������ ���̻� ó������ �ʵ����ϱ�
    public bool isDie;

    //����
    public bool isHit = false;

    public int maxJump = 2;

    public float health;

    private void Start()
    {
        //���������� ������ ü���� �ʱ�ȭ ���� �ʰ� ���� ü���� ���������� �ϴ� ����
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

    //�ǰ��� �������
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.CompareTo("Block") == 0 && !DataManager.Instance.isMoon)
        {
            //���� ����
            if (!isHit)
            {
                AudioManager.aInstance.Play("Hit");
                DataManager.Instance.playTimeCurrent -= 2f;
                //StartCoroutine(HitEffect());
            }
            StartCoroutine(PlayerHit());

        }


    }

    //��ֹ��� ����� ��� ���� �Ÿ��� ȿ�� �� ����
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
