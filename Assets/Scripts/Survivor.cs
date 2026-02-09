using UnityEngine;

public class Survivor : MonoBehaviour
{
	Rigidbody2D rb;
	[field: SerializeField] public float currentHealth { get; private set; }
	[SerializeField] float maxHealth;
	[SerializeField] float speed;
	[SerializeField] float fireRate;
	[SerializeField] Weapon weapon;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}
	private void Update()
	{
		weapon.Fire(fireRate);
	}

	public void Move(float dir)
	{
		rb.linearVelocityX = dir * speed;
	}
	public void TakeDamage(float damage)
	{
		currentHealth -= damage;
		Death();
	}
	public void Heal(float amount)
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
