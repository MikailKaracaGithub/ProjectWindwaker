using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RupeeCounter : MonoBehaviour
{

    public Text RupeeAmount;
    public PlayerLogic player;
    void Start()
    {
        RupeeAmount = GetComponent<Text>();

    }

    void Update()
    {
        if (player != null)
        {
            int scoreCounter = player.ReturnRupeeCount();
            RupeeAmount.text = scoreCounter.ToString("000");  // make it a string to output to the Text object
        }
    }
}
