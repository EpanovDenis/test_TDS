using UnityEngine;

public class SpeedUpBonus : MonoBehaviour
{
    public static bool speedUp;
    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.gameObject.tag == "Player")
        {            
            PlayerMovement.deceleration = PlayerMovement.speedUp * 1.5f;
            Destroy(gameObject);
            PlayerMovement.speedUpTimer = 10f;
        }
    }

    void Update()
    {
        Destroy(gameObject, 5f);
    }
}
