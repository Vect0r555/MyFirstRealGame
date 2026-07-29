using UnityEngine;

public class EnemyAnimController : MonoBehaviour
{
    [SerializeField]private Animator animator;
    [SerializeField]private EnemyController enemyController;

    

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyController.agentMagnitude >= 0.1)
        {
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
            if (enemyController.isAttacking)
            {
                animator.SetTrigger("Attack");
            }
            
        }
    }
    public void TakeDamageAnim()
    {
        animator.SetTrigger("TakeDamage");
    }
    /*public void DeathAnim()
    {
        animator.SetTrigger("Death");
    }*/
}
