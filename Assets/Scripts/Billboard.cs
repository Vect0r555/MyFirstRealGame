using UnityEngine;
using TMPro;
public class Billboard : MonoBehaviour
{
    [SerializeField]private Transform mainCameraTransform;
    [SerializeField]
    private TextMeshProUGUI nocQuestText;
    void Start()
    {
        // Находим главную камеру при старте
        if (Camera.main != null)
        {
            mainCameraTransform = Camera.main.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (mainCameraTransform != null) {
            transform.LookAt(transform.position + mainCameraTransform.rotation * Vector3.forward, mainCameraTransform.rotation * Vector3.up);
        }
    }
}
