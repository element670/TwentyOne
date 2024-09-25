using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static GameController;
public class PlayButton : MonoBehaviour
{
    public static event Action PLAY_BUTTON;
    [SerializeField] private Button _button;
    private void Awake()
    {
        _button.onClick.AddListener(() =>
        {
            PLAY_BUTTON?.Invoke();
            Debug.Log("Play button is clicked");
            _gameState = GameState.PLAY;
        });
    }
}
