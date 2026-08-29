using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealthScript : MonoBehaviour
{
    //private EnemyController enemyController;
    [SerializeField] private Image healthBar;
    [SerializeField] private EnemyAnimController enemyAnimController;
    [SerializeField] private EnemyController enemyController;
    [SerializeField] private ParticleSystem particleSystem;
    [SerializeField] private float health = 300;
    [SerializeField] private float deathDuration = 2f;
    private float currentHealth;
    private bool beenHit = false;
    private int hitCount = 0;
    void Start()
    {
        currentHealth = health;
        enemyAnimController = GetComponentInChildren<EnemyAnimController>();
        //
        
    }
    private void UpdateHealthBar(float currentHealth)
    {
        healthBar.fillAmount = currentHealth / health;
        Debug.Log(healthBar);
    }
    public void TakeDamage(float damage)
    {
        //enemyController.KnockBack(attackerPos);
        currentHealth -= damage;
        hitCount++;
        //beenHit = !beenHit;
        Debug.Log(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
        UpdateHealthBar(currentHealth);
        //enemyController.KnockBack();
        /*if (!beenHit)*/
        if (hitCount!=3)enemyAnimController.TakeDamageAnim();
        
        else hitCount = 0;
        PlayEffect();

    }
    public void PlayEffect()
    {
        // Проверяем, что ссылка на Particle System ЗАДАНА в инспекторе
        if (particleSystem != null)
        {
            particleSystem.Play();
        }
    }
    public virtual void Die()
    {
        StartCoroutine(DeathRoutine());
    }
    private IEnumerator DeathRoutine()
    {
        enemyAnimController.DieAnim();
        
        yield return new WaitForSeconds(deathDuration);
        Destroy(gameObject);
    }
}
