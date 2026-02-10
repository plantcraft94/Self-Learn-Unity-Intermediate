using UnityEngine;

public class Zombie : MonoBehaviour
{
	[SerializeField] float maxHealth;
	[SerializeField] float speed;
	[SerializeField] int damage;
	Survivor target;
	Transform targetPos;
	float currentHealth;
	Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
	{
		currentHealth = maxHealth;
		target = FindAnyObjectByType<Survivor>();
		targetPos = target.transform;
	}

	void FixedUpdate()
	{
		if (target == null) return;

		Vector2 direction = ((Vector2)targetPos.position - rb.position).normalized;
		Vector2 newPosition = rb.position + direction * speed * Time.fixedDeltaTime;

		rb.MovePosition(newPosition);
	}
	public void TakeDamage(float amount)
	{
		currentHealth -= amount;
		if(currentHealth <= 0)
		{
			Destroy(gameObject);
		}
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.CompareTag("Player"))
		{
			target.TakeDamage(damage);
		}
	}
}