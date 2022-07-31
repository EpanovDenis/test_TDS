using UnityEngine;

public class ShieldBonus : MonoBehaviour
{
    public static bool isSheild = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isSheild = true;
            Destroy(gameObject);
        }
    }

    void Update()
    {
        Destroy(gameObject, 5f);
    }
}
