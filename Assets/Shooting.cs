using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    //VARIABLES
    Vector2 hotSpot = Vector2.zero;

    //REFERENCES
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;

    private void Update()
    {
        Vector3 gunpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(gunpos.x < transform.position.x)
        {
            transform.eulerAngles = new Vector3(transform.rotation.x, 180f, transform.rotation.z);
        }
        else
        {
            transform.eulerAngles = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
        }

        if (Input.GetButtonDown("Fire1")) 
        { 
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    private void Start()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }
}
