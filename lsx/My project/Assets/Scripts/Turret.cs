

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject bulletPrefab;

    public Transform firePoint;

    public Transform bulletPool; 
    
    public List<Bullet> bullets = new ();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    //Convertir este start en una corrutina 
    IEnumerator Start()
    {
        for (int i = 0; i < 15; i++)
        {
            var instance  = Instantiate(bulletPrefab, bulletPool);
            var bullet = instance.GetComponent<Bullet>();
            bullets.Add(bullet);
            instance.SetActive(false);
        }
        
        //Se ejecuta una vez 
        while (true)
        {
            //Se ejecuta indefinidamente
            var available = bullets.FirstOrDefault(x => !x.gameObject.activeInHierarchy);
            if (available)
            {
                available.gameObject.SetActive(true);
                available.direction = firePoint.up;
                available.transform.position = firePoint.position;   
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
