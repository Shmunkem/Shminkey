using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider PlayerRB)
    {
        Debug.Log("finished stage 1");
        Player.transform.Translate(new Vector3(35, 1, 0));
    }
}
