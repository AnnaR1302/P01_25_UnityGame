using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Player : MonoBehaviour
{
    public int health = 3;


    private void Update()
    {
        if(health <= 0)
        {
            health = 0;
            Destroy(gameObject);
        }
    }
}
