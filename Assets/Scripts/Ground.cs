using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public float moveSpeed = 10f;

    private void Update()
    {
        if (!DataManager.Instance.playerDie)
        {
            transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
        }
    }
}
