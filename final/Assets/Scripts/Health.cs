using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour 
{
	public float HealthPoints
	{
		get{return healthPoints;}
		set
		{
			healthPoints = value;

			//If health is < 0 then die
			if (healthPoints <= 0)
            {
				print("Dieing");
				explosion.Play();
                Destroy(gameObject, .2f);
            }
		}
	}

	[SerializeField]
	public float healthPoints = 100f;

	private ParticleSystem explosion;


	void Start()
    {
		explosion = GetComponent<ParticleSystem>();
	}
}
