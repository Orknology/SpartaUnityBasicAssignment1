using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterClass
{
    Penguin,
    Knight
}

[System.Serializable]
public class Character
{
    public CharacterClass CharacterClass;
    public Sprite CharacterSprite;
    public RuntimeAnimatorController AnimatorController;
}
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Animator PlayerAnimator;

    public List<Character> CharacterList = new List<Character>();

    public void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    public void SetCharacter(CharacterClass characterClass)
    {
        var character = GameManager.instance.CharacterList.Find(item => item.CharacterClass == characterClass);

        PlayerAnimator.runtimeAnimatorController = character.AnimatorController;
    }
}
