using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public Animator playerAnimatorController;
    public GameObject femaleCopBody;
    public GameObject maleCopBody;

    public Transform playerDanceCameraTransform;

    public static PlayerCharacter Instance;

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

}
