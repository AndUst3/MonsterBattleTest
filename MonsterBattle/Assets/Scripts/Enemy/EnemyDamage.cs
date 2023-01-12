using UnityEngine;

public class EnemyDamage : TakingDamage
{
    [SerializeField] private GameObject _bodyParts;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Update()
    {
        SetPosition();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CharacterHit"))
        {
            if (EnemyMove.enemyWakeUp == false && PlayerAttack.isAttack == true)
            {
                rb.AddForce(new Vector3(damageForce, damageForce * 1.25f, 0));
                GlobalEvents.EnemyEffect?.Invoke();
            }
        }

        if (other.CompareTag("Wall"))
        {
            GlobalEvents.EnemyEffect?.Invoke();
        }
    }

    protected override void SetPosition()
    {
        _bodyParts.transform.position = transform.position;
    }
}
