using UnityEngine;
using UnityEngine.UI;

public class Canvas_Victory : UICanvas
{
    [SerializeField] private Button btnNext;

    private void Start()
    {
        btnNext.onClick.AddListener(OnNext);
    }

    private void OnNext()
    {
        Close(0);
        LevelManager.Instance.NextLevel();
    }
}
