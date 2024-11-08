using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField] CharacterPanel characterPanelLeft;
    [SerializeField] CharacterPanel characterPanelRight;
    [SerializeField] CharacterPanel characterPanelMiddle;

    void Start()
    {
        CharacterList.Instance.SelectCharIndex = 0;
        UpdateCharacterPanel();
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("left");
            CharacterList.Instance.SelectCharIndex--;
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("right");
            CharacterList.Instance.SelectCharIndex++;
        }
    }

    private void UpdateCharacterPanel()
    {
        characterPanelLeft.UpdateCharacterPanel(CharacterList.Instance.GetPrevious());
        characterPanelMiddle.UpdateCharacterPanel(CharacterList.Instance.currentCharacter);
        characterPanelRight.UpdateCharacterPanel(CharacterList.Instance.GetNext());
    }
}
