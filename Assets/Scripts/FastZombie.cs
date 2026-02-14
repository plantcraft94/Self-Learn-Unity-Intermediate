using UnityEngine;

public class FastZombie : ZombieBase
{
    [SerializeField] float moveSpeedFast = 5f;
    float oldms;
    protected override void Awake()
    {
        oldms = moveSpeed;
        base.Awake();
    }

    public override void Attack()
    {
        Debug.Log("get fk but fast");
    }

    protected override void Update()
    {
        base.Update();
        if (Vector3.Distance(target.transform.position,transform.position) <= 5f)
        {
            moveSpeed = oldms * moveSpeedFast;
        }
        else
        {
            moveSpeed = oldms;
        }
    }
}
