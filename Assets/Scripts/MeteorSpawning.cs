using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawning : MonoBehaviour
{
    public GameObject Meteor;


    // Start is called before the first frame update
    void Start()
    {
        MeteorSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MeteorSpawn() 
    {
        GameObject.Instantiate(Meteor, new Vector3(transform.position.x, Random.Range(-5, 5), 3), new Quaternion());
        Invoke(nameof(MeteorSpawn), Random.Range(0.1f, .8f));
    }
}
