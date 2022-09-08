using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pierreDePierre : MonoBehaviour
{
    private Rigidbody2D rigidB;
    private Vector2 veloDePierre;
    public float rapide;

    // Start is called before the first frame update
    void Start()
    {
        rigidB = GetComponent<Rigidbody2D>();

       
    }
    private void FixedUpdate()
    {
        rigidB.MovePosition(rigidB.position + veloDePierre * Time.fixedDeltaTime);
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 movePierre = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        veloDePierre = movePierre.normalized * rapide;
    }

}

