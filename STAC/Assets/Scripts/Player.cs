using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject Theme;
    public GameObject DieParticle;
    public static Player instance;
    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void Die()
    {
        Theme.transform.SetParent(GameObject.Find("GameManager").transform);
        Instantiate(DieParticle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
