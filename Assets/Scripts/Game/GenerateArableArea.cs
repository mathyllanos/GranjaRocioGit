using UnityEngine;

public class GenerateArableArea : MonoBehaviour
{
    /*  Descripción: Crea automáticamente un área con celdas que se pueden arar
        Nota adicional: Posibilidad de crear un array que se deja comentado por el momento al no tener uso
        Autor: Adrián */
    public GameObject arableGroundPrefab;       // El prefab de la celda arable
    public int rows = 10;                       // Número de filas que tendrá el área
    public int columns = 17;                    // Número de columnas que tendrá el área

    // private GameObject[,] _arableGrid;       // Array que contiene todas las celdas arables
    private Vector2 _position;                  // Guarda la posición donde se creará la celda
    private GameObject _cell;                   // Para poder manipular mejor la celda instanciada

    private void Start()
    {
        // Creamos un array con el número de filas y columnas
        // _arableGrid = new GameObject[rows, columns];
        
        // Usamos un for anidado para pintar las celdas como si se tratase de una cuadrícula
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                // La posición donde se va a crear la celda. Comienza en la esquina superior izquierda y acaba en la esquina inferior derecha.
                _position = new Vector2(transform.position.x + j, transform.position.y - i);
                // Instanciamos la celda en la coordenada determinada anteriormente y como hija del objeto vacío en el que se encuentra
                _cell = Instantiate(arableGroundPrefab, _position, Quaternion.identity, transform);
                // Le damos un nombre más distintivo en la jerarquía (facilita las pruebas)
                _cell.name = "Cell " + i + "," + j;
                // Finalmente se añade al array
                // _arableGrid[i, j] = _cell;
            }
        }
    }
}
