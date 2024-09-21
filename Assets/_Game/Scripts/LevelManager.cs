using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : Singleton<LevelManager>
{

    [SerializeField] private List<GameObject> levelPrefabs;
    [SerializeField] private Transform levelParent;

    private int currentLevel = 0;
    public int CurrentLevel => currentLevel;

  
    public void loadLevel(int level)
    {
        currentLevel++;
        destroyLevel();


        GameObject currentGameLevel = Instantiate(levelPrefabs[level], levelParent);
    }
    private void destroyLevel()
    {
        foreach (Transform child in levelParent)
        {
            Destroy(child.gameObject);
        }
    }


}
