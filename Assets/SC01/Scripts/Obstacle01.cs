using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle01 : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject,10f);
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.localPosition += new Vector3(-1 * GameManager.instance.speed * Time.deltaTime, 0, 0);
    }
}
