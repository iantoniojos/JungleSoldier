using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public AudioClip Sound;

    //Variable para velocidad de la bala
    public float Speed;

    private Rigidbody2D Rigidbody2D;
    private Vector3 Direction;

    
    private void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
    }

   
    private void FixedUpdate()
    {
        //Velocidad de la bala 
        Rigidbody2D.velocity = Direction * Speed;
    }

    public void SetDirection(Vector3 direction)
    {
        Direction = direction;
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        JhonMovement john = other.GetComponent<JhonMovement>();
        GruntScript grunt = other.GetComponent<GruntScript>();
    

        if (grunt != null)
        {
            grunt.Hit();
        }
        if (john != null)
        {
            john.Hit();
        }
       
        DestroyBullet();
    }
}

   
       

