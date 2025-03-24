using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public delegate void MineHandler();
    public static event MineHandler OnMineReady;
    private int catched = 0;
    public void AddCatch()
    {
        catched++;
        if(catched >= 3)
        {
            //GameObject.Find("Player").GetComponent<PlayerController>().MineIsReady();
            OnMineReady();
            Destroy(gameObject);
        }
    }
}
