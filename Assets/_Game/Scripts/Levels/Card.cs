using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private GameObject imgText;
    [SerializeField] private Button btnCard;
    [SerializeField] private CardType currentCardType;
    [SerializeField] private int cardId;
    [SerializeField] private GameObject backCardImg;
    [SerializeField] private LevelLogic levelLogic;
    public int CardId => cardId;

    private void Start()
    {
        btnCard.onClick.AddListener(OnClickSelf);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            FlipUp();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            FlipDown();
        }
    }

    private void OnClickSelf()
    {
        FlipUp();
        levelLogic.SetCard(this);
    }

    public void FlipUp()
    {
        StartCoroutine(Flip(true));

    }
    public void FlipDown()
    {
        StartCoroutine(Flip(false));

    }


    private IEnumerator Flip(bool isFlip)
    {
        if (isFlip == true)
        {
            for (float i = 0; i <= 180f; i += 10f)
            {

                rectTransform.rotation = Quaternion.Euler(0, i, 0);
                if (i == 90)
                {
                    imgText.SetActive(true);
                    backCardImg.SetActive(false);
                }
                yield return new WaitForSeconds(0.01f);
            }

        }
        else
        {
            for (float i = 180; i >= 0f; i -= 10f)
            {

                rectTransform.rotation = Quaternion.Euler(0, i, 0);
                if (i == 90)
                {
                    imgText.SetActive(false);
                    backCardImg.SetActive(true);
                }
                yield return new WaitForSeconds(0.01f);
            }

        }
    }
}
