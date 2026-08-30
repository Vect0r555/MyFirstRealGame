using UnityEngine;

public class EnemyWeaponController : MonoBehaviour
{
    [SerializeField] private int damage = 10;
    [SerializeField] private EnemyController enemyController;
    [SerializeField] private Collider weaponCollider;
    [SerializeField] private Animator enemyAnimator;
    [SerializeField] private EnemySound enemySound;

    private bool hasHitThisAttack = false;
    void Start()
    {
        weaponCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo state = enemyAnimator.GetCurrentAnimatorStateInfo(0);
        if (enemyController.isAttacking&&state.IsTag("Attacking")) 
        {
            Enable();
           
        }
        /*else if (enemyController.isThrowing && state.IsTag("Throwing"))
        {
            
        }*/
        else
        {
            Disable();
        }
    }

    public void Enable()
    {
        weaponCollider.enabled = true;
    }
    public void Disable()
    {
        weaponCollider.enabled = false;
        hasHitThisAttack = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(hasHitThisAttack);
        if (!enemyController.isAttacking||hasHitThisAttack) return;
        LinkHealth linkHealth = other.GetComponent<LinkHealth>();
        if (linkHealth != null) 
        {
           linkHealth.TakeDamage(damage);
            enemySound.SwordHitSound();
            hasHitThisAttack = true;
            
        }
    }
}
