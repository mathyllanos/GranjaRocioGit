using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AguaPlantas : MonoBehaviour
{
    public int CantidadAgua = 0;

    public Image bar;
    
    

    // Update is called once per frame
    void Update()
    {
           // Verifica si la barra está llena antes de incrementar el fillAmount y la cantidad de agua
           if (Input.GetKey(KeyCode.Space) && bar.fillAmount < 1.0f)
           {                      //0.0002f;
                                 //0.0006f;
               bar.fillAmount += 0.00035f;
   
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
           if (Input.GetKeyDown(KeyCode.A) && bar.fillAmount != 0f)
                      {                     
                          bar.fillAmount -= 0.35f;
              
                         
                          if (bar.fillAmount = 0f)
                          {
                              CantidadAgua = 0;
                          }
                          else
                          {
                              CantidadAgua = CantidadAgua -(Mathf.RoundToInt(bar.fillAmount * 100));
                          }
                      }
       }
   
   }
   
  