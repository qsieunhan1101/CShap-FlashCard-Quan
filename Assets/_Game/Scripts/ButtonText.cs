using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonText : ButtonParent
{
  
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            StartCoroutine(flip(true));
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            StartCoroutine(flip(false));
        }
    }

}
