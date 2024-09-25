using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    public static readonly string ACTION = "BUTTON_CLICK";
    
    [SerializeField] private Buttons _selectedButton;
    [SerializeField] private Button _button;

    private void Awake()
    {
        _button.onClick.AddListener(() =>
        {
            EventBus.Trigger(ACTION, _selectedButton);
        });
    }
}
