using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;


public class terrbin : MonoBehaviour
{
    [Header("Fields")] [SerializeField] private List<GameObject> parentGameObjects;
    [SerializeField] private List<GameObject> section;
    [SerializeField] private List<GameObject> obstacles;

    [SerializeField(), Range(0, 300)] private int level = 10;
    
    //constants
    [Header("Constants")] [SerializeField]private GameObject env;
    private int count;
    private int pC;
    private Vector3 golbalPosZ = new Vector3(0, 0, 10);
    // private Vector3 golbalPosX = new Vector3(10, 0, 0);

    private int chance;

    //fuckery 
    private GameObject za;
    private GameObject zb;
    private GameObject xa;
    private GameObject xb;
    
    private void Start()
    {
        Instantiate(section[0]).transform.position = new Vector3(0, 0, 5);
        count = 0;
        pC = 0;
        Parent(pC);

    }

    private void Update()
    {
        var t = Random.Range(0, 101);
        chance = t switch
        {
            > 96 => 3,
            > 70 and < 91 => 2,
            > 40 and < 71 => 1,
            > 0 and < 41 => 0,
            _ => chance
        };

       
        if (count < level)
        {
            
            if (chance == 0 || chance == 1 || chance == 2)
            {
                PlatoZ(za ,section[chance], chance);
            }

            if (chance == 3)
            {
                var a = PlatoX(za ,section[chance], chance).transform.position+new Vector3(0,0,5);
                pC++;
                Parent(pC).transform.position = a;
                
            }

            if (pC == 3)
            {
                pC = 0;
            }

            count++;
        }
    }

    private GameObject Parent(int index)
    {
        za = Instantiate(parentGameObjects[index]);
        za.transform.Rotate(15, 10*index, 0);
        // Instantiate(section[0],za.transform,false).transform.position = new Vector3(0, 0, 5);
        golbalPosZ = new Vector3(0, 0, 5);
        return za;
    }
    private GameObject PlatoZ(GameObject par, GameObject plate, int index)
    {
        var a = Instantiate(plate, za.transform, false);
        var b = a.transform.localScale.z;
        a.transform.localPosition = new Vector3(0, 0, (golbalPosZ.z + b / 2));
        golbalPosZ.z += b;
        return a;
    }

    private GameObject PlatoX(GameObject par ,GameObject plate, int index)
    {
        var a = Instantiate(plate, za.transform, false);
        var b = a.transform.localScale.z;
        a.transform.localPosition = new Vector3(0, 0, (golbalPosZ.z + b / 2));
        return a;
    }



    private int Debug(int a)
    {
        UnityEngine.Debug.Log(a);
        UnityEngine.Debug.Log(golbalPosZ);
        UnityEngine.Debug.Log("terrbin" + transform.position);
        return 0;
    }
}