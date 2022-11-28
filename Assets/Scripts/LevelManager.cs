using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] levels;
    public GameObject currentLevelGO;
    public int currentLevelNumber;

    [SerializeField]
    private CameraFollow cameraFollow;

    public EasyObjectsFade objectFadeFollow;

    public static LevelManager Instance;

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
        if (!PlayerPrefs.HasKey("level"))
        {
            Debug.Log("First time");
            PlayerPrefs.SetInt("level", 0);
            currentLevelNumber = 0;
            InstantiateLevel(currentLevelNumber);

        }
        else
        {
            Debug.Log("Not First time");
            currentLevelNumber = PlayerPrefs.GetInt("level");

            if (currentLevelNumber > levels.Length - 1)
            {
                currentLevelNumber = 0;
                PlayerPrefs.SetInt("level", 0);
                InstantiateLevel(currentLevelNumber);

            }
            else
            {
                InstantiateLevel(currentLevelNumber);
            }

        }



    }


    public void InstantiateLevel(int currentLevel)
    {
        currentLevelGO = GameObject.Instantiate(levels[currentLevel]);
        cameraFollow.enabled = true;
    }


}
