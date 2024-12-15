using UnityEngine;
using UnityEngine.Windows;
using Input = UnityEngine.Windows.Input;

public class PlayerAnimator : MonoBehaviour
{
    /*
     
    Funcion: Controla del estado de animaciones de andar y estar quieto.
    Autor: OCG
     
     
     
     
     */

    private Vector2 _input;
    private Vector2 _ultimaPosicion;
    private Animator _animator;
    private void Awake(){ _animator = GetComponent<Animator>();}
    public bool x, y;
    
    public CircleCollider2D puntoArriba, puntoAbajo, puntoDerecha, puntoIzquierda;      // Almacena los distintos colliders del punto de detección del personaje (modificado por Oscar y Adrián)
    
    void Update()
    {
        // Según la posición hacia la que quede mirando el personaje, se activará y desactivará el collider correspondiente (modificado por Oscar y Adrián)
        if (_ultimaPosicion.x == 1)
        {
            puntoAbajo.enabled = false;
            puntoArriba.enabled = false;
            puntoIzquierda.enabled = false;
            puntoDerecha.enabled = true;
        } 
        
        if ((_ultimaPosicion.x == -1))
        {
            puntoAbajo.enabled = false;
            puntoArriba.enabled = false;
            puntoIzquierda.enabled = true;
            puntoDerecha.enabled = false;
        }

        if (_ultimaPosicion.y == 1)
        {
            puntoAbajo.enabled = false;
            puntoArriba.enabled = true;
            puntoIzquierda.enabled = false;
            puntoDerecha.enabled = false;
        } 
        
        if ((_ultimaPosicion.y == -1))
        {
            puntoAbajo.enabled = true;
            puntoArriba.enabled = false;
            puntoIzquierda.enabled = false;
            puntoDerecha.enabled = false;
        }
        
        _input = new Vector2(UnityEngine.Input.GetAxisRaw("Horizontal"), UnityEngine.Input.GetAxisRaw("Vertical"));
        
        if (x == false)
        {
            if (_input.x != 0)
            {
                _animator.SetBool("Quieto", false);
                _ultimaPosicion.y = 0;
                _ultimaPosicion.x = _input.x;
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
                _animator.SetBool("Quieto", false);
                _ultimaPosicion.x = 0;
                _ultimaPosicion.y = _input.y;
                x = true;
            }
            else 
            { 
                x = false ;
            }
        }
        
        if (_input.x == 0 && _input.y == 0)
        {
            _animator.SetBool("Quieto", true);
        }
        
        _animator.SetFloat("AndarX", _input.x);
        _animator.SetFloat("AndarY", _input.y);
        _animator.SetFloat("QuietoAndarX", _ultimaPosicion.x);
        _animator.SetFloat("QuietoAndarY", _ultimaPosicion.y);
    }
}
