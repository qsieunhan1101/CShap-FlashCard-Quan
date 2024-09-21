using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasGamePlay : UICanvas
{
    [SerializeField] private TextMeshProUGUI textScore;
    [SerializeField] private TextMeshProUGUI textTurn;
    void Start()
    {
        
    }
    private void OnEnable()
    {
        GameLogicManager.updateScoreEvent += updateScore;
    }
    private void OnDisable()
    {
        GameLogicManager.updateScoreEvent -= updateScore;

    }
    public void updateScore(int score)
    {
        textScore.text = $"Score: {score.ToString()}";
    }

}
