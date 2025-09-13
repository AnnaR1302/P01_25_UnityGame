using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int FruitCollected = 0;
    public Text FruitOutput;
    private void Update()
    {
        FruitOutput.text = "Score: " + FruitCollected;
    }

    public void CollectFruit()
    {
        FruitCollected++;
    }
}
