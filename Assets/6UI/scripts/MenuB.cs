using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuB : MonoBehaviour
{
    [SerializeField] private Transform yes;
    public GameObject[] cams;
    private bool state = false;
    private Vector3 o;
    private Vector3 n;

    private void Awake()
    {
        o = yes.position;
        n = yes.position - Vector3.forward / 5f;
    }

    private void Update()
    {
        if (state)
        {
            yes.position = n;
            
        }
        else
        {
            yes.position = o;
        }
    }

    private void Goback()
    {
        Debug.Log("start game");
        cams[0].SetActive(true);
        cams[1].SetActive(false);
        cams[2].SetActive(false);
    }
    private void OnMouseOver()
    {
        state = true;
    }

    private void OnMouseExit()
    {
        state = false;
    }

    private void OnMouseDown()
    {
       
        Goback();
    }
}
