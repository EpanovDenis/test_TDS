using UnityEngine;

public class Shield : MonoBehaviour
{
    public GameObject shield;
    private float startTimer = 10f;
    private float shieldTimer;
    public static bool invulnerability = false;


    private void Update()
    {
        shieldTimer -= Time.deltaTime;

        if (ShieldBonus.isSheild == true)
        {
            shield.SetActive(true);
            invulnerability = true;
            shieldTimer = startTimer;

            ShieldBonus.isSheild = false;
        }

        if (shieldTimer <= 0)
        {
            shield.SetActive(false);
            invulnerability = false;
        }

    }
}
