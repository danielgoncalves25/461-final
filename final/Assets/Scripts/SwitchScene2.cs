using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene2 : MonoBehaviour
{
   void OnTriggerEnter(Collider gold){
       SceneManager.LoadScene(3);
   }
}

