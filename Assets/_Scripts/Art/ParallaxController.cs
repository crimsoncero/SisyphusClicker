using System;
using System.Collections;
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

    private void OnEnable()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.OnHeightChanged += MoveGround;
        else
            StartCoroutine(AssignToGameManager());
    }

    private IEnumerator AssignToGameManager()
    {
        yield return new WaitForEndOfFrame();
            GameManager.Instance.OnHeightChanged += MoveGround;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnHeightChanged -= MoveGround;
    }

    //private void LateUpdate()
    //{
    //    if (background != null)
    //    background.transform.position = math.lerp(background.transform.position, background.transform.position - Vector3.right, backgroundSpeed);
    //    if (foreground != null)
    //    foreground.transform.position = math.lerp(foreground.transform.position, foreground.transform.position - Vector3.right, foregroundSpeed);
    //    if (ground != null)
    //    ground.transform.position = math.lerp(ground.transform.position, ground.transform.position - Vector3.right, groundSpeed);
    //}

    public void MoveGround()
    {
        Debug.Log("asd");
        ground.transform.position = new Vector3(ground.transform.position.x - groundSpeed, ground.transform.position.y, ground.transform.position.z);
    }
}