using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuIdle : MonoBehaviour
{
    public Animator animator;

    public int characterId;
    public string characterName;
    public Sprite characterSprite;
    public Sprite characterReady;
    public bool isSelect;

    public Sprite sprite
    {
        get { return characterSprite; }
        
    }

    public void Idle()
    {
        animator.SetInteger("isBlink", 0);
    }



}
