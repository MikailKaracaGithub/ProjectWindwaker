using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    public void SelfDestruct()
    {
        Destroy(gameObject);
    }
}
