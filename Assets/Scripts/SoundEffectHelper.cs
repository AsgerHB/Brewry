using UnityEngine;
using System.Collections;
public class SoundEffectHelper : MonoBehaviour
{
    
    public static SoundEffectHelper Instance;

    public AudioClip bubblingSound;
    public AudioClip zislingSound;

    void Awake()
    {
        // Register the singleton
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of SoundEffectsHelper!");
        }
        Instance = this;
    }

    public void MakeBubblingExplosionSound()
    {
        MakeSound(bubblingSound);
    }

    public void MakeZislingSound()
    {
        MakeSound(zislingSound);
    }
    
    private void MakeSound(AudioClip originalClip)
    {
        // As it is not 3D audio clip, position doesn't matter.
        AudioSource.PlayClipAtPoint(originalClip, transform.position);
    }
}
