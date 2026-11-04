
using UnityEngine;

public class PassportPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerPassport player = other.GetComponent<PlayerPassport>();

        if (player != null)
        {
            player.CollectPassport();
            Destroy(gameObject);
        }
    }
}
