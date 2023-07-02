using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Respawn : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    public GameObject character;


    private void Start()
    {
        character = Instantiate(characterPrefabs[(int)DataManager.Instance.id]);
        character.transform.position = transform.position;
    }

 

   
}
