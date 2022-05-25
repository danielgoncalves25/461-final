using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
   void OnTriggerEnter(Collider gold){
       SceneManager.LoadScene(2);
   }
}
