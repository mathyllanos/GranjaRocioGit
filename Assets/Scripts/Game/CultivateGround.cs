using System;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;


public class CultivateGround : MonoBehaviour
{
    /*  Descripción: Sistema para cultivar el suelo
        Autor: Adrián */
    public GameObject currentCell = null;                       // Almacena la celda detectada
    public GameObject plowedGroundPrefab;                       // Prefab del terreno arado
    public GameObject[] sownGroundPrefabs = new GameObject[4];  // Array con los prefabs de los terrenos cultivados


    [Range(-1, 3)]
    public int pickedSeed = -1;                                 // ID de la semilla recogida
    public InventoryManager inventory;                          // Para usar los huecos del inventario
    public AguaPlantas1 plantWater;                              // Para usar la cantidad de agua
    public PlayerController PlayerController;
    public Animator playerAnimator;                             // Para ejecutar las condiciones de las animaciones
    public PlayerAnimator PlayerAnimator;
    public TextMeshProUGUI textpuntos;
    public int puntos;

    private void Update()
    {
        if (currentCell != null && Input.GetKeyDown(KeyCode.E))
        {
            // Si el terreno es arable y se tiene la azada seleccionada, creamos el terreno arado
            if (currentCell.CompareTag("Arable") && inventory.selectedSlot == 1)
            {

                PlayerAnimator.Detente(1.1f);

                PlayerController.Detener(1f);


                // Condiciones para que se ejecute la animación
                playerAnimator.SetInteger("Herramienta", 1);
                playerAnimator.SetBool("Interactuar", true);
                // Esperamos unos segundos para que se ejecute la animación y luego volvemos a la de idle
                Invoke("ResetAnimation", 1);
                Instantiate(plowedGroundPrefab, currentCell.transform.position, quaternion.identity);
                Destroy(currentCell.gameObject);
            }
            // Si ya está arado y se tienen los guantes seleccionados, se crea un terreno sembrado según la semilla que se haya recogido 
            else if (currentCell.CompareTag("Plowed") && inventory.selectedSlot == 0 && pickedSeed >= 0)
            {
                PlayerAnimator.Detente(1.8f);
                PlayerController.Detener(2);
                // Condiciones para que se ejecute la animación
                playerAnimator.SetInteger("Herramienta", 0);
                playerAnimator.SetBool("Interactuar", true);
                // Esperamos unos segundos para que se ejecute la animación y luego volvemos a la de idle
                Invoke("ResetAnimation", 1);
                Instantiate(sownGroundPrefabs[pickedSeed], currentCell.transform.position, quaternion.identity);
                pickedSeed = -1;
                Destroy(currentCell.gameObject);
            }
            // Si es una caja de semillas y se tienen los guantes selccionados, recoge la semilla correspondiente
            else if (currentCell.CompareTag("Seed") && inventory.selectedSlot == 0)
            {
                PlayerAnimator.Detente(1.8f);

                PlayerController.Detener(2);

                // Condiciones para que se ejecute la animación
                playerAnimator.SetInteger("Herramienta", 0);
                playerAnimator.SetBool("Interactuar", true);
                // Esperamos unos segundos para que se ejecute la animación y luego volvemos a la de idle
                Invoke("ResetAnimation", 1);
                pickedSeed = currentCell.GetComponent<Seed>().id;
            }
            // Si se tiene seleccionada la regadera, hay agua y la planta no está en su etapa final, la puede regar si cumple las condiciones
            else if (inventory.selectedSlot == 2 && plantWater.CantidadAgua > 0 && currentCell.GetComponent<FoodGrowing>().growthStage < 3)
            {
                switch (currentCell.tag, plantWater.CantidadAgua)
                {
                    case ("Zanahoria", >= 30):


                        PlayerAnimator.Detente(1.8f);
                        PlayerController.Detener(2);
                        
                        currentCell.GetComponent<FoodGrowing>().currentWater += 30;

                        playerAnimator.SetInteger("Herramienta", 2);
                        playerAnimator.SetBool("Interactuar", true);
                        Invoke("ResetAnimation", 1);

                        plantWater.RestarAgua(0.3f,30);


                        break;
                    case ("Lechuga", >= 50):
                        
                        PlayerAnimator.Detente(1.8f);
                        PlayerController.Detener(2);

                        currentCell.GetComponent<FoodGrowing>().currentWater += 50;

                        playerAnimator.SetInteger("Herramienta", 2);
                        playerAnimator.SetBool("Interactuar", true);
                        Invoke("ResetAnimation", 1);

                        plantWater.RestarAgua(0.5f,50);

                        break;
                    case ("Patata", >= 10):
                        
                        PlayerAnimator.Detente(1.8f);
                        PlayerController.Detener(2);

                        currentCell.GetComponent<FoodGrowing>().currentWater += 10;

                        playerAnimator.SetInteger("Herramienta", 2);
                        playerAnimator.SetBool("Interactuar", true);
                        Invoke("ResetAnimation", 1);

                        plantWater.RestarAgua(0.1f,10);

                        break;
                    case ("Tomate", >= 75):

                        PlayerAnimator.Detente(1.8f);
                        PlayerController.Detener(2);

                        currentCell.GetComponent<FoodGrowing>().currentWater += 75;

                        playerAnimator.SetInteger("Herramienta", 2);
                        playerAnimator.SetBool("Interactuar", true);
                        Invoke("ResetAnimation", 1);

                        plantWater.RestarAgua(0.75f,75);
                        break;
                }
            }
            // Si se tienen los guantes seleccionados y el cultivo está en su última etapa, lo recoge. Se elimina el cultivo, volviendo a ser una zona arada.
            // Falta llamar al método que añade la comida a los huecos del inventario
            else if (inventory.selectedSlot == 0 && currentCell.GetComponent<FoodGrowing>().growthStage == 3)
            {
                switch (currentCell.tag)
                {
                    case "Zanahoria":
                        Instantiate(plowedGroundPrefab, currentCell.transform.position, quaternion.identity);

                        PlayerAnimator.Detente(1.8f);
                        Destroy(currentCell.gameObject);
                        playerAnimator.SetInteger("Herramienta", 0);
                        playerAnimator.SetBool("Interactuar", true);
                        Invoke("ResetAnimation", 1);
                        PlayerController.Detener(2);

                        puntos += 30;
                        textpuntos.text = puntos.ToString();


                        break;
                    case "Lechuga":
                        Instantiate(plowedGroundPrefab, currentCell.transform.position, quaternion.identity);

                        PlayerAnimator.Detente(1.8f);
                        Destroy(currentCell.gameObject);
                        playerAnimator.SetInteger("Herramienta", 0);
                        playerAnimator.SetBool("Interactuar", true);
                        Invoke("ResetAnimation", 1);
                        PlayerController.Detener(2);

                        puntos += 50;
                        textpuntos.text = puntos.ToString();

                        break;
                    case "Patata":
                        Instantiate(plowedGroundPrefab, currentCell.transform.position, quaternion.identity);

                        PlayerAnimator.Detente(1.8f);
                        Destroy(currentCell.gameObject);
                        playerAnimator.SetInteger("Herramienta", 0);
                        playerAnimator.SetBool("Interactuar", true);
                        Invoke("ResetAnimation", 1);
                        PlayerController.Detener(2);


                        puntos += 10;
                        textpuntos.text = puntos.ToString();

                        break;
                    case "Tomate":
                        Instantiate(plowedGroundPrefab, currentCell.transform.position, quaternion.identity);
                        
                        PlayerAnimator.Detente(1.8f);
                        Destroy(currentCell.gameObject);
                        playerAnimator.SetInteger("Herramienta", 0);
                        playerAnimator.SetBool("Interactuar", true);
                        Invoke("ResetAnimation", 1);
                        PlayerController.Detener(2);

                        puntos += 75;
                        textpuntos.text = puntos.ToString();

                        break;
                }
            }
        }
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        // Detecta el tipo de suelo para obtener su gameObject
        if (other.CompareTag("Arable") || other.CompareTag("Plowed") || other.CompareTag("Seed") || other.CompareTag("Zanahoria") || other.CompareTag("Lechuga") || other.CompareTag("Patata") || other.CompareTag("Tomate"))
            currentCell = other.gameObject;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Evitamos que podamos realizar acciones fuera del área arable/cultivable
        if (other.CompareTag("Arable") || other.CompareTag("Plowed") || other.CompareTag("Seed") || other.CompareTag("Zanahoria") || other.CompareTag("Lechuga") || other.CompareTag("Patata") || other.CompareTag("Tomate"))
            currentCell = null;
    }

    private void ResetAnimation()
    {
        // Restaura la
        playerAnimator.SetBool("Interactuar", false);
    }
}
