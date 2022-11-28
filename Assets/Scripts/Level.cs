using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public List<GameObject> protestors = new List<GameObject>();

    public bool isLevelCompleted = false;
    public GameObject playerPrefab;

    public Transform playerSpawnPosition;

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
