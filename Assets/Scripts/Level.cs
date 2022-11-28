using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public List<GameObject> protestors = new List<GameObject>();

    public bool isLevelCompleted = false;
    public GameObject playerPrefab;

    public Transform playerSpawnPosition;

    public bool showAdAfterThisLevel;

    public int enemiesInThisLevel;

    public int enemiesKilled = 0;

    public static Level Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            return;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        //Spawn Player
        var player = Instantiate(playerPrefab, playerSpawnPosition.position, Quaternion.identity);
        LevelManager.Instance.objectFadeFollow.playerTransform = player.transform;
        var levelNumber = LevelManager.Instance.currentLevelNumber + 1;
        UIManager.Instance.levelNumberText.text = $"LEVEL {levelNumber}";

        enemiesInThisLevel = protestors.Count;
        UIManager.Instance.totalEnemiesToKillText.text = $"{enemiesKilled}/{enemiesInThisLevel}";
    }

    private void Update()
    {
        if (!isLevelCompleted && protestors.Count == 0)
        {
            Debug.Log("Level is completed");
            var levelCompletedNumber = LevelManager.Instance.currentLevelNumber++;
            PlayerPrefs.SetInt("level", LevelManager.Instance.currentLevelNumber++);
            isLevelCompleted = true;
        }
    }

}
