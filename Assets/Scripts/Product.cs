using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Product : MonoBehaviour
{
    private const float HeightDestroy = 30f;
    private const float Speed = 10f;

    public float Price { get; set; }
    public float CoastPrice { get; set; }
    
    void Update()
    {
        var gameObjectTransform = gameObject.transform;
        gameObjectTransform.position += new Vector3(0, Speed * Time.deltaTime, 0);

        if (gameObjectTransform.position.y >= HeightDestroy)
        {
            Destroy(gameObject);
        }
    }
}