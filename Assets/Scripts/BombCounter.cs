using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BombCounter : MonoBehaviour
{

    public Text BombAmount;
    public PlayerLogic player;
    void Start()
    {
        BombAmount = GetComponent<Text>();

    }

    void Update()
    {
        if (player != null)
        {
            int scoreCounter = player.ReturnBombCount();
            BombAmount.text = scoreCounter.ToString("00");  // make it a string to output to the Text object
        }
    }
}
