using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    static AudioClip virusHitSound, playerHitSound, gameOverSound, winSound;
    static AudioSource audioSrc;

    void Start()
    {
        playerHitSound = Resources.Load<AudioClip>("Adiosvidas");
        gameOverSound = Resources.Load<AudioClip>("gameOver");
        virusHitSound = Resources.Load<AudioClip>("SoundFX/explosion");
        winSound = Resources.Load<AudioClip>("win-sound");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip) {
        switch (clip)
        {
            case "playerHit":
                audioSrc.PlayOneShot(playerHitSound);
                break;
            case "gameOver":
                audioSrc.PlayOneShot(gameOverSound);
                break;
            case "virusHit":
                audioSrc.PlayOneShot(virusHitSound);
                break;
            case "win":
                audioSrc.PlayOneShot(winSound);
                break;
            default:
                break;
        }
    }
}
