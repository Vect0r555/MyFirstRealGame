using UnityEngine;

public class LinkSound : MonoBehaviour
{
    [SerializeField]AudioSource swordAudioSource;
    [SerializeField]AudioSource linkAudioSource;
    [SerializeField] private AudioSource jumpAudioSource;
    [SerializeField]private Animator animator;
    public bool jumping=false;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void SwordHitSound()
    { swordAudioSource.Play();
        
    }
    private void FootSteps()
    {
        if (!linkAudioSource.isPlaying&&!swordAudioSource.isPlaying)
        {
            linkAudioSource.Play();
        }
    }
    public void JumpSound()
    {
        jumpAudioSource.Play();
        jumping = false;
    }
    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);
        if (state.IsTag("Moving")&&!state.IsTag("isAttacking"))
        {
            FootSteps();
        }
        else if (jumping)
        {
            JumpSound();
        }
        
    }
}
