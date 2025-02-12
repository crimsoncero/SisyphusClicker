using UnityEngine;

public class LayerSpawner : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;

    public void Spawn()
    {
        transform.position = spawnPoint.position;
        Debug.Log("Spawned");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
    }
}
