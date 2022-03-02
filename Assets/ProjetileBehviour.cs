using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjetileBehviour : MonoBehaviour
{
    public Vector2 dir;
    [SerializeField, Range(1, 20)] public float speed = 2f;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        transform.position += (Vector3)dir * Time.deltaTime * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>())
        {
            collision.GetComponent<PlayerMovement>().GetHit();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
