using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jelly : MonoBehaviour
{
    public GameObject player;

    public int point = 1;

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("PlayerPosition");

        //�ڱ� �ڽ��� ��ġ�� �÷��̾��� ��ġ�� distance
        float distance = Vector2.Distance(gameObject.transform.position, player.transform.position);

        //���ӿ����� �ƴϰ�, �ڼ� �������� ��ȿ�ð� �̶��
        if (DataManager.Instance.playerDie == false && DataManager.Instance.magnetCurrentTime > 0)
        {
            //�����۰� �÷��̾��� �Ÿ��� 6���� ���� ���� ����
            if (distance < 6)
            {
                Vector2 dir = player.transform.position - transform.position;
                //nomalized = 0 ~ 1�� ������ �ٲ��ִ� ��
                //Space.World ��ü ��ǥ ����, Space.Self �ڱ� ��ǥ ����
                transform.Translate(dir.normalized * DataManager.Instance.itemMoveSpeed * Time.deltaTime, Space.World);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.CompareTo("Player") == 0)
        {
            if (!DataManager.Instance.playerDie)
            {
                if (!DataManager.Instance.isMoon)
                {
                    DataManager.Instance.score += point;
                    //��� ������ �Ծ����� ���带 �޸��ϱ� ���� ��
                    if (point >= 3)
                    {
                        AudioManager.aInstance.Play("CarrotEat");
                    }
                    else
                        AudioManager.aInstance.Play("EatJelly");
                }
                else
                {
                    DataManager.Instance.score += point+1 ;
                    AudioManager.aInstance.Play("EatJelly");
                }
            }
      

            gameObject.SetActive(false);
        }
    }
}
