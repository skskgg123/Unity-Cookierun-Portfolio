using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameObject hitEffect;

    //public SpriteRenderer pRenderer;
    //������ ���̻� ó������ �ʵ����ϱ�
    public bool isDie;


    public GameObject playerChar;
    private Character character;

    public Respawn respawn;

    public GameManager game;

    public GameObject fallGuard;

    //�׽�Ʈ
    private bool isButtonPressed = false;  // ��ư�� ���ȴ��� ���θ� ��Ÿ���� ����
    public float upForce = 1f;  // ���� �������� ���� ũ��

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
                ApplyUpwardForce();  // ��ư�� ������ �� ���� ���� ����
                
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
            /*if (character.jumpCount == 0) //������ ���� ����
            {
                AudioManager.aInstance.Play("Jump");
                playerChar.GetComponent<Rigidbody2D>().velocity = new Vector3(0, character.jump, 0);
                character.jumpCount += 1; //���� 1ȸ ����
                character.playerAnim.SetInteger("pJump", 1);

            }
            else if (character.jumpCount == 1) //���� 1�� ��
            {
                AudioManager.aInstance.Play("Jump");
                playerChar.GetComponent<Rigidbody2D>().velocity = new Vector3(0, character.jump2, 0);
                character.jumpCount += 1;
                character.playerAnim.SetInteger("pJump", 2);
            }*/


            //ĳ���� ���� �ٸ���
            if (character.jumpCount < character.maxJump)
            {
                if (character.jumpCount == 0)
                {
                    AudioManager.aInstance.Play("Jump");
                    playerChar.GetComponent<Rigidbody2D>().velocity = new Vector3(0, character.jump, 0);
                    character.jumpCount += 1; //���� 1ȸ ����
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


    //������Ʈ �ɷ�
    void MoonlightTime()
    {
        if (DataManager.Instance.isMoon)
        {
            fallGuard.SetActive(true); //�߶� ����
            character.playerAnim.SetBool("skill", true); //�ִϸ��̼�
            DataManager.Instance.magnetCurrentTime = 0.1f; //�� �� �Դ� �ɷ�
        }
        else
        {
            fallGuard.SetActive(false);
            character.playerAnim.SetBool("skill", false);
        }

    }

    //������Ʈ ����
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

    //��ư�� �������� ���� ���� �޴� �Լ�
    private void ApplyUpwardForce()
    {
        //playerChar.GetComponent<Rigidbody2D>().velocity = new Vector2(playerChar.GetComponent<Rigidbody2D>().velocity.x, upForce);


        playerChar.GetComponent<Rigidbody2D>().AddForce(Vector2.up * upForce, ForceMode2D.Impulse);
    }

}



