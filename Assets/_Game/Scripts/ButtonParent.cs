using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum ButtonType
{
    Text = 0,
    Image = 1,
}

public class ButtonParent : MonoBehaviour
{
    [SerializeField] protected Button btnSelf;
    [SerializeField] protected RectTransform rectTransform;
    [SerializeField] protected GameObject imgText;

    [SerializeField] protected string key;

    [SerializeField] protected ButtonType buttonType;


    private void Start()
    {
        btnSelf.onClick.AddListener(onClickSelf);

    }

    protected void onClickSelf()
    {
        StartCoroutine(flip(true));
        GameLogicManager.Instance.setButtonValue(this);
    }

    protected IEnumerator flip(bool turn)
    {
        if (turn == true)
        {
            for (float i = 0; i <= 180f; i += 10f)
            {

                rectTransform.rotation = Quaternion.Euler(0, i, 0);
                if (i == 90)
                {
                    imgText.SetActive(true);
                }
                yield return new WaitForSeconds(0.01f);
            }
            Debug.Log("flip true");

        }
        else
        {
            for (float i = 180; i >= 0f; i -= 10f)
            {

                rectTransform.rotation = Quaternion.Euler(0, i, 0);
                if (i == 90)
                {
                    imgText.SetActive(false);
                }
                yield return new WaitForSeconds(0.01f);
            }
            Debug.Log("flip false");

        }


    }

    public ButtonType getButtonType()
    {
        return buttonType;
    }

    public string getKey()
    {
        return key;
    }
    public void flipDown()
    {
        StartCoroutine(flip(false));
    }
}
