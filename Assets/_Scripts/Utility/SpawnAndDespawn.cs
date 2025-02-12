using UnityEngine;

public class SpawnAndDespawn : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("a");
        if(collision.TryGetComponent(out LayerSpawner spawner))
        {
            spawner.Spawn();
            Debug.Log("Touched collider " + collision.name);
        }
    }
}
