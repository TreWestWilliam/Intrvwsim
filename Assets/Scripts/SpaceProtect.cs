using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceProtect : MonoBehaviour
{
    public int hp = 10;
    public GameObject GunBase;
    public Transform BulletSpawn;
    public GameObject BulletPrefab;
    public float CooldownTime;
    public float Cooldown=.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 InWorld = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,GunBase.transform.position.z));
        InWorld = InWorld - GunBase.transform.position;
        InWorld.z = GunBase.transform.position.z;
        Debug.DrawLine(GunBase.transform.position, InWorld,Color.red);
        GunBase.transform.right = InWorld;
        
        //InWorld.Normalize();
        //float rotation_z = Mathf.Atan2(InWorld.y, InWorld.x) * Mathf.Rad2Deg;
        //GunBase.transform.rotation = Quaternion.Euler(0f, 0f, rotation_z- 90);
       
        //Quaternion rotation = Quaternion.LookRotation(Vector3.up,InWorld - GunBase.transform.position);
        //GunBase.transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);

        if (Input.GetMouseButtonDown(0)) 
        {
            if (CooldownTime < Time.time) 
            {
                GameObject.Instantiate(BulletPrefab, BulletSpawn.position, new Quaternion());
                CooldownTime = Time.time + Cooldown;
            }
            
        }
    }
}
