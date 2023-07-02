using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameObject hitEffect;

    //public SpriteRenderer pRenderer;
    //죽으면 더이상 처리하지 않도록하기
    public bool isDie;


    public GameObject playerChar;
    private Character character;

    public Respawn respawn;

    public GameManager game;

    public GameObject fallGuard;

    //테스트
    private bool isButtonPressed = false;  // 버튼이 눌렸는지 여부를 나타내는 변수
    public float upForce = 1f;  // 위로 가해지는 힘의 크기

    private void Start()
    {
        //pRenderer = GetComponent<SpriteRenderer>();
        isDie = false;

        SetCharacter();

    }

    private void Update()
    {
        if (!isDie)
        {
            if (DataManager.Instance.playTimeCurrent <= 0 && character.isHit)
            {
                GameManager.Death(PlayerDie.TRAPDIE);
                character.playerAnim.SetInteger("pJump", 4);
                isDie = true;
            }
            else if (DataManager.Instance.playTimeCurrent <= 0)
            {
                GameManager.Death(PlayerDie.TIMEDIE);
                character.playerAnim.SetInteger("pJump", 3);
                isDie = true;
            }
        }

        
        if (DataManager.Instance.isMoon)
        {
            
            if (isButtonPressed)
            {
                ApplyUpwardForce();  // 버튼이 눌렸을 때 위로 힘을 가함
                
            }

        }

        MoonlightTime();

    }

    public void SetCharacter()
    {
        playerChar = respawn.character;

        character = playerChar.GetComponent<Character>();
    }

    public void JumpButton()
    {
        if (!DataManager.Instance.playerDie && !DataManager.Instance.isMoon)
        {
            /*if (character.jumpCount == 0) //점프를 안한 상태
            {
                AudioManager.aInstance.Play("Jump");
                playerChar.GetComponent<Rigidbody2D>().velocity = new Vector3(0, character.jump, 0);
                character.jumpCount += 1; //점프 1회 판정
                character.playerAnim.SetInteger("pJump", 1);

            }
            else if (character.jumpCount == 1) //점프 1번 함
            {
                AudioManager.aInstance.Play("Jump");
                playerChar.GetComponent<Rigidbody2D>().velocity = new Vector3(0, character.jump2, 0);
                character.jumpCount += 1;
                character.playerAnim.SetInteger("pJump", 2);
            }*/


            //캐릭터 점프 다르게
            if (character.jumpCount < character.maxJump)
            {
                if (character.jumpCount == 0)
                {
                    AudioManager.aInstance.Play("Jump");
                    playerChar.GetComponent<Rigidbody2D>().velocity = new Vector3(0, character.jump, 0);
                    character.jumpCount += 1; //점프 1회 판정
                    character.playerAnim.SetInteger("pJump", 1);
                }
                else
                {
                    AudioManager.aInstance.Play("Jump");
                    playerChar.GetComponent<Rigidbody2D>().velocity = new Vector3(0, character.jump2, 0);
                    character.jumpCount += 1;
                    character.playerAnim.SetInteger("pJump", 2);
                }
            }




        }

    }


    public void SlideButtonUp()
    {
        if (DataManager.Instance.isMoon)
        {
            isButtonPressed = false;
        }
        else
        {
            character.playerAnim.SetBool("isSlide", false);
        }
    }

    public void SlideButtonDown()
    {
        if (DataManager.Instance.isMoon)
        {
            isButtonPressed = true;
        }
        else
        {
            character.playerAnim.SetBool("isSlide", true);

            if (character.jumpCount == 0)
            {
                AudioManager.aInstance.Play("Slide");
            }

        }
    }


    //문라이트 능력
    void MoonlightTime()
    {
        if (DataManager.Instance.isMoon)
        {
            fallGuard.SetActive(true); //추락 방지
            character.playerAnim.SetBool("skill", true); //애니메이션
            DataManager.Instance.magnetCurrentTime = 0.1f; //템 다 먹는 능력
        }
        else
        {
            fallGuard.SetActive(false);
            character.playerAnim.SetBool("skill", false);
        }

    }

    //문라이트 전용
    public void ButtonDown()
    {
        if(DataManager.Instance.isMoon)
            isButtonPressed = true;
    }

    public void ButtonUp()
    {
        if (DataManager.Instance.isMoon)
            isButtonPressed = false;
    }

    //버튼을 눌렀을때 힘을 위로 받는 함수
    private void ApplyUpwardForce()
    {
        //playerChar.GetComponent<Rigidbody2D>().velocity = new Vector2(playerChar.GetComponent<Rigidbody2D>().velocity.x, upForce);


        playerChar.GetComponent<Rigidbody2D>().AddForce(Vector2.up * upForce, ForceMode2D.Impulse);
    }

}



