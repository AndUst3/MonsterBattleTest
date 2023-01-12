using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBreaking : MonoBehaviour
{
    [SerializeField] private Queue<GameObject> _wallParts;
    [SerializeField] private GameObject _firstPartWall;

    private bool _isFirstHit = true;

    private void Start()
    {
        _wallParts = new Queue<GameObject>();
        _firstPartWall = transform.GetChild(0).gameObject;

        for (int i = 1; i < transform.childCount; i++)
        {
            _wallParts.Enqueue(transform.GetChild(i).gameObject);
        }
    }

    public void HitAllWallParts()
    {
        //Для разрушения стены с двух ударов раскомментировать скрипт
        //if (_isFirstHit)
        //{
        //    _firstPartWall.SetActive(false);
        //    StartCoroutine(SetCountHit());
        //}

        //else if (!_isFirstHit)
        if (_isFirstHit)
        {
            while (_wallParts.Count != 0)
            {
                //Удалить следующую строку
                _firstPartWall.SetActive(false);
                GameObject part = _wallParts.Dequeue();

                Rigidbody wallPartRb = part.GetComponent<Rigidbody>();
                MeshCollider wallPartCollider = part.GetComponent<MeshCollider>();
                wallPartRb.isKinematic = false;
                wallPartRb.AddExplosionForce(20000f, Vector3.up, 1000f);
                StartCoroutine(WallPartColliderSetTrigger(wallPartCollider));
            }
        }
    }

    IEnumerator SetCountHit()
    {
        yield return new WaitForSeconds(1);
        _isFirstHit = false;
    }

    IEnumerator WallPartColliderSetTrigger(MeshCollider mesh)
    {
        yield return new WaitForSeconds(1);
        mesh.isTrigger = true;
    }
}
