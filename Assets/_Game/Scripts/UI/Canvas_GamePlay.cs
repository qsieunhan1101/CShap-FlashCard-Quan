using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Canvas_GamePlay : UICanvas
{
    [SerializeField] private TextMeshProUGUI textFlipTurn;


    private void OnEnable()
    {
        LevelLogic.updateFlipTurnUI += UpdateFlipTurnUI;
    }
    private void OnDisable()
    {
        LevelLogic.updateFlipTurnUI -= UpdateFlipTurnUI;

    }

    private void UpdateFlipTurnUI(int numberTurn)
    {
        textFlipTurn.text = $"Turn: {numberTurn}";
    }
}
