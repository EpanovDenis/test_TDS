using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;    

    public ParticleSystem fireShootPS;
    public float roundPerSecond;
    private float rechargeTime;

    public static Vector2 target;
    
    void Update()
    {
        SpawnBonus.activeWeapon = this.gameObject;

        if (Input.GetMouseButtonDown(0))
        {
            CurrentMousePosition();
        }

        if (rechargeTime <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                if (gameObject.name == "ShotGun")
                {
                    Instantiate(fireShootPS, firePoint.position, Quaternion.identity);
                    float step = -5f; 
                    for (int i = 0; i < 5; i++)
                    {                                            
                        Instantiate(bullet, firePoint.position, (transform.rotation * Quaternion.Euler(0,0,step)));                   
                        step += 2;
                    }                    
                }
                else
                {
                    Instantiate(fireShootPS, firePoint.position, Quaternion.identity);
                    Instantiate(bullet, firePoint.position, transform.rotation);
                }
                
                rechargeTime = 1 / roundPerSecond;
            }
        }
        else
        {
            rechargeTime -= Time.deltaTime;
        }
    }

    private Vector2 CurrentMousePosition()
    {        
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);             
        return target;
    }
}
