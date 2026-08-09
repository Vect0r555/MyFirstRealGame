using UnityEngine;
using UnityEngine.InputSystem;

public class AsuraLaser : MonoBehaviour
{
    [SerializeField] private Collider collider;
    [SerializeField] private ParticleSystem chargingPart;
    [SerializeField] private GameObject laserPart;
    private float timer = 0;
    void Start()
    {
        chargingPart.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.fKey.wasPressedThisFrame)
        {
            //laserPart.;
        }
        if (Keyboard.current.fKey.isPressed)
        {
            timer += Time.deltaTime;
            if (chargingPart != null &&!chargingPart.isPlaying)
            {
                Debug.Log("ChargingPart is playing");
                chargingPart.Play();
            }
            else Debug.Log("Charging particle is null");
        }

    }
}
