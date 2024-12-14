using System;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class CultivateGround : MonoBehaviour
{
    /*  Descripción: Sistema para cultivar el suelo
        Autor: Adrián */
    public GameObject currentCell = null;
    public GameObject plowedGroundPrefab;
    public GameObject[] sownGroundPrefabs = new GameObject[4];

    [Range(-1, 3)]
    public int pickedSeed = -1;
    public InventoryManager tool;

    private void Update()
    {
        if (currentCell != null && Input.GetKeyDown(KeyCode.Space))
        {
            // Si el terreno es arable y se tiene la azada seleccionada, creamos el terreno arado
            if (currentCell.CompareTag("Arable") && tool.selectedSlot == 5)
            {
                Instantiate(plowedGroundPrefab, currentCell.transform.position, quaternion.identity);
                Destroy(currentCell.gameObject);
            }
            // Si ya está arado y se tienen los guantes seleccionados, se crea un terreno sembrado según la semilla que se haya recogido 
            else if (currentCell.CompareTag("Plowed") && tool.selectedSlot == 4 && pickedSeed >= 0)
            {
                Instantiate(sownGroundPrefabs[pickedSeed], currentCell.transform.position, quaternion.identity);
                pickedSeed = -1;
                Destroy(currentCell.gameObject);
            }
            else if (currentCell.CompareTag("Seed") && tool.selectedSlot == 4)
                pickedSeed = currentCell.GetComponent<Seed>().id;
            
        }
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Arable") || other.CompareTag("Plowed") || other.CompareTag("Seed"))
            currentCell = other.gameObject;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Arable") || other.CompareTag("Plowed"))
            currentCell = null;
    }
}
