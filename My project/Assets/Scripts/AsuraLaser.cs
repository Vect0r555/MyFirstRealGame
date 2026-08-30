
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using TMPro;

public class AsuraLaser : MonoBehaviour
{
    [SerializeField] private LinkSound linkSound;
    [SerializeField] private Collider laserCollider;
    [SerializeField] private ParticleSystem laserPart;
    [SerializeField] private ParticleSystem chargingPart;
    [SerializeField] private TextMeshProUGUI messageToPlayer;
    [SerializeField]private int damage = 20;
    private float timer = 0f;
    private float damageTimer = 0f;
    private float coolDown = 0f;
    [SerializeField] private float damageInterval = 0.5f;
    [SerializeField]private float LaserDuration = 3f;
    [SerializeField]private float currentLaserDuration = 0f;
    private bool laserActive = true;
    private bool blocked = false;
    private bool isCharged= false;
    private readonly List<EnemyHealthScript> enemiesInLaser = new List<EnemyHealthScript>();
    void Start()
    {
        laserPart.Stop();
        chargingPart.Stop();
        laserCollider.enabled = false;
        currentLaserDuration = LaserDuration;
    }

    // Update is called once per frame
    void Update()
    {
        if (coolDown > 0)
        {
            coolDown -= Time.deltaTime;
            blocked = true;
            ResetLaserVisuals(); // Удерживаем лазер выключенным, пока идет кулдаун
            return;
        }
        else
        {
            if (blocked)
            {
                blocked = false;
                laserActive = true;
                currentLaserDuration = LaserDuration;
            }
        }
        if(damageTimer>0) damageTimer -= Time.deltaTime;
        if (Keyboard.current.cKey.isPressed&&laserActive)
        {
            timer += Time.deltaTime;

            if (linkSound != null) linkSound.LaserSound(timer);
            else Debug.Log("LinkSound == null");
            //Debug.Log(timer);
            if (timer <= 2f)
            {
                currentLaserDuration = LaserDuration;
                if (!chargingPart.isPlaying) chargingPart.Play();
            }
            // Если прошло 2 секунды и лазер еще не горит — включаем лазер
            else
            { 
                if (chargingPart.isPlaying)  chargingPart.Stop();
                if (!laserPart.isPlaying)
                {
                    laserPart.Play();
                }
                laserCollider.enabled = true;
                currentLaserDuration -= Time.deltaTime;

                 if (currentLaserDuration>0&&damageTimer<=0)
                {
                    ApplyDamage();
                }
                if (currentLaserDuration <= 0f)
                {
                    laserActive = false;
                    coolDown = 2f;
                    StopLaser();
                }
            }
        }
        else
        {
            if (timer > 0)
            {
                StopLaser();
            }
        }

    }
    private void ApplyDamage()
    {
        if (enemiesInLaser.Count == 0) return;
        for (int i = enemiesInLaser.Count - 1; i >= 0; i--)
        {
            if (enemiesInLaser[i] != null)
            {
                enemiesInLaser[i].TakeDamage(damage);
            }
            else enemiesInLaser.RemoveAt(i);
        }
        damageTimer = damageInterval;
    }

    private void StopLaser()
    {
        timer = 0f;
        damageTimer = 0f;
        laserPart.Stop();
        chargingPart.Stop();
        if (laserCollider != null) laserCollider.enabled = false; // Выключаем урон

        if (linkSound != null) linkSound.StopLaserSound();
    }
    private void ResetLaserVisuals()
    {
        if (laserPart.isPlaying) laserPart.Stop();
        if (chargingPart.isPlaying) chargingPart.Stop();
        if (laserCollider != null) laserCollider.enabled = false;
        if (linkSound != null) linkSound.StopLaserSound();
    }
    public void ChargeLaser()
    {
        isCharged = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Enemy")) return;
        EnemyHealthScript enemyHealth = other.GetComponent<EnemyHealthScript>();
        if (enemyHealth != null&&!enemiesInLaser.Contains(enemyHealth))
        {
            enemiesInLaser.Add(enemyHealth);
        }
        else
        {
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Enemy")) return;
        EnemyHealthScript enemyHealth = other.GetComponent<EnemyHealthScript>();
        if (enemyHealth != null && enemiesInLaser.Contains(enemyHealth))
        {
            enemiesInLaser.Remove(enemyHealth);
        }
    }
}
