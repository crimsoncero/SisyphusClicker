using UnityEngine;

public class SpawnAndDespawn : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out LayerSpawner spawner))
        {
            spawner.Spawn();
        }
    }
}
