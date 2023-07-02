using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectCharacter : MonoBehaviour
{
    //private Button button;
    public CharacterMenu characterMenu;

    //ĳ���Ͱ� ���õǾ����� �Ǵ�
    private bool isSelected = false;

    public List<GameObject> cookies;

    public Image image;

    private GameObject selectCharacter;

    public Sprite lockedSprite;

    private void Start()
    {
        selectCharacter = Instantiate(cookies[PlayerPrefs.GetInt("SaveId")]);

        //����� ĳ���� ��������
        for (int i = 0; i < cookies.Count; i++)
        {
            if (i == PlayerPrefs.GetInt("SaveId"))
            {
                cookies[i].GetComponent<MenuIdle>().isSelect = true;
                break;
            }
        }
    }


    public void OnDeSelect()
    {
        isSelected = false;

        for (int i = 0; i < cookies.Count; i++)
        {
            cookies[i].GetComponent<MenuIdle>().isSelect = false;
        }
    }

    public void OnSelect()
    {

        isSelected = true;                                                                                              // ���� ���¸� true�� ����
        image.sprite = cookies[characterMenu.currentCharacterIndex].GetComponent<MenuIdle>().characterSprite;           // �̹��� ��������Ʈ�� ������ ĳ������ ��������Ʈ�� ����
        DataManager.Instance.SaveId(cookies[characterMenu.currentCharacterIndex].GetComponent<MenuIdle>().characterId); // ������ ĳ������ ID�� ����
        Destroy(selectCharacter);                                                                                       // ������ ���õ� ĳ���� ������Ʈ�� �ı�
        selectCharacter = Instantiate(cookies[characterMenu.currentCharacterIndex]);                                    // ������ ĳ���͸� ���ο� ������Ʈ�� ����
        OnDeSelect();                                                                                                   // ���� ���� ó��
        cookies[characterMenu.currentCharacterIndex].GetComponent<MenuIdle>().isSelect = true;                          // ������ ĳ������ ���¸� ���õ� ���·� ����



    }




}
