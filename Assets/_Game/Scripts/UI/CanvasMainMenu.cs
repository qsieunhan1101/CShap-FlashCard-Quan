using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvanMainMenu : UICanvas
{
    [SerializeField] private Button btnPlay;

    void Start()
    {
        btnPlay.onClick.AddListener(onPlay);
    }

    private void onPlay()
    {
        UIManager.Instance.OpenUI<CanvasBlockKey>();
        UIManager.Instance.CloseAll();
        UIManager.Instance.OpenUI<CanvasGamePlay>();
        LevelManager levelManager = LevelManager.Instance;
        levelManager.loadLevel(0);
    } 
}
