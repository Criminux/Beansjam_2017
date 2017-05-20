using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class AsteroidSpawning : MonoBehaviour
{

	[SerializeField] private GameObject[] asteroidPrefabs;

	[SerializeField] private float count;

	[SerializeField] private int seed;

	// Use this for initialization
	void Start ()
	{
		SpawnAsteroids();
	}

	private void SpawnAsteroids()
	{
		Random random = new Random(seed);

		for (int i = 0; i < count; i++)
		{
			var selectedPrefab = asteroidPrefabs[random.Next(asteroidPrefabs.Length)];

			var size = transform.localScale;

			var position = new Vector3(
				(float) random.NextDouble() * size.x,
				(float) random.NextDouble() * size.y,
				(float) random.NextDouble() * size.z
			);


			var rotation = Quaternion.Euler(
				(float)random.NextDouble() *360f, 
				(float)random.NextDouble() *360f, 
				(float)random.NextDouble() *360f
			);
		

			var newAsteroid = Instantiate(selectedPrefab);
			newAsteroid.transform.parent = transform;
			newAsteroid.transform.position = transform.position + position - transform.localScale *0.5f ;
			newAsteroid.transform.rotation = rotation;
		}
	}
}
