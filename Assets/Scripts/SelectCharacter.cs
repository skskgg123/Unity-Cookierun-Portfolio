using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectCharacter : MonoBehaviour
{
    //private Button button;
    public CharacterMenu characterMenu;

    //캐릭터가 선택되었는지 판단
    private bool isSelected = false;

    public List<GameObject> cookies;

    public Image image;

    private GameObject selectCharacter;

    public Sprite lockedSprite;

    private void Start()
    {
        selectCharacter = Instantiate(cookies[PlayerPrefs.GetInt("SaveId")]);

        //저장된 캐릭터 가져오기
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

        isSelected = true;                                                                                              // 선택 상태를 true로 설정
        image.sprite = cookies[characterMenu.currentCharacterIndex].GetComponent<MenuIdle>().characterSprite;           // 이미지 스프라이트를 선택한 캐릭터의 스프라이트로 변경
        DataManager.Instance.SaveId(cookies[characterMenu.currentCharacterIndex].GetComponent<MenuIdle>().characterId); // 선택한 캐릭터의 ID를 저장
        Destroy(selectCharacter);                                                                                       // 기존에 선택된 캐릭터 오브젝트를 파괴
        selectCharacter = Instantiate(cookies[characterMenu.currentCharacterIndex]);                                    // 선택한 캐릭터를 새로운 오브젝트로 생성
        OnDeSelect();                                                                                                   // 선택 해제 처리
        cookies[characterMenu.currentCharacterIndex].GetComponent<MenuIdle>().isSelect = true;                          // 선택한 캐릭터의 상태를 선택된 상태로 설정



    }




}
