using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject player;

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("PlayerPosition");

        //자기 자신의 위치와 플레이어의 위치값 distance
        float distance = Vector2.Distance(gameObject.transform.position, player.transform.position);

        //게임오버가 아니고, 자석 아이템의 유효시간 이라면
        if (DataManager.Instance.playerDie == false && DataManager.Instance.magnetCurrentTime > 0)
        {
            //아이템과 플레이어의 거리를 6보다 작을 경우로 설정
            if (distance < 6)
            {
                Vector2 dir = player.transform.position - transform.position;
                //nomalized = 0 ~ 1로 비율을 바꿔주는 것
                //Space.World 전체 좌표 기준, Space.Self 자기 좌표 기준
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
