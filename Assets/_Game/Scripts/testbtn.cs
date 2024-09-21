using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testbtn : MonoBehaviour
{
    [SerializeField] private Button btn;
    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(test);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void test()
    {
        UIManager.Instance.CloseAll();
    }
}
