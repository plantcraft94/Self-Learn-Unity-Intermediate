using UnityEngine;

public class Survivor : MonoBehaviour
{
	Rigidbody2D rb;
	[field: SerializeField] public float currentHealth { get; private set; }
	[SerializeField] float maxHealth;
	[SerializeField] float speed;
	[SerializeField] float fireRate;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}
	private void Update()
	{

	}

	void Move(float speed)
	{
		rb.linearVelocityX = speed;
	}
	void TakeDamage(float damage)
	{
		currentHealth -= damage;
		Death();
	}
	void Heal(float amount)
	{
		currentHealth += amount;
		if (currentHealth > maxHealth)
		{
			currentHealth = maxHealth;
		}
	}
	void Death()
	{
		if (currentHealth <= 0)
		{
			Destroy(gameObject);
		}
	}
}
