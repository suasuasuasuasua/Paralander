using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager instance;

    public AudioSource soundFXObject;

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // Make this object persistent
        }
        else
        {
            Destroy(gameObject);  // Ensure there is only one instance
        }
        
    }

    public void PlaySoundFXClip(AudioClip audioClip, Transform spawnTransform, float volume) 
    {
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);
        
        audioSource.clip = audioClip;

        audioSource.volume = volume;

        audioSource.Play();

        float clipLength = audioSource.clip.length;


        Destroy(audioSource.gameObject, clipLength);


    }

    public float PlaySoundFXClipReturn(AudioClip audioClip, Transform spawnTransform, float volume)
{
    AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);
    audioSource.clip = audioClip;
    audioSource.volume = volume;
    audioSource.Play();

    Destroy(audioSource.gameObject, audioClip.length);
    return audioClip.length; // Return the duration of the clip
}


}
