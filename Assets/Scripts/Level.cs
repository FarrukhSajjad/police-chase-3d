using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

    public bool isLevelCompleted = false;
    public GameObject playerPrefab;

    public Transform playerSpawnPosition;

    public bool showAdAfterThisLevel;

    public int enemiesInThisLevel;

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

        UIManager.Instance.totalEnemiesToKillText.text = $"{enemiesInThisLevel}";
    }

    private void Update()
    {
        if (!isLevelCompleted && enemiesInThisLevel == 0)
        {
            Debug.Log("Level is completed");
            var levelCompletedNumber = LevelManager.Instance.currentLevelNumber++;
            PlayerPrefs.SetInt("level", LevelManager.Instance.currentLevelNumber++);
            UIManager.Instance.gameplayPanel.SetActive(false);
            PlayerCharacter.Instance.gameObject.GetComponent<PlayerMovement>().enabled = false;
            PlayerCharacter.Instance.playerAnimatorController.SetBool("isMoving", false);
            Destroy(UIManager.Instance.offscreenPanelIndicator);
            //GameManager.Instance.playerDanceCamera.m_Priority = 11;
        //UIManager.Instance.levelCompletePanel.SetActive(true);

            // PlayerCharacter.Instance.playerAnimatorController.SetBool("dance", true);
            StartCoroutine(DelayInShowingLevelCompeletePanel());
            isLevelCompleted = true;
        }
    }

    private IEnumerator DelayInShowingLevelCompeletePanel()
    {
        yield return new WaitForSeconds(1f);
        UIManager.Instance.levelCompletePanel.SetActive(true);
    }

}
