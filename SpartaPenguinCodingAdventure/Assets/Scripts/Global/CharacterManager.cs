using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Threading;

public class CharacterManager : MonoBehaviour
{
    //�̸� ����
    [SerializeField] private TMP_InputField playerNameInput;
    private string playerName;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text placeHolderText;

    [SerializeField] private GameObject NameSelectCanvas;

    //ĳ���� ����
    [SerializeField] private GameObject CharSelectCanvas;
    [SerializeField] private Image characterSprite;

    private CharacterClass characterClass;

    public void Awake()
    {
        Time.timeScale = 0.0f;
    }
    public void Close()
    {
        Thread.Sleep(200);
        Time.timeScale = 1.0f;
        CharSelectCanvas.SetActive(false);
        NameSelectCanvas.SetActive(false);
    }
    public void OnBtnJoin()
    {
        playerName = playerNameInput.GetComponent<TMP_InputField>().text;
        if (playerName.Length > 1)
        {
            nameText.text = playerNameInput.GetComponent<TMP_InputField>().text;
            Close();
        }
        else
            placeHolderText.text = "�߸��� �̸� �Դϴ�!";
        //���� ���⼭�� ���������� NetworkManager������ 2���� �̸� �̸��� �Էµǰ� ����
    }
    public void OnCharSelect(int index)
    {
        characterClass = (CharacterClass)index;
        var character = GameManager.instance.CharacterList.Find(item => item.CharacterClass == characterClass);

        characterSprite.sprite = character.CharacterSprite;
        characterSprite.SetNativeSize();

        GameManager.instance.SetCharacter(characterClass);

        Close();
    }
}
