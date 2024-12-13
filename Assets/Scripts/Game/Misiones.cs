using UnityEngine;

public class Misiones : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    [SerializeField] float Duracion;

   private float time;
   [SerializeField] private float inter;
   private float ac_time;
    private bool Denido;
    public GameObject Aguja;
    public int Conteo;


    

    void Detener() 
    {
        Denido = true;

        Debug.Log("Fin_Del_tiempo");
    }


    void Tiemer() 
    {


        time += Time.deltaTime;
        inter = time;
        inter = time - ac_time;



        Aguja.transform.Rotate(Vector3.back * (360/Duracion) * Time.deltaTime);






    }









    void Start()
    {
        Invoke("Tiks", (Duracion / 24));
    }

    void Tiks() 
    {
        if (Conteo < 24) 
        {

            Aguja.transform.Rotate(Vector3.back * 15);

            Conteo++;


            Invoke("Tiks", (Duracion / 24));
        }

        
    }

    


    // Update is called once per frame



















    void Update()
    {


        if (!Denido) 
        {

            



        }
        Invoke("Detener", Duracion);


        if (Input.GetKeyDown(KeyCode.R)) 
        {

            ac_time = time;


        }

















    }












}
