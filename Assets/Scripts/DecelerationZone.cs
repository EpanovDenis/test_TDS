using UnityEngine;

public class DecelerationZone : MonoBehaviour
{
    [Range(60f, 100f)]
    [Tooltip("The speed of the player in percentage of the normal")]
    public float speedPlayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerMovement.deceleration = PlayerMovement.deceleration / 100 * speedPlayer;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerMovement.deceleration = 1;
    }
}
