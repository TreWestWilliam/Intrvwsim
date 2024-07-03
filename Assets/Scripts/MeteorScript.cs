using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MeteorScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector3 Direction;
    // Start is called before the first frame update
    void Start()
    {
        Direction = new Vector3(-1, Random.Range(-1, 1), 0);
        Direction = Direction.normalized;
        Direction *= Random.Range(0.01f, 1);
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(Direction);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        MeteorGame_Shot shot = collision.gameObject.GetComponent<MeteorGame_Shot>();
        if (shot == null)
        {
            GameObject.Find("DefenseManager").GetComponent<DefenseManager>().Damage();
        }
        else 
        {
            GameObject.Find("DefenseManager").GetComponent<DefenseManager>().AddScore(rb.velocity.x+rb.velocity.y);
        }
        Destroy(gameObject);
    }
}
