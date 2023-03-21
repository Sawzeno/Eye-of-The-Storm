using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Animal : MonoBehaviour
{
    [SerializeField] private GameObject snake;
    [SerializeField] private int size = 5;
    [SerializeField] private float speed;
    [SerializeField] private float moveDistance;
    private Vector3 initx = Vector3.forward;

    private Vector3 momentumX = Vector3.forward;
    private Vector3 momentumY = Vector3.up;
    private Vector3 momentumZ = Vector3.right;
    private Vector3 momentum;
    private List<Transform> body = new List<Transform>();

    private void Awake()
    {
        var c = Time.deltaTime/speed;
        for (int i = 0; i < size; i++)
        {
            var piece = Instantiate(snake).transform;
            piece.position = new Vector3(i, 0, 0);
            body.Add(piece);
        }

        momentum = momentumX;
        InvokeRepeating(nameof(MoveSnake), c,  speed/10);
    }

    private void MoveSnake()
    {
        body[0].position += momentum;
        for (int i = body.Count - 1; i >= 1; i--)
        {
            body[i].position = body[i - 1].position;
            Debug.Log(body[i].position);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            momentum = (momentumX);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            momentum = -(momentumX);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            momentum = (momentumZ);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            momentum = -(momentumZ);
        }


        if (Input.GetKeyDown(KeyCode.J))
        {
            momentum = (momentumY);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            momentum = -(momentumY);
        }
    }
}
