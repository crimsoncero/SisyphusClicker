using UnityEngine;

public class LayerSpawner : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;

    public void Spawn()
    {
        transform.position = spawnPoint.position;
    }

}
