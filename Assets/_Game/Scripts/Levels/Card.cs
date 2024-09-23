using Palmmedia.ReportGenerator.Core.Reporting.Builders;
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
    [SerializeField] private Animator anim;
    [SerializeField] private Image cusorImg;
    [SerializeField] private AudioSource audioCard;
    [SerializeField] private AudioSource audioCusor;

    private Vector3 currentRectTransformPos;

    public int CardId => cardId;

    private void Start()
    {
        btnCard.onClick.AddListener(OnClickSelf);
    }

    private void OnClickSelf()
    {
        StartCoroutine(FlipUp());
        levelLogic.SetCard(this);
        audioCard.Play();
    }

    public IEnumerator FlipUp()
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
    public IEnumerator FlipDown()
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

    //Tham khao
    /* private IEnumerator Flip(bool isFlip)
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
     }*/


    public IEnumerator VibrateCard()
    {
        currentRectTransformPos = rectTransform.anchoredPosition;

        for (int i = 0; i <= 2; i++)
        {
            WaitForSeconds wait = new WaitForSeconds(0.05f);
            float offset = 30f;
            rectTransform.anchoredPosition = new Vector2(currentRectTransformPos.x + offset, currentRectTransformPos.y + offset);
            yield return wait;                                                       
            rectTransform.anchoredPosition = new Vector2(currentRectTransformPos.x - offset, currentRectTransformPos.y);
            yield return wait;                                                       
            rectTransform.anchoredPosition = new Vector2(currentRectTransformPos.x - offset, currentRectTransformPos.y - offset);
            yield return wait;                                                       
            rectTransform.anchoredPosition = new Vector2(currentRectTransformPos.x + offset, currentRectTransformPos.y );
        }

        rectTransform.anchoredPosition = currentRectTransformPos;

    }

    public void CusorActive(bool isActive)
    {
        cusorImg.gameObject.SetActive(isActive);
        anim.enabled = isActive;
        if (isActive == true)
        {
            audioCusor.Play();
        }
    }
}
