using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour
{
    public List<MenuIdle> characters; // ĳ���� ������Ʈ ����Ʈ
    public int currentCharacterIndex = 0; // ���� ���̴� ĳ���� �ε���

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
        // ���� ���̴� ĳ���� ������Ʈ�� ��Ȱ��ȭ
        //characters[currentCharacterIndex].SetActive(false);


        //characters[currentCharacterIndex]

        // �ε��� ����
        currentCharacterIndex++;
        if (currentCharacterIndex >= characters.Count)
        {
            currentCharacterIndex = 0; // ������ ����� ó�� ĳ���ͷ� ���ư�     
        }

        ShowCurrentCharacter();
    }

    public void LeftButton()
    {
        AudioManager.aInstance.Play("Click");
        // ���� ���̴� ĳ���� ������Ʈ�� ��Ȱ��ȭ
        //characters[currentCharacterIndex].SetActive(false);

        // �ε��� ����
        currentCharacterIndex--;
        if (currentCharacterIndex < 0)
        {
            currentCharacterIndex = characters.Count - 1; // ������ ����� ������ ĳ���ͷ� ���ư�
        }

        ShowCurrentCharacter();
    }

    private void ShowCurrentCharacter()
    {
        // ���� ���̴� ĳ���� ������Ʈ�� Ȱ��ȭ
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
