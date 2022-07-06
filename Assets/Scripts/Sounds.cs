using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public List<AudioClip> myAudioClipsList = new List<AudioClip>();
    public AudioSource audioSource;
    public AudioClip collisionSoundClip;
    public AudioClip victorySoundClip;

    public void goal_sound_clip() {
        audioSource.clip = myAudioClipsList[Random.Range(0,myAudioClipsList.Count)];
        audioSource.Play();
    }


    public void collision_sound() {
        audioSource.clip = collisionSoundClip;
        audioSource.Play();
    }

    public void victorySound() {
        audioSource.clip = victorySoundClip;
        audioSource.Play();
    }
}
