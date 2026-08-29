using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class LinkHealth : MonoBehaviour
{
    //[SerializeField] private GameObject link;
    [SerializeField] private Image healthImage;
    [SerializeField] private LinkController linkController;
    //[SerializeField] private CanvasControl canvasController;
    [SerializeField] private LinkAnimationController linkAnimController;
    [SerializeField] private int health = 100;
    private int currentHealth;
    void Start()
    {
        currentHealth = health;
    }
    public void TakeDamage(int damage)
    {

        currentHealth -= damage;
        UpdateHealthBar(currentHealth);
        Debug.Log(currentHealth);
        if (currentHealth <= 0) Die();
    }
    public void Heal(int healing)
    {
        currentHealth += healing;
        UpdateHealthBar(currentHealth);
    }
    private void UpdateHealthBar(float currentHealth)
    {
        healthImage.fillAmount = currentHealth / health;
        Debug.Log(healthImage);
    }
    // Update is called once per frame
    private void Die()
    {
        linkAnimController.Die();
        linkController.Die();
        //canvasController.Die();

    }

}
