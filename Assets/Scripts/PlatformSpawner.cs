using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{

    //public static PlatformSpawner Instance;
    public GameObject Platform;
    public GameObject diamond;
    Vector3 lastPos;
    float size;
    public bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        lastPos = Platform.transform.position;
        size = Platform.transform.localScale.x;

    }

    // Update is called once per frame
    public void StartSpawnPlatform()
    {
        InvokeRepeating("SpawnPlatforms", 0.1f, 0.2f);
    }
    void Update()
    {
        if (GameManager.Instance.gameOver==true) 
        {
            CancelInvoke("SpawnPlatforms");
        }
    }
   
    void SpawnPlatforms() 
    {
        int ran = Random.Range(0, 6);
        if (ran < 3)
        {
            SpawnX();
        }
        else if (ran >= 3) 
        {
            SpawnZ();
        }
    }
    void SpawnX() 
    {
        Vector3 pos = lastPos;
        pos.x += size;
        lastPos = pos;
        Instantiate(Platform,pos,Quaternion.identity);

        int ran = Random.Range(0,4);
        if (ran < 1) 
        {
            Instantiate(diamond, new Vector3(pos.x, pos.y+1,pos.z), diamond.transform.rotation) ;
        }

    }
    void SpawnZ()
    {
        Vector3 pos = lastPos;
        pos.z += size;
        lastPos = pos;
        Instantiate(Platform, pos, Quaternion.identity);
        int ran = Random.Range(0, 4);
        if (ran < 1)
        {
            Instantiate(diamond, new Vector3(pos.x, pos.y + 1, pos.z), diamond.transform.rotation);
        }
    }

}
