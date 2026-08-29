using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NPCTalking : MonoBehaviour
{
    [SerializeField] private Transform linkPos;
    private float interactionDistance = 5f;
    [SerializeField]private GameObject button;
    [SerializeField]private TextMeshProUGUI textMesh;
    [SerializeField]private TextMeshProUGUI text;
    [Header("Список реплик")]
    public string[] lines;
    private int currentIndex = 0;
    void Start()
    {
        button.SetActive(false);
        text.gameObject.SetActive(false);
        if (lines.Length > 0 && textMesh != null)
        {
            textMesh.text = lines[currentIndex];
        }
        UpdateTextDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        if (linkPos == null) return;
        if (lines.Length <= 0 || textMesh == null) return;
        float distance = Vector3.Distance(transform.position, linkPos.position);
        if (distance < interactionDistance)
        {
            button.SetActive(true);
            text.gameObject.SetActive(true);
        }
        else
        {
            button.SetActive(false);
            text.gameObject.SetActive(false);
        }
        UpdateTextDisplay();
        
    }
    public void changeReplic()
    {
        if (lines.Length == 0) return;

        currentIndex++;
        if (currentIndex > lines.Length) {
            currentIndex = 0;
        }
        UpdateTextDisplay();
    }
    private void UpdateTextDisplay()
    {
        if (textMesh != null && lines.Length > 0)
        {
            textMesh.text = lines[currentIndex];
        }
    }
}
