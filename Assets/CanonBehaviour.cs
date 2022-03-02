using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBehaviour : MonoBehaviour
{
    [SerializeField, Range(0.1f, 5f)] float cooldown = 1f;
    [SerializeField, Range(0.1f, 5f)] float projetileSpeed = 2f;
    [SerializeField] GameObject projectilePF;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShootTimer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ShootTimer()
    {
        yield return new WaitForSeconds(cooldown);
        Shoot();
        RestartTImer();
    }

    void RestartTImer()
    {
        StartCoroutine(ShootTimer());
    }

    void Shoot()
    {
        GameObject projetile = Instantiate(projectilePF);
        projetile.transform.position = transform.position;
        projetile.GetComponent<ProjetileBehviour>().dir = transform.up.normalized;
        projetile.GetComponent<ProjetileBehviour>().speed = projetileSpeed;
    }
}
