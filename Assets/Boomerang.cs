using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    bool go; //change direction weapon

    GameObject player;
    GameObject weapon;

    Transform itemToRotate;

    Vector3 locationInfrontOfPlayer;
    void Start()
    {
        go = false;

        player = GameObject.Find("Lonk");
        weapon = GameObject.Find("Boomerang");

        locationInfrontOfPlayer = new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z) + player.transform.forward * 10f;

        StartCoroutine(Throw());
    }
    IEnumerator Throw()
    {
        go = true;
        yield return new WaitForSeconds(1.5f);
        go = false;
    }
    private void Update()
    {
        transform.Rotate(0, Time.deltaTime * 500, 0);
        if (go)
        {
            // change pos to in front of the player
            transform.position = Vector3.MoveTowards(transform.position, locationInfrontOfPlayer, Time.deltaTime * 40);
        }
        if (!go)
        {
            // return to player
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, player.transform.position.y +1, player.transform.position.z), Time.deltaTime * 40);

        }
        if (!go && Vector3.Distance(player.transform.position, transform.position) < 1.5f)
        {
            Destroy(gameObject);
        }
    }
}
