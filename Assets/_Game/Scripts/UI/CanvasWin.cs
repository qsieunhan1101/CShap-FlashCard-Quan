using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasWin : UICanvas
{
    [SerializeField] private Button btnNext;
    
    void Start()
    {
        btnNext.onClick.AddListener(onNext);
    }
    private void onNext()
    {
        Close(0);
        LevelManager levelManager = LevelManager.Instance;
        levelManager.loadLevel(levelManager.CurrentLevel);
        
    }

}
