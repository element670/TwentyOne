using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quit : MonoBehaviour
{
    public  event Action QUIT_GAME;
    [SerializeField] private Button _button;

    private void Awake()
    {
        _button.onClick.AddListener(() =>
        {
            QUIT_GAME?.Invoke();
            Debug.Log("No button clicked");
        });
    }
}
