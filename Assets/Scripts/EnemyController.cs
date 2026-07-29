using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using System.Collections;
public class EnemyController : MonoBehaviour
{
    private EnemyAnimController enemyAnimController;
    Transform target;
    NavMeshAgent agent;
    Rigidbody rb;
    public float agentMagnitude;
    [SerializeField] private float attackDistance;
    [SerializeField] private float lookRadius = 10f;
    public bool isAttacking { get; private set; }

    [SerializeField] private float knockBackForce = 3f;
    [SerializeField] private float knockBackTime = 0.2f;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        rb= GetComponent<Rigidbody>();
        target = LinkController.Instance.transform;
    }
    /*public void KnockBack(Vector3 sourcePosition)
    {
        StartCoroutine(KnockBackRoutine(sourcePosition));
    }
    private IEnumerator KnockBackRoutine(Vector3 sourcePosition)
    {
        agent.enabled = false;

        Vector3 direction = (transform.position - sourcePosition).normalized;
        rb.AddForce(direction * knockBackForce, ForceMode.Impulse);
        yield return new WaitForSeconds(knockBackTime);
        agent.enabled = true;
    }*/

    // Update is called once per frame
    void Update()
    {
        agentMagnitude = agent.velocity.magnitude; 
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= attackDistance)
        {
            agent.SetDestination(transform.position);
            isAttacking = true;
        }
        else if (distance <= lookRadius) 
        {
            isAttacking = false;
            agent.SetDestination(target.position);
        }

        
    }
    private void BeenHit()
    {

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackDistance);
    }
}
