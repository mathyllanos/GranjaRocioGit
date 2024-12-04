using UnityEngine;
using UnityEngine.Windows;
using System;
/*
 Funcion: Controla los movimientos basico del jugador.
 Autor: Oscar
 */

public class PlayerController: MonoBehaviour
{

    //Explicacion


    public Rigidbody2D rb;
    public float speed = 5f;
    private Vector2 _input;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        _input = new Vector2(UnityEngine.Input.GetAxisRaw("Horizontal"), UnityEngine.Input.GetAxisRaw("Vertical"));
        if (_input.x != 0  ) 
        
            rb.transform.Translate(Vector2.right * (speed * _input.x) * Time.deltaTime);
        
        if (_input.y != 0) 
         
            rb.transform.Translate(Vector2.up * (speed * _input.y) * Time.deltaTime); 
    }
}
