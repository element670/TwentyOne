using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private UIController _uiController;
    [SerializeField] private TextMeshProUGUI _helloPlayer;

    [SerializeField] private RestartGame _yesButton;
    [SerializeField] private Quit _noButton;
    
    public static GameState _gameState = GameState.MENU;
    private static int _aiScore = 0;
    private static Player currentPlayer = Player.ME;

    private static int _currentScore = 0;
    private void Start()
    {
        _uiController.DefaultDeactivatingGameObjects();
        _uiController.EnterNickname();
        // if (_gameState == GameState.MENU)
        // {
        //     _uiController.DefaultDeactivatingGameObjects();
        //     _uiController.MainMenu();
        //     _uiController.EnterNickname();
        // }
        
        _uiController.SetActivMachine(false);
        // _playButton.onClick.AddListener(() =>
        // {
        //     _uiController.SetActiveMainMenu(false);
        //     _uiController.SetActivMachine(true);
        //     GameBegins();
        // });

        PlayButton.PLAY_BUTTON += StartGame;
       
        _yesButton.yesClicked += Restart;
        _noButton.QUIT_GAME += QuittingGame;
        
        EventBus.Register<Buttons>(ButtonClick.ACTION, HandleButtons);
    }

    private void QuittingGame()
    {
        _uiController.DefaultDeactivatingGameObjects();
        _uiController.MainMenu();
    }
    private void GameBegins()
    {
        _uiController.DefaultDeactivatingGameObjects();
        _uiController.EmptyScoreList();
        _uiController.SearchingOpponent(() =>
        {
            _uiController.SetInterectableButtons(true);
        });
    }

    private void Restart()
    {
        StartGame();
    }

    private void StartGame()
    {
        DefaultSettings();
        _uiController.DefaultDeactivatingGameObjects();
        _uiController.EmptyScoreList();
        _uiController.ScrollMachine();
        _uiController.SearchingOpponent(() =>
        {
            _uiController.GameSetup();
        });
    }
    
    private void DefaultSettings()
    {
        _aiScore = 0;
        currentPlayer = Player.ME;
        _currentScore = 0;
        //_uiController.SetResult(_currentScore);
    }
    private int GetNumber(Buttons buttons)
    {
        switch (buttons)
        {
            case Buttons.ONE:
                return 1;
            case Buttons.TWO:
                return 2;
            case Buttons.THREE:
                return 3;
        }
        return 0;
    }
    private void HandleButtons(Buttons selectedButton)
    {
        var result = GetNumber(selectedButton);
        if (currentPlayer == Player.ME)
        {
            _uiController.SetMyScore(result);
            //  MyLogger.Logd("my selected button is: " + result);
        }
        else
        {
            _uiController.SetAIScore(result);
            // MyLogger.Logd("ai selected button is " + result);
        }

        _currentScore += result;
        _uiController.SetResult(_currentScore);
        
        if (currentPlayer == Player.ME)
            currentPlayer = Player.AI;
        else
            currentPlayer = Player.ME;

        if (_currentScore >= 20)
        {
            _uiController.SetInterectableButtons(false);
            if (currentPlayer == Player.AI)
            {
                Debug.Log("ai won");
            }
            else
            {
                Debug.Log("you lost");
                _uiController.ShowResultPanel(true);
                _uiController.SetResult(0);
            }
        }
        else
        {
            if (currentPlayer == Player.AI)
            {
                StartCoroutine(AiSelect());
                _uiController.SetInterectableButtons(false);
            }
            else
                _uiController.SetInterectableButtons(true);
        }
    }

    private IEnumerator AiSelect()
    {
        yield return new WaitForSeconds(2.5f);
        var aiSelection = GetAiMove();

        Buttons selectedButton = Buttons.ONE;
        switch (aiSelection)
        {
            case 2:
                selectedButton = Buttons.TWO;
                break;
            case 3:
                selectedButton = Buttons.THREE;
                break;
        }
        EventBus.Trigger(ButtonClick.ACTION, selectedButton);
    }
    private int GetAiMove()
    {
        int index = 0;
        int result = 0;

        _aiScore += 4;
        Debug.Log(_aiScore);
        for (int i = 1; i <= 3; i++)
        {
            result = _currentScore + i;
            if (result == _aiScore)
            {
                index = i;
                break;
            }

            if (result == 20 || result == 21)
            {
                index = i;
                break;
            }
        }

        return index;
    }
}

public enum Buttons
{
    ONE,
    TWO,
    THREE
}

public enum Player
{
    ME, AI
}

public enum GameState
{
    IDLE, MENU, PLAY, FINISH
}