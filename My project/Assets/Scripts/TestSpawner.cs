using UnityEngine;
using UnityEngine.InputSystem;

public class TestSpawner : MonoBehaviour
{
    void Update()
    {
        // При нажатии на клавишу Пробел будет вызываться спавн врага
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            // Спавним объект с тегом "Enemy" в центре координат (0,0,0)
            ObjectPooler.Instance.SpawnFromPool("Enemy", Vector3.zero, Quaternion.identity);
        }
    }
}