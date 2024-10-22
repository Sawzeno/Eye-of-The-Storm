using System;
using Unity.VisualScripting;
using UnityEngine;


public class NewGame : MonoBehaviour
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

    private void StartGame()
    {
        Debug.Log("start game");
        cams[0].SetActive(false);
        cams[1].SetActive(true);
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
       
        StartGame();
    }

}