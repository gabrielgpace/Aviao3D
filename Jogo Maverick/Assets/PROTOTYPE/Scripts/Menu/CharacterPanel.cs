using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterPanel : MonoBehaviour
{
    [SerializeField] GameObject transparentPanel;
    [SerializeField] private bool showTransparentPanel = false;
    public Image charImage;
    public TMP_Text nameText;
    void Start()
    {
        transparentPanel.SetActive(showTransparentPanel);
    }

    void Update()
    {
        
    }

    internal void UpdateCharacterPanel(CharacterStats characterStats)
    {
        if(characterStats == null)
        {
            charImage.sprite = null;
            nameText.SetText("");
        }
        else
        {
            charImage.sprite = characterStats.face;
            nameText.SetText(characterStats.characterName);
        }
    }
}
