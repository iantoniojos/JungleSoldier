using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JhonMovement : MonoBehaviour
{
    //Recolocar en caso de caida (Reaparecer)
    float xInicial, yInicial;

    //Variables para fuerza de salto y velocidad de John
    public float JumpForce;
    public float Speed;

    public GameObject BulletPrefab;
    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;

    //Variable que nos indicara si estamos en el suelo o no (true o false)
    private bool Grounded;

    private float LastShoot;
    public static int Health = 100;

    public Slider vidaSlider;
    public float DañoBala = 0;

    private void Start()
    {
        xInicial = transform.position.x;
        yInicial = transform.position.y;

        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        //Movimiento en X, a = -1, d = 1 o lo que seria derecha e izquierda
        Horizontal = Input.GetAxisRaw("Horizontal");

        //Lo usamos para que John se gire, osea, vaya a la izquierda o derecha 
        // -1 seria derecha y 1 izquierda
        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        //Si Horizontal != 0 sera true, y si es igual a 0 sera False (no nos estamos moviendo) 
        Animator.SetBool("running", Horizontal != 0.0f);

        //Raycast es una funcion que lanza un rayo desde nustra posicion hacia abajo
        //Si choca con algo es true, si no false
        Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.blue);
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.2f))
        {
            Grounded = true;
        }
        else Grounded = false;

        //salto
        if (Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            Jump();
        }

        //disparar
        if (Input.GetKey(KeyCode.Space) && Time.time > LastShoot + 0.25f)
        {
            Shoot();
            LastShoot = Time.time;
        }
    }

    //Utilizamos FixedUpdate ya que las fisicas necesitan refrescarsen 
    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal * Speed, Rigidbody2D.velocity.y);
    }

    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    private void Shoot()
    {
        Vector3 direction;
        if (transform.localScale.x == 1.0f) direction = Vector3.right;
        else direction = Vector3.left;

        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.2f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);
    }
   

    public void Hit()
    {
        Health -=  1;
        if (Health == 0) Destroy(gameObject);
    }

    public void Recolocar()
    {
        transform.position = new Vector3(xInicial, yInicial, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DamageBala")
        {
            vidaSlider.value -= DañoBala;
            Destroy(collision.gameObject);
        }
    }
}
