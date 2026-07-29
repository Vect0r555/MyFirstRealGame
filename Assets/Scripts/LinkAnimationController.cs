using UnityEngine;
using UnityEngine.InputSystem;

public class LinkAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private LinkController controller;
    [SerializeField] private WeaponHitbox weaponHitbox; 


    private float lastAttackTime;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
        Moving();
        Jump();
        UpdateWeaponHitBox();
    }
    private void UpdateWeaponHitBox()
    {
        AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);
        weaponHitbox.SetAttacking(state.IsTag("isAttacking"));
    }
    private void Moving()
    {
        if (Keyboard.current.wKey.isPressed || Keyboard.current.aKey.isPressed ||
    Keyboard.current.sKey.isPressed || Keyboard.current.dKey.isPressed)
        {
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
        }
    }
    private void Jump()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && controller.IsGrounded)
        {
            animator.SetTrigger("Jump");
            Debug.Log("JumpSet");
        }
    }
    private void Attack()
    {
        if (!Mouse.current.leftButton.wasPressedThisFrame) return;

        AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);
        bool canCombo = state.normalizedTime <= 0.7f;
        bool isIdleOrMoving = !state.IsTag("Attack");
        if (isIdleOrMoving||canCombo)
        {
            lastAttackTime = Time.time;
            animator.SetTrigger("Attack");
        }
    }
}
