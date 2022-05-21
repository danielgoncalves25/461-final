using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject gold = null;


    public void Start()
    {
        //gold.SetActive(false);
        
        Invoke("Show", 60f);

        StartCoroutine(WaitBeforeShow());
        //gold.SetActive(true);
    }
    private void Show(){

        gold.SetActive(true);

    }

    private IEnumerator WaitBeforeShow(){
        gold.SetActive(false);
        yield return new WaitForSeconds(5);
    }
}
