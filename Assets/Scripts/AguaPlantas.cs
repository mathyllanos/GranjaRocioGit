using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AguaPlantas : MonoBehaviour
{
    public int CantidadAgua;

   [SerializeField] private Image bar;
   [SerializeField] private Text texto;
   [SerializeField] private string tocaPozo = "Well";
   [SerializeField] private string tocaPlanta = "Verduras";
   [SerializeField] private bool _puedeLlenar = false;
   [SerializeField] private bool _regarPlanta = false;
    
    

    // Update is called once per frame
    void Update()
    {
            texto.text =   CantidadAgua + " %";
        // Verifica si la barra está llena antes de incrementar el fillAmount y la cantidad de agua y permite llenar
        //la barra si el valor "_puedeLlenar" es verdadero
           if (Input.GetKey(KeyCode.Space) && bar.fillAmount < 1.0f && _puedeLlenar)
           {                      //0.0002f;
                                 //0.0006f;
                                 //0.00035f
               bar.fillAmount +=  0.0006f;
   
               // Solo incrementa CantidadAgua cuando el fillAmount aún no ha llegado a 1
               if (bar.fillAmount >= 1.0f)
               {
                   CantidadAgua = 100;
               }
               else
               {
                   CantidadAgua = Mathf.RoundToInt(bar.fillAmount * 100);
               }
           }
           //Decrementa el fillAmount,al mismo tiempo decrementando el valor de la CantidadAgua solo si el valor 
           //"_regarPlanta" es verdadero

     
               if (Input.GetKeyDown(KeyCode.E) && bar.fillAmount != 0f && _regarPlanta)
               {                     
                   bar.fillAmount -= 0.25f;
                   CantidadAgua = Mathf.RoundToInt(bar.fillAmount * 100);
               }
               
           
           
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Well"))
        {
            _puedeLlenar = true; // Permite que la barra pueda llenarse si contacta con un collider de un objeto de tag
            //"well" (pozo)
        }
        if (other.gameObject.CompareTag("Verduras"))
        {
            _regarPlanta = true; // Permite que la barra pueda bajarse si contacta con un collider de un objeto de tag
            //"verduras"
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other != null)
        {
            _puedeLlenar = false; // Desactiva la posibilidad de llenar la barra
            _regarPlanta = false;// Desactiva la posibilidad de bajar la barra
        }
    }
   
}
   
  