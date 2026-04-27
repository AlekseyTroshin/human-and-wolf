using Unity.VisualScripting;
using UnityEngine;

public class GroundDetection : MonoBehaviour
{

    [SerializeField] private bool _isGround;

    public bool isGround
    {
        get { return _isGround; }
        set { _isGround = value; }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            _isGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            _isGround = false;
        }
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            _isGround = true;
        }
    }

    private void OnTriggerExit2D (Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            _isGround = false;
        }
    }

}
