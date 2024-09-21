using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasFail : UICanvas
{
    [SerializeField] private Button btnReplay;
    
    void Start()
    {
        btnReplay.onClick.AddListener(onReplay);
    }

    private void onReplay()
    {
        Close(0);

    }
}
