using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour
{
    public List<MenuIdle> characters; // 캐릭터 오브젝트 리스트
    public int currentCharacterIndex = 0; // 현재 보이는 캐릭터 인덱스

    public Image image;

    void Start()
    {
        currentCharacterIndex = PlayerPrefs.GetInt("SaveId");
        ShowCurrentCharacter();
        image.sprite = characters[currentCharacterIndex].characterSprite;
    }

    public void RightButton()
    {
        AudioManager.aInstance.Play("Click");
        // 현재 보이는 캐릭터 오브젝트를 비활성화
        //characters[currentCharacterIndex].SetActive(false);


        //characters[currentCharacterIndex]

        // 인덱스 증가
        currentCharacterIndex++;
        if (currentCharacterIndex >= characters.Count)
        {
            currentCharacterIndex = 0; // 범위를 벗어나면 처음 캐릭터로 돌아감     
        }

        ShowCurrentCharacter();
    }

    public void LeftButton()
    {
        AudioManager.aInstance.Play("Click");
        // 현재 보이는 캐릭터 오브젝트를 비활성화
        //characters[currentCharacterIndex].SetActive(false);

        // 인덱스 감소
        currentCharacterIndex--;
        if (currentCharacterIndex < 0)
        {
            currentCharacterIndex = characters.Count - 1; // 범위를 벗어나면 마지막 캐릭터로 돌아감
        }

        ShowCurrentCharacter();
    }

    private void ShowCurrentCharacter()
    {
        // 현재 보이는 캐릭터 오브젝트를 활성화
        //characters[currentCharacterIndex].SetActive(true);
        
        if(characters[currentCharacterIndex].isSelect)
        {
            image.sprite = characters[currentCharacterIndex].characterSprite;
        }
        else
        {
            image.sprite = characters[currentCharacterIndex].characterReady;
        }
    }

}
