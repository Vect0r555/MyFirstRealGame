using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 15f;
    [SerializeField] private int damage = 15;
    [SerializeField] private float lifeTime = 5f;
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        LinkHealth linkHealth = other.GetComponent<LinkHealth>();
        if (linkHealth != null)
        {
            linkHealth.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
