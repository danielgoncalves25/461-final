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
				death.Play();
                Destroy(gameObject, .3f);
            }
		}
	}

	[SerializeField]
	public float healthPoints = 100f;

	private ParticleSystem death;


	void Start()
    {
		death = GetComponent<ParticleSystem>();
	}
}
