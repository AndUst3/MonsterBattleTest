using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private string _nameThisObject;

    private Transform _transform;
    private Vector3 _firstScale;

    public static bool isAttack;

    void Start()
    {
        _transform = GetComponent<Transform>();
        _firstScale = transform.localScale;
        isAttack = false;
    }

    void LateUpdate()
    {
        if (isAttack && PlayerHit.nameToChange == _nameThisObject)
        {
            _transform.position = this.transform.position;
        }

        else
        {
            _transform.localScale = _firstScale;
        }
    }
}
