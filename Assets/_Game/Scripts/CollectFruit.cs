using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectFruit : MonoBehaviour
{
    [SerializeField] public int FruitPoints;

    public GameManager GM;
    void OnTriggerEnter2D(Collider2D WalkedInto)
    {
        if(WalkedInto.name == "Player")
        {
            Debug.Log("Collected");
            GM.CollectFruit();
            Destroy(gameObject);
        }
    }
}
