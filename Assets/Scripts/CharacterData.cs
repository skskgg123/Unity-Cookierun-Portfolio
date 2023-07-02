using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData : MonoBehaviour
{
    public int characterId;
    public string characterName;
    public Sprite characterSprite;

    public Sprite sprite
    {
        get { return characterSprite; }
    }
}
