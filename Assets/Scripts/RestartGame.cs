using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RestartGame : MonoBehaviour
{
    [SerializeField] private Button _button;
    public event Action yesClicked;
    private void Awake()
    {
        _button.onClick.AddListener(() =>
        {
            yesClicked?.Invoke();
        });
    }
    
}
