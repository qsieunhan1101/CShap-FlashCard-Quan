using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUi : MonoBehaviour
{
    [SerializeField] private Button btnPlay;

    // Start is called before the first frame update
    void Start()
    {
        btnPlay.onClick.AddListener(onPlayGame);
    }
    void onPlayGame()
    {
        CanvasManager canvasManager = CanvasManager.Instance;
        canvasManager.menuUi.SetActive(false);
        canvasManager.gamePlayUi.SetActive(true);

        LevelManager levelManager = LevelManager.Instance;
    }
}
