using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallParts : MonoBehaviour
{
    private const string wallName = "Wall";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.transform.parent != this.gameObject.transform.parent)
        {
            var wallArray = GameObject.FindGameObjectsWithTag(wallName);
            GameObject wall;
            
            for (int i = 0; i < wallArray.Length; i++)
            {
                if (transform.parent.name == wallArray[i].name)
                {
                    wall = wallArray[i];
                    wall.GetComponent<WallBreaking>().HitAllWallParts();
                }
            }
        }
    }
}
