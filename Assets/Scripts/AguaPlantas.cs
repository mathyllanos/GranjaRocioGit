using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AguaPlantas : MonoBehaviour
{
    public int CantidadAgua;

   [SerializeField] private Image bar;
   [SerializeField] private Text texto;
    
    

    // Update is called once per frame
    void Update()
    {
            texto.text =   CantidadAgua + " %";
        // Verifica si la barra está llena antes de incrementar el fillAmount y la cantidad de agua
           if (Input.GetKey(KeyCode.Space) && bar.fillAmount < 1.0f)
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
           //Decrementa el fillAmount,al mismo tiempo decrementando el valor de la CantidadAgua

     
               if (Input.GetKeyDown(KeyCode.E) && bar.fillAmount != 0f)
               {                     
                   bar.fillAmount -= 0.25f;
                   CantidadAgua = Mathf.RoundToInt(bar.fillAmount * 100);
               }
           
           
    }
   
}
   
  