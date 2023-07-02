using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    public Animator arrowAnim;

    public GameObject player;

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    //���ư��� Ʈ���� ������ �ִϸ��̼�
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            arrowAnim.SetBool("arrowDie", true);
            Destroy(gameObject, 2f);
        }
    }
}
