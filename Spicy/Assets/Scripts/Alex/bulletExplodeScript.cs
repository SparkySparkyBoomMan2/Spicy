﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletExplodeScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
