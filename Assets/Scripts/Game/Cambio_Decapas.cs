using Unity.VisualScripting;
using UnityEngine;

public class Cambio_Decapas : MonoBehaviour
{

    private SpriteRenderer SpriteRenderer;


   void Awake() 
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();    


    }



    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {


            SpriteRenderer.sortingOrder = 6;






        }
    }


    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {




            SpriteRenderer.sortingOrder = 0;




        }
    }








    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
