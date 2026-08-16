using UnityEngine;
using UnityEngine.InputSystem;

public class AsuraLaser : MonoBehaviour
{
    [SerializeField] private Collider laserCollider;
    [SerializeField] private ParticleSystem laserPart;
    [SerializeField] private ParticleSystem chargingPart;
    private int damage = 20;
    private float timer = 0;
    void Start()
    {
        laserPart.Stop();
        chargingPart.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.fKey.isPressed)
        {
            timer += Time.deltaTime;
            if(!chargingPart.isPlaying)chargingPart.Play();
            if (timer > 2&&!laserPart.isPlaying) laserPart.Play(); 
            chargingPart.Stop();
        }
        else
        {
            timer = 0;
            laserPart.Stop();
            chargingPart.Stop();
        }

    }
    private void onTriggerStay(Collider other)
    {
        Debug.Log("OnTriggerStay");
        EnemyHealthScript enemyHealth = other.GetComponent<EnemyHealthScript>();
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(damage);
        }
    }  
}
