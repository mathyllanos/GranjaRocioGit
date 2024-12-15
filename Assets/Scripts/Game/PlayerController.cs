using UnityEngine;
using UnityEngine.Windows;
using System;
using Input = UnityEngine.Input;

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
    private bool x , y;

    private bool _interactuando;


    private void Awake(){rb = GetComponent<Rigidbody2D>();}


    void RestaurarMovimiento()
    {
        _interactuando = false;
    }

    void Update()
    {
        //Explicacion: Esta para es para detectar las teclas que detectan el mobimiento Horizontal y el movimiento Vertical.
        
        _input = new Vector2(UnityEngine.Input.GetAxisRaw("Horizontal"), UnityEngine.Input.GetAxisRaw("Vertical"));
       

        


        // Explicacion: Cons estos IF determinan cuando no esta quieto y cuando se estan desplazando.

        if (Input.GetKeyDown(KeyCode.E))
        {
            _interactuando = true;
            Invoke("RestaurarMovimiento", 2);
        }
        
        if (!_interactuando)
        {


            if (x == false)
            {
                if (_input.x != 0)
                {

                    rb.transform.Translate(Vector2.right * (speed * _input.x) * Time.deltaTime);

                    y = true;
                }
                else
                {


                    y = false;
                }


            }




            if (y == false)
            {

                if (_input.y != 0)
                {

                    rb.transform.Translate(Vector2.up * (speed * _input.y) * Time.deltaTime);
                    x = true;
                }
                else
                {
                    x = false;
                }



            }
        }

    }
}
