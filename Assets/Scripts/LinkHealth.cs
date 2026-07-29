using UnityEngine;

public class LinkHealth : MonoBehaviour
{
    [SerializeField] private int health = 100;
    private int currentHealth;
    void Start()
    {
        currentHealth = health;
    }
    public void TakeDamage(int damage)
    {

        currentHealth -= damage;
        Debug.Log(currentHealth);
        if (currentHealth <= 0) Die();
    }
    // Update is called once per frame
    private void Die()
    {
     Debug.Log("You Died");
    }
}
