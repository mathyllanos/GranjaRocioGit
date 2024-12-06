using UnityEngine;
using UnityEngine.Windows;
using System;
/*
 Funcion: Controla los movimientos basico del jugador.
 Autor: Oscar
 */

public class PlayerController: MonoBehaviour
{

    

    //Variables
    private Rigidbody2D rb;
    public float speed = 5f;
    private Vector2 _input;
    
    private void Awake(){rb = GetComponent<Rigidbody2D>();}



    void Update()
    {
        //Explicacion: Esta para es para detectar las teclas que detectan el mobimiento Horizontal y el movimiento Vertical.
        
        _input = new Vector2(UnityEngine.Input.GetAxisRaw("Horizontal"), UnityEngine.Input.GetAxisRaw("Vertical"));
       
        // Explicacion: Cons estos IF determinan cuando no esta quieto y cuando se estan desplazando.
        if (_input.x != 0  ) 
        
            rb.transform.Translate(Vector2.right * (speed * _input.x) * Time.deltaTime);
        
        if (_input.y != 0) 
         
            rb.transform.Translate(Vector2.up * (speed * _input.y) * Time.deltaTime); 
    }
}
