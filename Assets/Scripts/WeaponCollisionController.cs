using UnityEngine;

public class WeaponHitbox : MonoBehaviour
{
    [SerializeField] private Collider weaponCollider;
    [SerializeField] private int damage = 10;
    private bool isAttacking = false;

    private void Start()
    {
        Debug.Log("Collider is true");
        weaponCollider.enabled = true; 
    }

    public void SetAttacking(bool value)
    {
        isAttacking = value;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!isAttacking) return;
        Debug.Log("Triggered");
        EnemyHealthScript enemyHealth = other.GetComponent<EnemyHealthScript>();
        if (enemyHealth != null)
        {
            Debug.Log("Enemy Took Damage ?");
            enemyHealth.TakeDamage(damage);
        }
    }
}