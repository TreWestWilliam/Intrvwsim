using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorGame_Shot : MonoBehaviour
{
    public Rigidbody2D rb;
    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        if (rb == null) 
        {
            rb = gameObject.GetComponent<Rigidbody2D>();
        }
        direction = Vector3.Normalize(Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position) *10;
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(direction);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        MeteorScript MS = collision.gameObject.GetComponent<MeteorScript>();
        if (MS != null) 
        {
            Destroy(MS.gameObject);
        }
        Destroy(gameObject);
    }
}
