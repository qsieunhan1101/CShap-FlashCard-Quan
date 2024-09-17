using System.Collections;
using UnityEngine;

public class GameLogicManager : Singleton<GameLogicManager>
{
    [SerializeField] private ButtonParent button_1;
    [SerializeField] private ButtonParent button_2;
    [SerializeField] private int count = 0;

    private void Update()
    {
        if (count == 2)
        {
            compareKey();
            StartCoroutine(compareKey());
            count = 0;
        }
    }

    public void setButtonValue(ButtonParent btn)
    {
        if (count == 0)
        {
            button_1 = btn;
            count = 1;
            return;
        }
        if (count == 1)
        {
            button_2 = btn;
            count = 2;
        }
    }
    private IEnumerator compareKey()
    {
        if (button_1 != null && button_2 != null)
        {
            if (button_1.getKey() == button_2.getKey())
            {
                Debug.Log("So sanh dung");
                yield return new WaitForSeconds(1);
                button_1.gameObject.SetActive(false);
                button_2.gameObject.SetActive(false);
                resetSelect();
                CanvasManager.Instance.setScore();
            }
            else
            {
                Debug.Log("So sanh sai");
                yield return new WaitForSeconds(1);
                button_1.flipDown();
                button_2.flipDown();
                resetSelect();
            }

        }
    }

    private void resetSelect()
    {
        
        button_1 = null;
        button_2 = null;
    }
}
