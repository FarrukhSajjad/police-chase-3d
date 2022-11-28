using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI levelNumberText;
    public TextMeshProUGUI totalEnemiesToKillText;

    [Space(10)]
    [Header("UI Panels")]
    public GameObject mainMenuPanel;
    public GameObject gameplayPanel;

    [Space(10)]
    [Header("Buttons")]
    public Button playButton;

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
    }

    private void OnPlayButtonPressed()
    {
        mainMenuPanel.SetActive(false);
        gameplayPanel.SetActive(true);

    }
}
