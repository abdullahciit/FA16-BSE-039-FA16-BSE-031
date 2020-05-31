using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class mapactivate : MonoBehaviour
{
    public GameObject map;
    public GameObject cave;
    public GameObject levelui;
    //public GameObject cave;
    bool active;
    // Start is called before the first frame update
    void Start()
    {
        map.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        if(active == true)
        {
            map.SetActive(true);
            cave.SetActive(false);
            levelui.SetActive(true);
            timedel();
            levelui.SetActive(false);
            Destroy(gameObject);

        }
        else
        {
            map.SetActive(false);
        }
        
    }
    void OnTriggerEnter(Collider other)
    {
        
     
     if (other.gameObject.tag == "Player") {
            
            active = true;
        
    }
    }
    IEnumerator timedel()
    {
        yield return new WaitForSeconds(5);
    }
}
