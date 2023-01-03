using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    //Color Support
    [SerializeField]
    Color32 hasPackageColor = new Color32(76, 206, 75, 255);
    [SerializeField]
    Color32 noPackageColor = new Color32(255, 255, 255, 255);

    //Delivery Suport
    bool hasPackage = false;
    [SerializeField]
    float destroyDelay = 0f;
    SpriteRenderer spriteRenderer;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Ouch");
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Package" && !hasPackage)
        {
            hasPackage = true;
            Debug.Log("Package picked up");
            Destroy(other.gameObject, destroyDelay);
            spriteRenderer.color = hasPackageColor;
        }

        if(other.tag == "Delivery Point" && hasPackage)
        {
            Debug.Log("Package Delivered");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}
