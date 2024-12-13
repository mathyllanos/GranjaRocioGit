using System.Net.NetworkInformation;
using UnityEngine;

public class ControladorGrifo : MonoBehaviour
{

    public Animator animator;
    private bool Dentro;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {


            
            Dentro = true;





        }
    }


    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {


            Dentro = false; 

           




        }
    }

    void Desactivar() 
    {

        animator.SetBool("Activar", false);

    }






    void Update()
    {

        if (Dentro)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {

                animator.SetBool("Activar", true);
                Invoke("Desactivar",1f);
                
            }
        }
    }
}
