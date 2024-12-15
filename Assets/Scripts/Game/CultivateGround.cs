using System;
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
    public AguaPlantas plantWater;                              // Para usar la cantidad de agua

    public Animator playerAnimator;                             // Para ejecutar las condiciones de las animaciones

    private void Update()
    {
        if (currentCell != null && Input.GetKeyDown(KeyCode.E))
        {
            // Si el terreno es arable y se tiene la azada seleccionada, creamos el terreno arado
            if (currentCell.CompareTag("Arable") && inventory.selectedSlot == 5)
            {
                // Condiciones para que se ejecute la animación
                playerAnimator.SetInteger("Herramienta", 1);
                playerAnimator.SetBool("Interactuar", true);
                // Esperamos unos segundos para que se ejecute la animación y luego volvemos a la de idle
                Invoke("ResetAnimation", 2);
                Instantiate(plowedGroundPrefab, currentCell.transform.position, quaternion.identity);
                Destroy(currentCell.gameObject);
            }
            // Si ya está arado y se tienen los guantes seleccionados, se crea un terreno sembrado según la semilla que se haya recogido 
            else if (currentCell.CompareTag("Plowed") && inventory.selectedSlot == 4 && pickedSeed >= 0)
            {
                // Condiciones para que se ejecute la animación
                playerAnimator.SetInteger("Herramienta", 0);
                playerAnimator.SetBool("Interactuar", true);
                // Esperamos unos segundos para que se ejecute la animación y luego volvemos a la de idle
                Invoke("ResetAnimation", 2);
                Instantiate(sownGroundPrefabs[pickedSeed], currentCell.transform.position, quaternion.identity);
                pickedSeed = -1;
                Destroy(currentCell.gameObject);
            }
            // Si es una caja de semillas y se tienen los guantes selccionados, recoge la semilla correspondiente
            else if (currentCell.CompareTag("Seed") && inventory.selectedSlot == 4)
            {
                // Condiciones para que se ejecute la animación
                playerAnimator.SetInteger("Herramienta", 0);
                playerAnimator.SetBool("Interactuar", true);
                // Esperamos unos segundos para que se ejecute la animación y luego volvemos a la de idle
                Invoke("ResetAnimation", 2);
                pickedSeed = currentCell.GetComponent<Seed>().id;
            }
            // Si se tiene seleccionada la regadera, hay agua y la planta no está en su etapa final, la puede regar si cumple las condiciones
            else if (inventory.selectedSlot == 6 && plantWater.CantidadAgua > 0 && currentCell.GetComponent<FoodGrowing>().growthStage < 3)
            {
                switch (currentCell.tag, plantWater.CantidadAgua)
                {
                    case ("Zanahoria", >= 30):
                        currentCell.GetComponent<FoodGrowing>().currentWater += 30;
                        break;
                    case ("Lechuga", >= 50):
                        currentCell.GetComponent<FoodGrowing>().currentWater += 50;
                        break;
                    case ("Patata", >= 10):
                        currentCell.GetComponent<FoodGrowing>().currentWater += 10;
                        break;
                    case ("Tomate", >= 75):
                        currentCell.GetComponent<FoodGrowing>().currentWater += 75;
                        break;
                }
            }
            // Si se tienen los guantes seleccionados y el cultivo está en su última etapa, lo recoge. Se elimina el cultivo, volviendo a ser una zona arada.
            // Falta llamar al método que añade la comida a los huecos del inventario
            else if (inventory.selectedSlot == 4 && currentCell.GetComponent<FoodGrowing>().growthStage == 3)
            {
                switch (currentCell.tag)
                {
                    case "Zanahoria":
                        Instantiate(plowedGroundPrefab, currentCell.transform.position, quaternion.identity);
                        Destroy(currentCell.gameObject);
                        break;
                    case "Lechuga":
                        Instantiate(plowedGroundPrefab, currentCell.transform.position, quaternion.identity);
                        Destroy(currentCell.gameObject);
                        break;
                    case "Patata":
                        Instantiate(plowedGroundPrefab, currentCell.transform.position, quaternion.identity);
                        Destroy(currentCell.gameObject);
                        break;
                    case "Tomate":
                        Instantiate(plowedGroundPrefab, currentCell.transform.position, quaternion.identity);
                        Destroy(currentCell.gameObject);
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
