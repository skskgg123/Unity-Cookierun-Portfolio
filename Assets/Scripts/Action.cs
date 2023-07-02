using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    public Animator playerAnim;
    public bool isFLy;
    public GameObject player;

    private void Start()
    {
        isFLy = false;
    }

    //�����ϴ� ��ư
    public void Jump()
    {
        playerAnim.SetInteger("isJump", 1);
        //�̴� ���� ����
        if(isFLy)
        {
            playerAnim.SetInteger("isJump", 2);
        }
    }

    //�����̵� ��ư
    public void Slide()
    {
        playerAnim.SetBool("isSlide", true);
    }

    //�⺻ �޸���
    public void Idle()
    {
        playerAnim.SetBool("isSlide", false);
    }

}
