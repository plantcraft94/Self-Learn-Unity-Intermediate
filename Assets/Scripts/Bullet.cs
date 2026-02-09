using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
	Rigidbody2D rb;
	[SerializeField] float speed;
	public UnityEvent<Bullet> OnBulletDestroy;
	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}
	private void Start()
	{
		rb.linearVelocityY = speed;
		Destroy(gameObject,1.5f);
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.CompareTag("BulletBreaker"))
		{		
			Destroy(gameObject);
		}
	}
    private void OnDestroy()
    {
        OnBulletDestroy.Invoke(this);
    }
}
