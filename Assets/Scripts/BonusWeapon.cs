using UnityEngine;

public class BonusWeapon : MonoBehaviour
{
    public static bool check = false;
    public static string tagBonus;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SpawnBonus.activeWeapon.SetActive(false);
            Destroy(gameObject);
            tagBonus = gameObject.tag;
            check = true;            
        }
    }

    void Update()
    {
        Destroy(gameObject, 5f);
    }
}
