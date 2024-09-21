using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;

public class CanvasManager : Singleton<CanvasManager>
{
    [SerializeField] private TextMeshProUGUI textScore;
    [SerializeField] private TextMeshProUGUI textTurnNumber;
    private int score;
    private int turnNumber;


    [SerializeField] public GameObject gamePlayUi;
    [SerializeField] public GameObject menuUi;
    [SerializeField] public GameObject blockInputUi;


    public int Score { get => score; }


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setScore(int score)
    {
        this.score = score;
        textScore.text = $"Score: {Score.ToString()}" ;
    }
    public void setTurnNumber(int turnNumber)
    {
        this .turnNumber = turnNumber;
        textTurnNumber.text = $"Turn: {turnNumber.ToString()}";
    }

    
}
