using UnityEngine;

public class Misiones : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float tiempo;
    public float Restante;
    


    public void Crono() 
    { 
    
        Restante = tiempo - Time.time;
    
    
    
    }

   




    void Start()
    {
        Restante = tiempo;
        
    }






    // Update is called once per frame
    void Update()
    {
        
        if(Restante > 0) 
        {

            Crono();
        }












    }
}
