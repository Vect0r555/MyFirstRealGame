using UnityEngine;

public class EnemyHealthScript : MonoBehaviour
{
    //private EnemyController enemyController;
    [SerializeField]private EnemyAnimController enemyAnimController;
    [SerializeField] private int health =100;
    private int currentHealth;
    void Start()
    {
        currentHealth = health;
        enemyAnimController = GetComponentInChildren<EnemyAnimController>();
        if (enemyAnimController == null) Debug.LogError("EnemyAnimController not found on " + gameObject.name);
        //enemyController = GetComponent<EnemyController>();
    }
    public void TakeDamage(int damage)
    {
        //enemyController.KnockBack(attackerPos);
        currentHealth -= damage;
        Debug.Log(currentHealth);
        if(currentHealth <= 0)
        {
            Die();
        }
        enemyAnimController.TakeDamageAnim();
    }
    private void Die()
    {
        Destroy(gameObject);
        Debug.Log("Destroyed");
    }
}
