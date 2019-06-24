using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource sound;

    [SerializeField]
    private AudioClip landClip , deathClip , iceBreakClip , gameOverClip;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public  void LandSound()
    {
        sound.clip = landClip;
        sound.Play();
    }
    public void IceBreakSound()
    {
        sound.clip = iceBreakClip;
        sound.Play();
    }
    public void DeathSound()
    {
        sound.clip = deathClip;
        sound.Play();
    }
    public void GameOverSound()
    {
        sound.clip = gameOverClip;
        sound.Play();
    }

}
