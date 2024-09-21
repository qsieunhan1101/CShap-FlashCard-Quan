using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestButton : MonoBehaviour
{

    [SerializeField] private Button button;
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(testButton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void testButton()
    {
        Debug.Log("AN DUOC BUTTON");
    }
}
