using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    //public GameObject cubePrefab;
    ObjectPooler objectPooler;

    private void Start()
    {
        objectPooler  = ObjectPooler.Instance;
    }

    void FixedUpdate() {
        //Instantiate(cubePrefab, transform.position, Quaternion.identity);  
        objectPooler.SpawnFromPool("Cube", transform.position, Quaternion.identity);  
    }
}
