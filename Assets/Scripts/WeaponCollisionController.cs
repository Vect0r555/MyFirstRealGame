using Unity.VisualScripting;
using UnityEngine;

public class WeaponHitbox : MonoBehaviour
{
    [SerializeField] private Collider weaponCollider; 
    [SerializeField] private Animator animator;
    [SerializeField] private LinkSound linkSound;
    [SerializeField] private int damage = 10;
    private bool isAttacking = false;
    private bool hasHitThisAttack = false;
    private bool sameAttack = true;
    private int lastAttackStateHash = 0;

    private void Start()
    {
        Debug.Log("Collider is true");
        weaponCollider.enabled = true; 
        animator = GetComponentInParent<Animator>();
        linkSound = GetComponentInParent<LinkSound>();
    }

    private void Update()
    {
        AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);

        if (!state.IsTag("Attack"))
        {
            hasHitThisAttack = false; // вышли из атаки полностью — можно бить заново
        }
    }
    private void Disable()
    {
        weaponCollider.enabled = false;
        hasHitThisAttack = false;
    }


    public void SetAttacking(bool value)
    {
        isAttacking = value;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log( hasHitThisAttack);
        if (!isAttacking||hasHitThisAttack) return;
        Debug.Log("Triggered");
        EnemyHealthScript enemyHealth = other.GetComponent<EnemyHealthScript>();
        if (enemyHealth != null)
        {
            linkSound.SwordHitSound();
            Debug.Log("Enemy Took Damage ?");
            enemyHealth.TakeDamage(damage);
        }
    }
}