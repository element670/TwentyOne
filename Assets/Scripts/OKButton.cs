using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OKButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    public event Action OKButtonClick;

    private void Awake()
    {
        _button.onClick.AddListener(() =>
        {
            OKButtonClick?.Invoke();
        });
    }
}
