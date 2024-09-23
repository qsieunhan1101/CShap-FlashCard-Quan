using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLogic : MonoBehaviour
{
    [SerializeField] private List<Card> listCards;
    [SerializeField] private List<RectTransform> listCardPositions;
    [SerializeField] private Animator anim;
    [SerializeField] private string currentAnimName;

    [SerializeField] private List<AudioSource> listAudios;


    [SerializeField] private Card card_1;
    [SerializeField] private Card card_2;
    private int quantityCard = 0;
    private int flipTurn = 3;
    private int flipScore = 0;

    private float timeNonInteract = 0;
    private bool isCusorActive = false;
    private bool isGamePlay = false;


    public static Action<int> updateFlipTurnUI;




    private void Start()
    {
        StartCoroutine(Shuffle());
        OnInit();

    }
    private void Update()
    {
        if (quantityCard == 0 && isGamePlay == true)
        {
            timeNonInteract += Time.deltaTime;
        }
        if (timeNonInteract >= 5.0f)
        {
            timeNonInteract = 0;
            if (isCusorActive == false)
            {
                ActiveCardCusor();
            }
        }
    }


    private void OnInit()
    {
        flipTurn = 3;
        flipScore = 0;
        if (updateFlipTurnUI != null)
        {
            updateFlipTurnUI(flipTurn);
        }
        DeactiveCardCusor();
    }

    private void PlayAudioClip(int soundNumber)
    {
        listAudios[soundNumber].Play();
    }
    private IEnumerator Shuffle()
    {
        UIManager.Instance.OpenUI<Canvas_BlockInput>();
        yield return new WaitForSeconds(1.0f);
        for (int i = 0; i < listCards.Count; i++)
        {
            StartCoroutine(listCards[i].FlipUp());
        }
        yield return new WaitForSeconds(1.0f);
        for (int i = 0; i < listCards.Count; i++)
        {
            StartCoroutine(listCards[i].FlipDown());
        }
        yield return new WaitForSeconds(1.0f);
        ChangeAnim(Constant.Amim_Shuffle);
        yield return new WaitForSeconds(2.0f);
        RandomCardPosition();
        UIManager.Instance.CloseUI<Canvas_BlockInput>(0);

        isGamePlay = true;
    }

    private void RandomCardPosition()
    {

        anim.enabled = false;
        for (int i = listCardPositions.Count - 1; i > 0; i--)
        {
            int random = UnityEngine.Random.Range(0, i + 1);
            RectTransform temp = listCardPositions[i];
            listCardPositions[i] = listCardPositions[random];
            listCardPositions[random] = temp;
        }
        for (int i = 0; i < listCards.Count; i++)
        {
            listCards[i].GetComponent<RectTransform>().anchoredPosition = listCardPositions[i].anchoredPosition;
        }

    }

    private void ActiveCardCusor()
    {
        isCusorActive = true;
        for (int i = 0; i < listCards.Count; i++)
        {

            if (listCards[i].gameObject.activeSelf == true)
            {
                listCards[i].CusorActive(true);
                return;
            }
        }
    }
    private void DeactiveCardCusor()
    {
        isCusorActive = false;
        timeNonInteract = 0;
        for (int i = 0; i < listCards.Count; i++)
        {
            listCards[i].CusorActive(false);
        }
    }

    private void ChangeAnim(string animName)
    {
        if (currentAnimName != animName)
        {
            anim.ResetTrigger(animName);

            currentAnimName = animName;

            anim.SetTrigger(currentAnimName);
        }
    }

    private IEnumerator CompareCard()
    {
        if (quantityCard == 2)
        {
            WaitForSeconds waitCompare = new WaitForSeconds(1.5f);
            WaitForSeconds waitOpenUI = new WaitForSeconds(1f);
            UIManager.Instance.OpenUI<Canvas_BlockInput>();
            //so sanh dung
            if (card_1.CardId == card_2.CardId)
            {
                yield return new WaitForSeconds(0.7f);
                PlayAudioClip(0);
                yield return waitCompare;
                card_1.gameObject.SetActive(false);
                card_2.gameObject.SetActive(false);
                flipScore++;
                if (flipScore == 2)
                {
                    yield return waitOpenUI;
                    GameManager.Instance.ChangeGameState(GameState.Victory);
                }
            }
            //so sanh sai
            if (card_1.CardId != card_2.CardId)
            {
                yield return waitCompare;
                PlayAudioClip (UnityEngine.Random.Range(1, listAudios.Count));
                StartCoroutine(card_1.VibrateCard());
                StartCoroutine(card_2.VibrateCard());
                yield return new WaitForSeconds(1f);
                StartCoroutine(card_1.FlipDown());
                StartCoroutine(card_2.FlipDown());

                
                flipTurn--;
                if (updateFlipTurnUI != null)
                {
                    updateFlipTurnUI(flipTurn);
                }
                if (flipTurn == 0)
                {
                    yield return waitOpenUI;
                    GameManager.Instance.ChangeGameState(GameState.Fail);
                }
            }
            quantityCard = 0;
            UIManager.Instance.CloseUI<Canvas_BlockInput>(0);

        }
    }
    public void SetCard(Card card)
    {
        if (quantityCard == 2)
        {
            return;
        }
        if (quantityCard == 0)
        {
            card_1 = card;
            quantityCard = 1;
            DeactiveCardCusor();
            return;
        }
        if (quantityCard == 1)
        {
            card_2 = card;
            quantityCard = 2;
            StartCoroutine(CompareCard());
            return;
        }
    }

}
