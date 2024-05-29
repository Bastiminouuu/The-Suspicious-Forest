using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource SFXSource;

    [Header("-------------AUDIO CLIP--------------")]
    public AudioClip MusicClip;
    public AudioClip CoinSound;
    public AudioClip JumpSound;
    public AudioClip JumpChampiSound;
    public AudioClip FallSound;
    public AudioClip AddVieSound;
    public AudioClip CheckpointSound;
    public AudioClip DamageSound;
    public AudioClip EnemyDie;
    public AudioClip PlayerDie;

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

}
