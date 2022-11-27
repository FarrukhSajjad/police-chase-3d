using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public List<GameObject> protestors = new List<GameObject>();

    public bool isLevelCompleted = false;

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

    private void Update()
    {
        if (!isLevelCompleted && protestors.Count == 0)
        {
            Debug.Log("Level is completed");
            isLevelCompleted = true;
        }
    }

}
