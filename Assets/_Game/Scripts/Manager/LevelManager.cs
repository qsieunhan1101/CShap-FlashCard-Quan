using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private List<GameObject> levelPrefabs;
    [SerializeField] private Transform levelTransform;

    private int currentLevel = 0;
    public int CurrentLevel => currentLevel;

    private void Start()
    {
        currentLevel = 0;
    }

    public void LoadLevel(int levelNumber)
    {
        currentLevel = levelNumber;
        DestroyLevel();
        GameObject level = Instantiate(levelPrefabs[levelNumber]);
        level.transform.SetParent(UIManager.Instance.transform, false);
        levelTransform = level.transform;


    }

    private void DestroyLevel()
    {
        if (levelTransform != null)
        {
            Destroy(levelTransform.gameObject);
        }
    }

    public void NextLevel()
    {
        currentLevel++;
        if (currentLevel > levelPrefabs.Count-1)
        {
            GameManager.Instance.ChangeGameState(GameState.MainMenu);
            return;
        }
        LoadLevel(currentLevel);
    }

    public void ReloadLevel()
    {
        LoadLevel(currentLevel);
    }
}
