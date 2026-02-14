using UnityEngine;

public abstract class ZombieBase : MonoBehaviour
{
	[SerializeField] protected float maxHealth = 50;
	[SerializeField] protected float moveSpeed = 2f;
	[SerializeField] protected int contactDamage = 10;
	[SerializeField] protected float damage;
	

	protected float currentHealth;
	protected Transform targetTransform;
	protected Survivor target;
    protected virtual void Awake()
    {
        Initialize(FindAnyObjectByType<Survivor>().transform);
    }

    public virtual void Initialize(Transform TargetTransform)
	{
		targetTransform = TargetTransform;
		target = targetTransform.GetComponent<Survivor>();


		currentHealth = maxHealth;
	}

	protected virtual void Update()
	{
		MoveTowardsTarget();
	}

	protected void MoveTowardsTarget()
	{
		if (target == null) return;
		transform.position = Vector3.MoveTowards(
			transform.position,
			targetTransform.position,
			moveSpeed * Time.deltaTime
		);
	}

	public abstract void Attack();  // Subclasses MUST implement

	public void TakeDamage(int amount)
	{
		currentHealth -= amount;
		if (currentHealth <= 0) Die();
	}

	protected virtual void Die()
	{
		// Drop XP, play death animation
		Destroy(gameObject);
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			Attack();
		}
	}
}