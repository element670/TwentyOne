using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _searchingOpponentMachine;
    [SerializeField] private GameObject _playersScoreList;

    [SerializeField] private GameObject _buttonHolder;
    
    [SerializeField] private Row _row;
    [SerializeField] private float _speed=150;

    [SerializeField] private ScrollManager _playerScroller;
    [SerializeField] private ScrollManager _aiScroller;

    [SerializeField] private TextMeshProUGUI _score;

    [SerializeField] private GameObject _resultPanel;
    [SerializeField] private GameObject _inputField;
    [SerializeField] private OKButton _okButton;

    // [SerializeField] private Button _buttonOne;
    // [SerializeField] private Button _buttonTwo;
    // [SerializeField] private Button _buttonThree;
    private void Start()
    {
        _okButton.OKButtonClick += DisableInputField;
    }

    public void SetActiveMainMenu()
    {
        _mainMenu.SetActive(false);
    }

    public void SetActivMachine(bool active)
    {
        _searchingOpponentMachine.SetActive(active);
    }

    public void SearchingOpponent(Action matchMaking)
    {
        _row.StartRotating(matchMaking, _speed);
    }

    public void ActivateScoreList(bool active)
    {
        _playersScoreList.SetActive(active);
    }

    public void SetInterectableButtons(bool interectable)
    {
        foreach (Transform button in _buttonHolder.transform)
        {
            button.GetComponent<Button>().interactable = interectable;
        }
    }
    public void ActivateButtons(bool active)
    {
        _buttonHolder.SetActive(active);
    }

    public void SetMyScore(int value)
    {
        _playerScroller.AddView(value.ToString());
    }

    public void SetAIScore(int value)
    {
        _aiScroller.AddView(value.ToString());
    }

    public void SetResult(int value)
    {
        _score.text = value.ToString();
    }

    public void ShowResultPanel(bool show)
    {
        _resultPanel.gameObject.SetActive(show);
    }

    public void ShowResultScore(bool show)
    {
        _score.gameObject.SetActive(show);
    }
   
    

    public void EmptyScoreList()
    {
        _playerScroller.EmptyContainer();
        _aiScroller.EmptyContainer();
    }

    public void DefaultDeactivatingGameObjects()
    {
        //main menu
        _mainMenu.gameObject.SetActive(false);
        
        //scroll view
        _aiScroller.gameObject.SetActive(false);
        _playerScroller.gameObject.SetActive(false);
        
        //scroll machine
        _searchingOpponentMachine.gameObject.SetActive(false);
        
        //buttons
        _buttonHolder.SetActive(false);
        
        //victory panel
        _resultPanel.gameObject.SetActive(false);
        //score text
        _score.gameObject.SetActive(false);
        //input field
        _inputField.SetActive(false);
        
        
    }

    public void MainMenu(){
        _mainMenu.SetActive(true);
    }

    public void ScrollMachine()
    {
        _searchingOpponentMachine.SetActive(true);
    }

    public void GameSetup()
    {
        DefaultDeactivatingGameObjects();
        _aiScroller.gameObject.SetActive(true);
        _playerScroller.gameObject.SetActive(true);
        _playersScoreList.gameObject.SetActive(transform);
        _score.gameObject.SetActive(true);
        SetInterectableButtons(true);
        _buttonHolder.SetActive(true);
    }

    public void ShowYourState()
    {
        _resultPanel.SetActive(true);
    }

    public void EnterNickname()
    {
        _inputField.SetActive(true);
    }

    public void DisableInputField()
    {
        _inputField.SetActive(false);
        _mainMenu.SetActive(true);
    }

    
}
