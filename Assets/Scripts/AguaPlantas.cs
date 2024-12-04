using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AguaPlantas : MonoBehaviour
{
    public float CantidadAgua = 0;

    public Image bar;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKey(KeyCode.Space)){ CantidadAgua += 0.001f; bar.fillAmount = CantidadAgua; }
    }
    
}
