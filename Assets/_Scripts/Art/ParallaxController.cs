using Unity.Mathematics;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    [SerializeField] GameObject foreground;
    [SerializeField] GameObject background;
    [SerializeField] GameObject ground;
    [SerializeField] float foregroundSpeed;
    [SerializeField] float backgroundSpeed;
    [SerializeField] float groundSpeed;

    private void LateUpdate()
    {
        background.transform.position = math.lerp(background.transform.position, background.transform.position - Vector3.right, backgroundSpeed);
        foreground.transform.position = math.lerp(foreground.transform.position, foreground.transform.position - Vector3.right, foregroundSpeed);
        ground.transform.position = math.lerp(ground.transform.position, ground.transform.position - Vector3.right, groundSpeed);
    }
}