
using UnityEngine;

public class SaveGame : MonoBehaviour
{
    [SerializeField] private Transform yes;
    // public Camera[] cams;
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
    
    void SaveWindow()
    {
        cams[0].SetActive(false);
        cams[1].SetActive(false);
        cams[2].SetActive(true);
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
        SaveWindow();

    }

   
}