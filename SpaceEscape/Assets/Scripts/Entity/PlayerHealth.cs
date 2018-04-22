using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public GameObject player;
    Status status;
    int hpMonitor;
    public Text output;

    // Use this for initialization
    void Start () {
        hpMonitor = 0;
        status = player.GetComponent("Status") as Status;
    }

    // Update is called once per frame
    void Update () {
        if (hpMonitor != status.Hp)
        {
            output.text = "HP: " + status.Hp + '/' + status.MaxHp;
            hpMonitor = status.Hp;
        }
        if (hpMonitor == 0)
        {
            output.text = "HP is 0!";
        }
    }

}
