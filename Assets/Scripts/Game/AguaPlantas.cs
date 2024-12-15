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
   [SerializeField] private string tocaPatata = "Patata";
   [SerializeField] private string tocaZanahoria = "Zanahoria";
   [SerializeField] private string tocaLechuga = "Lechuga";
   [SerializeField] private string tocaTomate = "Tomate";

   [SerializeField] private bool _puedeLlenar = false;
   [SerializeField] private bool _regarPatata = false;
   [SerializeField] private bool _regarZanahoria = false;
   [SerializeField] private bool _regarLechuga = false;
   [SerializeField] private bool _regarTomate = false;



    
    

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
                                 bar.fillAmount += 0.002f;
   
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

     
               if (Input.GetKeyDown(KeyCode.E) && bar.fillAmount != 0f && _regarPatata)
               {                     
                   bar.fillAmount -= 0.1f;
                   CantidadAgua = Mathf.RoundToInt(bar.fillAmount * 100);
               }
               if (Input.GetKeyDown(KeyCode.E) && bar.fillAmount != 0f && _regarZanahoria)
               {                     
                   bar.fillAmount -= 0.3f;
                   CantidadAgua = Mathf.RoundToInt(bar.fillAmount * 100);
               }
               if (Input.GetKeyDown(KeyCode.E) && bar.fillAmount != 0f && _regarLechuga)
               {                     
                   bar.fillAmount -= 0.5f;
                   CantidadAgua = Mathf.RoundToInt(bar.fillAmount * 100);
               }
               if (Input.GetKeyDown(KeyCode.E) && bar.fillAmount != 0f && _regarTomate)
               {                     
                   bar.fillAmount -= 0.75f;
                   CantidadAgua = Mathf.RoundToInt(bar.fillAmount * 100);
               }
               
           
           
    }
    
    // Modificados los OnCollision por OnTrigger (modificado por Adrián) 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Well"))
        {
            _puedeLlenar = true; // Permite que la barra pueda llenarse si contacta con un collider de un objeto de tag
            //"well" (pozo)
        }
        // Permite que la barra pueda bajarse si contacta con un collider de un objeto de tag
        //"(verduras)"
        if (other.gameObject.CompareTag("Patata"))
        {
            _regarPatata = true; 
        }
        if (other.gameObject.CompareTag("Zanahoria"))
        {
            _regarZanahoria = true; 
        }
        if (other.gameObject.CompareTag("Lechuga"))
        {
            _regarLechuga = true; 
        }
        if (other.gameObject.CompareTag("Tomate"))
        {
            _regarTomate = true; 
        }
        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other != null)
        {
            _puedeLlenar = false; // Desactiva la posibilidad de llenar la barra
            // Desactiva la posibilidad de bajar la barra
            _regarPatata = false;
            _regarZanahoria = false;
            _regarLechuga = false;
            _regarTomate = false;
        }
    }
   
}
   
  