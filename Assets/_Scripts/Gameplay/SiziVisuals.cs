using UnityEngine;

public class SiziVisuals : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void Start()
    {
        _animator.speed = 0;
        GameManager.Instance.OnHeightChanged += PlayAnim;
    }

    public void StopAnim()
    {
        _animator.speed = 0;
    }

    public void PlayAnim()
    {
        _animator.speed = 1;
    }

}
