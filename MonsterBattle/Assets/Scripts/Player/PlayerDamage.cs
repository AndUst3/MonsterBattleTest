using UnityEngine;

public class PlayerDamage : TakingDamage
{
    [SerializeField] private GameObject _bodyParts;

    protected override void Awake()
    {
        base.Awake();
        damageForce = 600f;
    }

    private void Update()
    {
        SetPosition();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyHit"))
        {
            if(EnemyMove.enemyWakeUp == false && EnemyAttack.enemyAttack == true)
            {
                rb.AddForce(new Vector3(-damageForce, damageForce, 0));
                GlobalEvents.PlayerEffect?.Invoke();
            }
        }

        if (other.CompareTag("Wall"))
        {
            GlobalEvents.PlayerEffect?.Invoke();
        }
    }

    protected override void SetPosition()
    {
        _bodyParts.transform.position = transform.position;
    }
}
