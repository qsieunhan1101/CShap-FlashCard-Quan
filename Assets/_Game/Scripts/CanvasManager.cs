using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasManager : Singleton<CanvasManager>
{
    [SerializeField] private TextMeshProUGUI textScore;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setScore()
    {
        score++;
        textScore.text = $"Score: {score.ToString()}" ;
    }
 
}
