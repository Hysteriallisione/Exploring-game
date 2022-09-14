using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class pierreDePierre : MonoBehaviour
{
    private Rigidbody2D rigidB;
    private Vector2 veloDePierre;
    public float rapide;
    public Animator animaPierre;
    public float Horizontal;
    public float Vertical;
    public TagAttribute Tronc;
    public TagAttribute bush;
    public GameObject daBomb;
    private bool colliderDP;
    private Collider2D target;

    public bool RollingP
    {
        get => _rollingP;
        set
        {
            _rollingP = value;
            animaPierre.SetBool("RollingP", value);
        }
    }
    private bool _rollingP; //le classeur getter setter de RollingP
    public float Pforce;


    // Start is called before the first frame update
    void Start()
    {
        rigidB = GetComponent<Rigidbody2D>();
        animaPierre = gameObject.GetComponent<Animator>();
        target = null;
        colliderDP = false;

    }

    private void FixedUpdate()
    {

        if (RollingP)
        {
            rigidB.MovePosition(rigidB.position + veloDePierre * Time.fixedDeltaTime * 2);
        }
        else
        {
            rigidB.MovePosition(rigidB.position + veloDePierre * Time.fixedDeltaTime);
        }
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tronc") || collision.gameObject.CompareTag("bush"))
        {
            colliderDP = true;
            target = collision;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tronc") || collision.gameObject.CompareTag("bush"))
        {
            colliderDP = false;
            target = null;
        }
    }
    // Update is called once per frame
    void Update()
        {
            animaPierre.SetBool("pierreIsMoving", false);
            bool pierreIsMoving = false;

            Vector2 movePierre = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            veloDePierre = movePierre.normalized * rapide;
            //attempt:
            //if (animaPierre.SetFloat("Horizontal" > 0) && animaPierre.SetFloat("Horizontal") < 0 && animaPierre.SetFloat("Vertical") > 0 && animaPierre.SetFloat("Vertical") < 0)
            if (movePierre.magnitude > 0)
            {
                animaPierre.SetFloat("Horizontal", movePierre.x);
                animaPierre.SetFloat("Vertical", movePierre.y);
                animaPierre.SetBool("pierreIsMoving", true);
                pierreIsMoving = true;
            }
            else
            {
                animaPierre.SetBool("pierreIsMoving", false);
            }

            animaPierre.SetFloat("Horizontal", Input.GetAxisRaw("Horizontal"));
            animaPierre.SetFloat("Vertical", Input.GetAxisRaw("Vertical"));
            Horizontal = Input.GetAxisRaw("Horizontal");
            Vertical = Input.GetAxisRaw("Vertical");

            RollingP = false;

            if (Input.GetKey(KeyCode.JoystickButton1))
            {
                // rigidB.MovePosition(rigidB.position + veloDePierre * Time.fixedDeltaTime * 2);
                //rigidB.AddForce(veloDePierre * Pforce);
                RollingP = true;
                //Debug.Log("je suis presséééééé");
            }
            if (Input.GetKeyUp(KeyCode.JoystickButton1) && pierreIsMoving)
            {
                RollingP = false;
                pierreIsMoving = true;
                Debug.Log("je relaaache Ze benjamin button et je bouge, je m'accroche à la vie");
            }
            if (Input.GetKeyUp(KeyCode.JoystickButton1) && pierreIsMoving == false)
            {
                RollingP = false;
                pierreIsMoving = false;
                Debug.Log("je relaaache Ze benjamin button");
            }
             if (Input.GetKeyDown(KeyCode.JoystickButton0) && colliderDP)
             {
          
                 GameObject c = Instantiate(daBomb, target.transform);
            // instantiate daBomb comme enfant de tag Tronc ou tag Bush 
                 c.transform.localPosition = Vector2.zero;
                 //animaPierre.SetBool("boum",true);
        }



    }


    }


