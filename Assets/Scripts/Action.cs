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

    //점프하는 버튼
    public void Jump()
    {
        playerAnim.SetInteger("isJump", 1);
        //이단 점프 구현
        if(isFLy)
        {
            playerAnim.SetInteger("isJump", 2);
        }
    }

    //슬라이드 버튼
    public void Slide()
    {
        playerAnim.SetBool("isSlide", true);
    }

    //기본 달리기
    public void Idle()
    {
        playerAnim.SetBool("isSlide", false);
    }

}
