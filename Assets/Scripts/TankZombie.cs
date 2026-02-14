using UnityEngine;

public class TankZombie : ZombieBase
{
    [SerializeField] float healthMultiplier;

    public override void Attack()
    {
        Debug.Log("get tickle");
    }

    protected override void Awake()
    {
        base.Awake();
        maxHealth *= healthMultiplier; 
    }
}
