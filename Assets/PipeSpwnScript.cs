using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpwnScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnrate = 3;
    private float spawntime = 0;
    public float heightoffset = 5;

    void spawnpipe()
    {
        float lowestpoint = transform.position.y - heightoffset;
        float heighestpoint = transform.position.y + heightoffset;

        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestpoint, heighestpoint), 0), transform.rotation);
    }

    // Start is called before the first frame update
    void Start()
    {
        spawnpipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawntime < spawnrate)
        {
            spawntime += Time.deltaTime;
        }
        else
        {
            spawnpipe();
            spawntime = 0;
        }
    }
}
