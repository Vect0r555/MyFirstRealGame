using UnityEngine;

public class EnemySound : MonoBehaviour
{
    [SerializeField] private AudioSource swordAudioSource;
    [SerializeField] private AudioSource walkAudioSource;
    [SerializeField] private AudioSource jumpAudioSource;
    [SerializeField] private Animator animator;
    void Start()
    {
        
    }
    public void SwordHitSound()
    {
        swordAudioSource.Play();

    }
    private void FootSteps()
    {
        if (!walkAudioSource.isPlaying && !swordAudioSource.isPlaying)
        {
            walkAudioSource.Play();
        }
    }
    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);
        if (state.IsTag("Moving") && !state.IsTag("Attacking"))
        {
            FootSteps();
        }
    }
}
