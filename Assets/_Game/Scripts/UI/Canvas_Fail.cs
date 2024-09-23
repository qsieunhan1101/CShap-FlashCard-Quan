using UnityEngine;
using UnityEngine.UI;

public class Canvas_Fail : UICanvas
{
    [SerializeField] private Button btnReplay;

    private void Start()
    {
        btnReplay.onClick.AddListener(OnReplay);
    }
    private void OnEnable()
    {
        transform.SetAsLastSibling();
    }

    private void OnReplay()
    {
        Close(0);
        LevelManager.Instance.ReloadLevel();
    }
}

