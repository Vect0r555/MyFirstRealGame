using Unity.VisualScripting;
using UnityEngine;

public class WeaponHitbox : MonoBehaviour
{
    [SerializeField] private Collider weaponCollider; 
    [SerializeField] private Animator animator;
    [SerializeField] private LinkSound linkSound;
    [SerializeField] private int damage = 10;
    private bool isAttacking = false;
    //private bool hasHitThisAttack = false;
    //private bool sameAttack = true;
    //private int lastAttackStateHash = 0;

    private void Start()
    {
        weaponCollider.enabled = true; 
        animator = GetComponentInParent<Animator>();
        linkSound = GetComponentInParent<LinkSound>();
    }




    public void SetAttacking(bool value)
    {
        isAttacking = value;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!isAttacking) return;
        EnemyHealthScript enemyHealth = other.GetComponent<EnemyHealthScript>();
        if (enemyHealth != null)
        {
            linkSound.SwordHitSound();
            enemyHealth.TakeDamage(damage);
        }
    }
}