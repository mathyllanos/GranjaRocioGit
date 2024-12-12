using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Grow : MonoBehaviour
{
    [Range(0, 3)]
    public int stage = 0;
    public bool canGrow;
    public float time = 0;
    public float maxTime;
    public float water = 0;
    public float maxWater;
    public Sprite[] sprites;
    [SerializeField] private SpriteRenderer renderer;

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (canGrow && time == maxTime && water == maxWater)
        {
            stage++;
            switch (stage)
            {
                case 0:
                    renderer.sprite = sprites[0];
                    break;
                case 1:
                    renderer.sprite = sprites[1];
                    break;
                case 2:
                    renderer.sprite = sprites[2];
                    break;
                case 3:
                    renderer.sprite = sprites[3];
                    break;
                default:
                    renderer.sprite = sprites[0];
                    break;
            }
            canGrow = false;
        }
    }
}
