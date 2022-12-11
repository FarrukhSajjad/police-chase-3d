using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject offscreenPanelIndicator;

    public TextMeshProUGUI levelNumberText;
    public TextMeshProUGUI totalEnemiesToKillText;

    [Space(10)]
    [Header("UI Panels")]
    public GameObject mainMenuPanel;
    public GameObject gameplayPanel;
    public GameObject levelCompletePanel;

    [Space(10)]
    [Header("Buttons")]
    public Button playButton;
    public Button nextButton;

    public static UIManager Instance;

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
        playButton.onClick.AddListener(() =>
               {
                   OnPlayButtonPressed();
               });


        nextButton.onClick.AddListener(() =>
        {
            OnNextButtonPressed();
        });
    }

    private void OnPlayButtonPressed()
    {
        GameManager.Instance.isGameStarted = true;
        mainMenuPanel.SetActive(false);
        gameplayPanel.SetActive(true);
        offscreenPanelIndicator.GetComponent<OffScreenIndicator>().enabled = true;
    }

    private void OnNextButtonPressed()
    {
        Destroy(LevelManager.Instance.currentLevelGO);
        SceneManager.LoadScene(1);
    }
}
