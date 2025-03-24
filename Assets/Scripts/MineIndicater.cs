using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineIndicater : MonoBehaviour
{
    private void OnEnable()
    {
        Mine.OnMineReady += ViewOnOff;
    }
    private void OnDisable()
    {   
        Mine.OnMineReady -= ViewOnOff;
    }
    private void ViewOnOff()
    {
        this.gameObject.SetActive(true);
    }
}
