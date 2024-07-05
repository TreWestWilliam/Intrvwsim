using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawning : MonoBehaviour
{
    public GameObject Meteor;
    public Texture2D[] MeteorTextures;
    public Sprite[] MeteorSprites;

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
        GameObject MyMeteor = GameObject.Instantiate(Meteor, new Vector3(transform.position.x, Random.Range(-5, 5), 3), new Quaternion());
        SpriteRenderer MeteorSprite = MyMeteor.GetComponent<SpriteRenderer>();
        MeteorSprite.sprite = MeteorSprites[(int)Random.Range(0, MeteorSprites.Length)];
        Invoke(nameof(MeteorSpawn), Random.Range(0.1f, .8f));
    }
}
