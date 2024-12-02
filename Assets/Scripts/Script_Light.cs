using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Script_Light : MonoBehaviour
{
    [SerializeField] private GameObject posiNave;

    // Update is called once per frame
    void Update()
    {
        transform.rotation = posiNave.transform.rotation;
    }
}
