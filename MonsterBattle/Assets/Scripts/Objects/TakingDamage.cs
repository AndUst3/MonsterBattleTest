using UnityEngine;

public abstract class TakingDamage : MonoBehaviour
{
    protected Rigidbody rb;
    public float damageForce;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody>();
        damageForce = 200f;
    }

    protected abstract void SetPosition();
}
