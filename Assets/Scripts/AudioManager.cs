using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField] private AudioSource gameplayMusic;
    [SerializeField] private AudioSource hitSound;
    [SerializeField] private AudioSource levelCompleteCelebration;

    #region  SingleTon

    public static AudioManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(this.gameObject);
            return;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    #endregion

    public void PlayHitSound()
    {
        hitSound.Play();
    }

    public void PlayLevelCompleteCelebrationSound()
    {
        levelCompleteCelebration.Play();
    }

    public void StopLevelCompleteCelebrationSound()
    {
        levelCompleteCelebration.Stop();
    }
}
