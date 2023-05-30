using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SvitiokManager : MonoBehaviour
{
    public GameObject xyi;
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            xyi.SetActive(true);
        }
    }
    
    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            xyi.SetActive(false);
        }
    }
}
