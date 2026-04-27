using UnityEngine;

public class Coin : MonoBehaviour
{
    
    [SerializeField] private Animator _animator;

    private void Start()
    {
        GameManager.Instance.coinContainer.Add(gameObject, this);
    }

    public void StartDestroy()
    {
        _animator.SetTrigger("StartDestroy");
    }

    public void EndDestroy()
    {
        Destroy(gameObject);
    }

}
