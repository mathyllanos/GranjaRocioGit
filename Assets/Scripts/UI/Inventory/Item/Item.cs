using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "ScriptableObject/Item")]
public class Item : ScriptableObject
{
    [Header("Only gameplay")]
    public ActionType action;
    public Vector2Int range = new Vector2Int(5, 4);
    public int timeGrow;

    [Range(1f, 100f)]
    public float waterNeeded;

    [Header("Only UI")]
    public bool stackable = true;

    [Header("Both")]
    public Sprite image;

    public enum ActionType
    {
        Glove,
        Hoe,
        WateringCan,
    }

}
