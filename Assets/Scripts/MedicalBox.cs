using System.Collections;
using UnityEngine;

public class FirstAid : MonoBehaviour
{
    
    [SerializeField] private int _health;
    [SerializeField] private Animator _animator;

    private GameObject _medicalBox;
    private GameObject _collisionObject;

    private void Start()
    {
        GameManager.Instance.animatorContainer.Add(gameObject, _animator);
        _medicalBox = gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _collisionObject = collision.gameObject;

        if (_collisionObject.CompareTag("Player") || _collisionObject.CompareTag("Enemy"))
        {
            Health health = GameManager.Instance.healthContainer[_collisionObject];
            GameManager.Instance.animatorContainer[_medicalBox].SetTrigger("TakeHealth");
            health.SetHealth(_health);
            StartCoroutine(StartDestroy());
        }
    }

    private IEnumerator StartDestroy()
    {
        yield return new WaitForSeconds(.25f);
        Destroy(_medicalBox);
    }

}
