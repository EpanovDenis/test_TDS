using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;

    [SerializeField] private ParticleSystem fireShootPS;
    [SerializeField] private float startRechargeTime;
    private float rechargeTime;           
    
    void Update()
    {
        if (rechargeTime <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(fireShootPS, firePoint.position, Quaternion.identity);
                Instantiate(bullet, firePoint.position, transform.rotation);
                rechargeTime = startRechargeTime;
            }
        }
        else
        {
            rechargeTime -= Time.deltaTime;
        }
    }
}
