using UnityEngine;
using UnityEngine.Windows;

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
    void Update()
    {
        _input = new Vector2(UnityEngine.Input.GetAxisRaw("Horizontal"), UnityEngine.Input.GetAxisRaw("Vertical"));
        if (_input.x != 0)
        {
            _animator.SetBool("Quieto", false);
            _ultimaPosicion.y = 0;
            _ultimaPosicion.x = _input.x;
        }

        if (_input.y != 0) 
        {
            _animator.SetBool("Quieto", false);
            _ultimaPosicion.x = 0;
            _ultimaPosicion.y = _input.y;
        }

        if(_input.x == 0 && _input.y == 0) 
        {
            _animator.SetBool("Quieto", true);
        }
        _animator.SetFloat("AndarX", _input.x);
        _animator.SetFloat("AndarY", _input.y);
        _animator.SetFloat("QuietoAndarX", _ultimaPosicion.x);
        _animator.SetFloat("QuietoAndarY", _ultimaPosicion.y);
    }
}
