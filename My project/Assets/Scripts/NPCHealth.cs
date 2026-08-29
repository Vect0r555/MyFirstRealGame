using UnityEngine;
using UnityEngine.UIElements;

public class NPCHealth : EnemyHealthScript
{
    public override void Die()
    {
        Destroy(gameObject);
    }
}
