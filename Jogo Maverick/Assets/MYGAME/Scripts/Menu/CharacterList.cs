using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class CharacterList : MonoBehaviour
{
    public static CharacterList Instance = null;
    [SerializeField] List<CharacterStats> characters = new List<CharacterStats>();

    private int SelectedCharIndex;
    public int SelectCharIndex
    {
        get{ return SelectedCharIndex;}
        set
        {
            if(value < 0) return;
            if(value >= characters.Count) return;

            SelectCharIndex = value;
        }
    } 

    internal CharacterStats currentCharacter;



    void Awake()
    {
        Instance = this;
    }

    public CharacterStats GetPrevious()
    {
        var index = SelectCharIndex - 1;
        if(index < 0) return null;
        return characters[index];
    }
    public CharacterStats GetNext()
    {
        var index = SelectCharIndex + 1;
        if(index >= characters.Count) return null;
        return characters[index];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
