using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
public class UI_InputWindow : MonoBehaviour
{
    public static string PlayerNickName = "";
    [SerializeField] private TMP_InputField _tmpInput;
    [SerializeField] private OKButton _okButton;
    [SerializeField] private TextMeshProUGUI _playerName;

    private void Start()
    {
        _tmpInput.onValidateInput += (text, index, addedChar) => ValidateString(addedChar, text);
        _okButton.OKButtonClick += GetNickName;
    }

    public void GetNickName()
    {
        _playerName.text = _tmpInput.text;
    }
    
    public char ValidateString(char addedChar, string str)
    {
        if (Char.IsDigit(addedChar) || Char.IsSymbol(addedChar) || str.Length >= 12 || Char.IsWhiteSpace(addedChar))
            return '\0';
        else
            return addedChar;
    }
}
