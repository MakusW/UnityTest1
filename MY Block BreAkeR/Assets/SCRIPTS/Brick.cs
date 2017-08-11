using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	
	public Sprite[] hitSprites;
	private int timesHit;
	private LevelManager levelManager;
	public static int breakableCount = 0;
	private bool isBreakable;
	public GameObject smoke;


	// Use this for initialization
	void Start () {
	isBreakable = (this.tag == "Breakable");
	if (isBreakable) {
		breakableCount++;
		print (breakableCount);

	}

	timesHit = 0;
	levelManager = GameObject.FindObjectOfType<LevelManager> ();
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	}

		void OnCollisionEnter2D (Collision2D collision)
	{
		
		if (isBreakable) {
			HandleHits ();
		}


	}

	void HandleHits ()
	{	{
		timesHit++;
		 int maxHits = hitSprites.Length +1;
		if (timesHit >= maxHits) {
			breakableCount --;
			levelManager.BrickDestroyed();
			Instantiate (smoke, gameObject.transform.position, Quaternion.identity);

		GetComponent<AudioSource>().Play();

			Destroy (gameObject);
		} else {
		LoadSprites();
		}


	}
	}

	void LoadSprites ()
	{ int spriteIndex = timesHit -1;
	this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
	}


		// TODO Remove this method once we can really win
		void SimulateWin ()
	{	levelManager.LoadNextLevel();
	}

}
