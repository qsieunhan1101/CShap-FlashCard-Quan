using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private GameState currentGameState;
    public GameState CurrentGameState => currentGameState;

    private void Start()
    {
        UIManager.Instance.OpenUI<Canvas_MainMenu>();
    }


    public void ChangeGameState(GameState newState)
    {
        currentGameState = newState;
        switch (newState)
        {
            case GameState.MainMenu:
                MainMenuState();
                break;
            case GameState.GamePlay:
                GamePlayState();
                break;
            case GameState.Victory:
                VictoryState();
                break;
            case GameState.Fail:
                FailState();
                break;
        }
    }


    private void MainMenuState()
    {
        UIManager.Instance.CloseAll();
        UIManager.Instance.OpenUI<Canvas_MainMenu>();
    }
    private void VictoryState()
    {
        UIManager.Instance.OpenUI<Canvas_Victory>();
    }
    private void FailState()
    {
        UIManager.Instance.OpenUI<Canvas_Fail>();

    }
    private void GamePlayState()
    {
        UIManager.Instance.CloseAll();
        UIManager.Instance.OpenUI<Canvas_GamePlay>();
        
    }
}
