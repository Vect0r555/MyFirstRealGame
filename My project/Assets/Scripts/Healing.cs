using UnityEngine;

public class Healing : MonoBehaviour
{
    [SerializeField] private GameObject gameObject;
    private int healing = 50;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
            Debug.Log("Healing Triggered");
            LinkHealth linkHealth = other.GetComponentInChildren<LinkHealth>();
            if (linkHealth != null)
            {
                Debug.Log("Healing");
                linkHealth.TakeDamage(-healing);
                Destroy(gameObject);
            }
            else Debug.Log("LinkHealth == null");
        
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Healing untriggered");
    }
}
