﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Product : MonoBehaviour
{
    public float heightDestroy = 20f;
    public float speed = 15f;

    void Start()
    {
    }

    void Update()
    {
        var gameObjectTransform = gameObject.transform;
        gameObjectTransform.position += new Vector3(0, speed * Time.deltaTime, 0);

        if (gameObjectTransform.position.y >= heightDestroy)
        {
            Destroy(gameObject);
        }
    }
}