using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    Animation anim;
    void Awake()
    {
        anim = gameObject.GetComponent<Animation>();
    }

    void Start()
    {
        anim = GetComponent<Animation>();
        //foreach (AnimationState state in anim)
        //{
        //    print(state);
        //}
        //anim.Play("Run");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
    }
}
