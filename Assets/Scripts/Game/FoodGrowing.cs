using UnityEngine;

public class FoodGrowing : MonoBehaviour
{
    /*  Descripción: Crecimiento de las plantas (comida)
        Autor: Adrián */
    
    // ==== Atributos ====
    [Header("Growth requirements")]
    [Range(0, 3)] public int growthStage = 0;       // Indicador de la etapa de crecimiento en la que se encuentra la planta
    public float currentTime = 0;                   // Tiempo transcurrido desde que se plantó
    public float currentWater = 0;                  // Cantidad de agua que ha obtenido tras ser regada
    public Item foodScriptableObject;               // Scriptable Object donde se encuentran los requisitos a cumplir para cambiar de etapa
    [Header("Image resources")]
    public new SpriteRenderer renderer;             // Necesario para poder poner el sprite correspondiente a la etapa actual
    public Sprite[] stageSprites = new Sprite[4];   // Array con las imágenes correspondientes a las 4 etapas

    private void Update()
    {
        // Mientras no se encuentre en la última etapa de crecimiento y el tiempo sea menor al requerido, el tiempo aumenta. El tiempo se detiene a la mitad del progreso si no se riega con la suficiente agua.
        if (growthStage < 3 && (currentTime < Mathf.Abs(foodScriptableObject.timeGrow / 2) || (currentWater >= foodScriptableObject.waterNeeded && currentTime >= Mathf.Abs(foodScriptableObject.timeGrow / 2))))
            currentTime += Time.deltaTime;
        
        // No se hace nada si ya alcanzó la última etapa o no se cumplen los requisitos. En caso contrario, se cambia de etapa y se reinician el tiempo y agua.
        if (growthStage >= 3 || currentTime < foodScriptableObject.timeGrow || currentWater < foodScriptableObject.waterNeeded) return;
        growthStage++;
        currentTime = 0;
        currentWater = 0;
        renderer.sprite = growthStage switch
        {
            0 => stageSprites[0],
            1 => stageSprites[1],
            2 => stageSprites[2],
            3 => stageSprites[3],
            _ => renderer.sprite
        };
    }
}
