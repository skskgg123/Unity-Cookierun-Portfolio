using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetItem : MonoBehaviour
{
    public GameObject player;


    // Update is called once per frame
    void Update()
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
        if(!DataManager.Instance.playerDie)
        {
            if(collision.gameObject.tag.CompareTo("Player") == 0)
            {
                //���Ⱑ �ڼ� ������ Ȱ��ȭ �κ�
                DataManager.Instance.magnetCurrentTime = DataManager.Instance.magnetMaxTime;
                AudioManager.aInstance.Play("Magnet");
                gameObject.SetActive(false);
            }
        }
    }

}