using UnityEngine;

public class CharacterCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            GlobalEvents.WallEnemyEffect?.Invoke();
        }

        if (other.CompareTag("Player"))
        {
            GlobalEvents.WallPlayerEffect?.Invoke();
        }
    }
}
