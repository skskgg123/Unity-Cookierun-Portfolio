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

    //날아가는 트랩이 죽을때 애니메이션
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            arrowAnim.SetBool("arrowDie", true);
            Destroy(gameObject, 2f);
        }
    }
}
