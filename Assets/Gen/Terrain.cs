using System.Collections.Generic;
using UnityEngine;


public class Terrain : MonoBehaviour
{
    [SerializeField] private List<GameObject> Obstacles;

    [SerializeField] private GameObject terrain;
    [SerializeField] private GameObject player;
    [SerializeField] private int levels = 10;

    private int count = 1;

    private Vector3 c = new(0, 0, 10);

    private Vector3 d = new(0, 1, 0);


    // Start is called before the first frame update
    public void Start()
    {
        Instantiate(terrain).transform.position = new Vector3(0, 0, 0);
        count = 1;
    }

    // Update is called once per frame
    public void Update()
    {
        if (count == 1) 
        {
            while (count < levels)
            {
                sextion();
            }
        }
    }

    private void sextion()
    {
        var e = Instantiate(terrain, (c * count), Quaternion.identity);
        var a = new Vector3(-4.5f, 0f, 0f);
        Obs(e, Obstacles[0],a);
        var b = new Vector3(1.5f, 0f, 0f);
        Obs(e, Obstacles[1],b);
        count++;
    }

    private GameObject Obs(GameObject section, GameObject ha, Vector3 post)
    {
        float r1 = Random.Range(-3f, 3f);
        float r2 = Random.Range(-5f, 5f);
        var b = section.transform.position;
        d.z = r2;
        d.x = r1;
        var s = Instantiate(ha, (b + d), Quaternion.identity);
        return s;
    }
}