using UnityEngine;

public class SwithWeapon : MonoBehaviour
{
    public GameObject[] weapon;
           
    void Update()
    {
        if (BonusWeapon.check == true)
        {            
            BonusWeapon.check = false;
            
            for (int i = 0; i < weapon.Length; i++)
            {                
                if (weapon[i].tag == BonusWeapon.tagBonus)
                {                    
                    weapon[i].SetActive(true);
                }
            }
        }
    }
}
