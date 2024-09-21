using System;
using System.Collections;
using UnityEngine;

public class GameLogicManager : Singleton<GameLogicManager>
{
    [SerializeField] private ButtonParent button_1;
    [SerializeField] private ButtonParent button_2;
    [SerializeField] private int countCardFlip = 0;
    [SerializeField] private int turnNumber = 3;
    [SerializeField] private int score = 0;

    public int Score => score;

    public static Action<int> updateScoreEvent;
    private void Start()
    {
        UIManager.Instance.OpenUI<CanvanMainMenu>();
    }

    public void setButtonValue(ButtonParent btn)
    {
        if (countCardFlip == 0)
        {
            button_1 = btn;
            countCardFlip = 1;
            return;
        }
        if (countCardFlip == 1)
        {
            button_2 = btn;

            countCardFlip = 0;
            StartCoroutine(compareKey());
        }
    }
    private IEnumerator compareKey()
    {
        Debug.Log("111111111111111111111111111");
        UIManager.Instance.OpenUI<CanvasBlockKey>();
        if (button_1 != null && button_2 != null)
        {
            if (button_1.getKey() == button_2.getKey())
            {
                Debug.Log("So sanh dung");
                yield return new WaitForSeconds(1);
                button_1.gameObject.SetActive(false);
                button_2.gameObject.SetActive(false);
                resetSelect();
                score++;
                if (updateScoreEvent != null)
                {
                    updateScoreEvent(score);

                }
                if (score >= 2)
                {
                    score = 0;
                    UIManager.Instance.OpenUI<CanvasWin>();
                }

            }
            else
            {
                Debug.Log("So sanh sai");
                yield return new WaitForSeconds(1);
                button_1.flipDown();
                button_2.flipDown();
                resetSelect();
                turnNumber--;

                if (turnNumber <= 0)
                {
                    UIManager.Instance.OpenUI<CanvasFail>();

                }
            }

        }
        yield return new WaitForSeconds(0.3f);
        UIManager.Instance.CloseUI<CanvasBlockKey>(0);
        

    }

    private void resetSelect()
    {

        button_1 = null;
        button_2 = null;
    }

    public void resetScore()
    {
        score = 0;
        CanvasManager.Instance.setScore(score);
    }


}
