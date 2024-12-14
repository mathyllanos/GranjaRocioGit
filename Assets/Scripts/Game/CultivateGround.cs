using System;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class CultivateGround : MonoBehaviour
{
    /*  Descripción: Sistema para cultivar el suelo
        Autor: Adrián */
    public GameObject currentCell = null;
    public GameObject groundPrefab;

    private void Update()
    {
        if (currentCell != null && Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(groundPrefab, currentCell.transform.position, quaternion.identity);
            Destroy(currentCell.gameObject);
        }
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Arable"))
            currentCell = other.gameObject;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Arable"))
            currentCell = null;
    }
}
