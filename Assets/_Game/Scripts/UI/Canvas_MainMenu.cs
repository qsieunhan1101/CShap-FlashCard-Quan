using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas_MainMenu : UICanvas
{
    [SerializeField] private Button btnPlay;

    private void Start()
    {
        btnPlay.onClick.AddListener(OnPlay);
    }

    private void OnPlay()
    {
        GameManager.Instance.ChangeGameState(GameState.GamePlay);
        LevelManager.Instance.LoadLevel(LevelManager.Instance.CurrentLevel);
    }
}
