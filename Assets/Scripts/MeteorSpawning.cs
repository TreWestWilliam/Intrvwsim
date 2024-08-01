using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawning : MonoBehaviour
{
    public GameObject Meteor;
    public Texture2D[] MeteorTextures;
    public Sprite[] MeteorSprites;
    public DefenseManager DM;

    // Start is called before the first frame update
    void Start()
    {
        MeteorSpawn();
        //DM = FindObjectOfType<DefenseManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MeteorSpawn() 
    {
        GameObject MyMeteor = Instantiate(Meteor, new Vector3(transform.position.x, Random.Range(-5, 5), 3), new Quaternion());
        SpriteRenderer MeteorSprite = MyMeteor.GetComponent<SpriteRenderer>();
        MeteorSprite.sprite = MeteorSprites[(int)Random.Range(0, MeteorSprites.Length)];
        DM.Meteors.Add(MyMeteor);
        Invoke(nameof(MeteorSpawn), Random.Range(0.1f, .8f));
    }
}
