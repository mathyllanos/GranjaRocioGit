using UnityEditor;
using UnityEngine;

public class Misiones : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject CanvasWin;
    public GameObject CanvasLose;

    [SerializeField] float Duracion; 
    
    private float time; 
    [SerializeField] private float inter; 
    private float ac_time;
    private bool detenido;
    public GameObject Aguja;
    public int Conteo;

    public CultivateGround cultivateGround;
    
    void Detener() 
    {
        detenido = true;
        
        if (cultivateGround.puntos >= 250)
            CanvasWin.SetActive(true);

        else
            CanvasLose.SetActive(true);
    }
    
    /* void Tiemer() 
    {
        time += Time.deltaTime;
        inter = time;
        inter = time - ac_time;
        
        Aguja.transform.Rotate(Vector3.back * (360/Duracion) * Time.deltaTime);
    }*/
    
    void Tiks() 
    {
        if (Conteo < 24) 
        {
            Aguja.transform.Rotate(Vector3.back * 15);

            Conteo++;

            Invoke("Tiks", (Duracion / 24));
        }
    }
    
    void Start()
    {
        Invoke("Detener", Duracion);
        Invoke("Tiks", (Duracion / 24));
    }
    
    /* void Update()
    {
        if (!detenido) 
        {

        }

        if (Input.GetKeyDown(KeyCode.R)) 
        {
            ac_time = time;
        }
    }*/
    
}
