using UnityEngine;

public class LinkSound : MonoBehaviour
{
    AudioSource swordAudioSource;
    void Start()
    {
        swordAudioSource = GetComponentInChildren<AudioSource>();
    }
    public void SwordHitSound()
    {
        swordAudioSource.Play();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
