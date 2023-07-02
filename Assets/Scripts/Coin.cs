using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject player;

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
        if (collision.gameObject.tag.CompareTo("Player") == 0)
        {
            if (!DataManager.Instance.playerDie)
            {
                DataManager.Instance.coin += 1;
                AudioManager.aInstance.Play("EatCoin");
            }

            gameObject.SetActive(false);
        }

    }
}
