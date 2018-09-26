using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour {
	
	public float speed = 0.13f;
	float gravity = 0.04f;
	float slideSpeed;
	float velocity;
	public float groundHeight;
	float upperLimit = 0.9f;
	float lowerLimit = -4f;
	public bool isJumping;
	bool isSliding;
	public bool isForward;
	public int health = 20;
	public int MaxHealth = 20;
	bool isInvincible;
	float timeInvincible;

	public int GreasePoints = 0;
	public float damageMulti = 1;
	public float defense = 1;

	public int EnemiesKilledTotal = 0;
	public bool bossAlive = false;
	float bosslimit;


	public Animator animator;

	public GameObject ouchsound;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update (){

		if (EnemiesKilledTotal > 8) {
			if (!bossAlive) {
				Vector2 SpawnPoint = new Vector2 (transform.position.x + 7, -1.4f);
				GameObject.Find ("BossHandler").GetComponent<BossFunctions> ().SpawnBoss (SpawnPoint, "Eggward");
				bosslimit = SpawnPoint.x;
				bossAlive = true;
			}
		}
			

		//Detect direction
		if (Input.GetKey (KeyCode.A)) {
			GetComponent<SpriteRenderer> ().flipX = true;
			isForward = false;
		}
		if (Input.GetKey (KeyCode.D)) {
			GetComponent<SpriteRenderer> ().flipX = false;
			isForward = true;
		}
		if (!isJumping){
			//WASD movement
			if (Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.D) || Input.GetKeyDown (KeyCode.W)) {
			} else {
				animator.SetBool ("Walk", false);
			}
			if (Input.GetKey (KeyCode.A) && !Input.GetKey (KeyCode.LeftShift)) {
				animator.SetBool ("Walk", true);
				transform.Translate (-speed, 0f, 0f);
				isSliding = false;
			} 
			if (Input.GetKey (KeyCode.D) && !Input.GetKey (KeyCode.LeftShift)) {
				if (bossAlive) {
					if (transform.position.x < bosslimit) {
						animator.SetBool ("Walk", true);
						transform.Translate (speed, 0f, 0f);
						isSliding = false;
					} else {

					}
				} else {
					animator.SetBool ("Walk", true);
					transform.Translate (speed, 0f, 0f);
					isSliding = false;
				}
			}
			if (Input.GetKey (KeyCode.W) && transform.position.y < upperLimit && !Input.GetKey (KeyCode.LeftShift)) {
				animator.SetBool ("Walk", true);
				transform.Translate (0f, speed, 0f);
				isSliding = false;
			} 
			if (Input.GetKey (KeyCode.S) && transform.position.y > lowerLimit && !Input.GetKey (KeyCode.LeftShift)) {
				animator.SetBool ("Walk", true);
				transform.Translate (0f, -speed, 0f);
				isSliding = false;
			}
			//Jumping
			if (Input.GetKey (KeyCode.Space)) {
				isJumping = true;
				groundHeight = transform.position.y;
				velocity = gravity * 10;
			}
			//starting Sliding
			if (!isSliding) {
				if (Input.GetKey (KeyCode.A) && Input.GetKey (KeyCode.LeftShift)) {
					slideSpeed = speed * 2.5f;
					transform.Translate (-slideSpeed, 0f, 0f);
					isSliding = true;
				} 
				if (Input.GetKey (KeyCode.D) && Input.GetKey (KeyCode.LeftShift)) {
					slideSpeed = speed * 2.5f;
					transform.Translate (slideSpeed, 0f, 0f);
					isSliding = true;
				}
				if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.LeftShift)) {
					slideSpeed = speed * 2.5f;
					transform.Translate (0f, slideSpeed, 0f);
					isSliding = true;
				}
				if (Input.GetKey (KeyCode.S) && Input.GetKey (KeyCode.LeftShift)) {
					slideSpeed = speed * 2.5f;
					transform.Translate (0f, -slideSpeed, 0f);
					isSliding = true;
				}

			}
			//during Sliding
			if (isSliding) {
				if (Input.GetKey (KeyCode.A) && Input.GetKey (KeyCode.LeftShift)) {
					if (slideSpeed > speed * 0.2f) {
						slideSpeed -= speed * 0.2f;
					}
					transform.Translate (-slideSpeed, 0f, 0f);
				} 
				if (Input.GetKey (KeyCode.D) && Input.GetKey (KeyCode.LeftShift)) {
					if (slideSpeed > speed * 0.2f) {
						slideSpeed -= speed * 0.2f;
					}
					transform.Translate (slideSpeed, 0f, 0f);
				}
				if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.LeftShift) && transform.position.y < upperLimit) {
					if (slideSpeed > speed * 0.2f) {
						slideSpeed -= speed * 0.2f;
					}
					transform.Translate (0f, slideSpeed, 0f);
				}
				if (Input.GetKey (KeyCode.S) && Input.GetKey (KeyCode.LeftShift) && transform.position.y > lowerLimit) {
					if (slideSpeed > speed * 0.2f) {
						slideSpeed -= speed * 0.2f;
					}
					transform.Translate (0f, -slideSpeed, 0f);
				}
			}

		}
		//Controls when in air
		if (isJumping) {
			if (Input.GetKey (KeyCode.A)) {
				transform.Translate (-speed, 0f, 0f);
			} 
			if (Input.GetKey (KeyCode.D)) {
				transform.Translate (speed, 0f, 0f);
			}
			transform.Translate (0f, velocity, 0f);
			velocity -= gravity;
			if (transform.position.y <= groundHeight + gravity) {
				isJumping = false;
			}

		}
		if (isInvincible) {
			if (Time.time - timeInvincible > 1f) {
				isInvincible = false;
			}
		}

	}

	void OnTriggerEnter2D(Collider2D otherCollider){
		if (otherCollider.tag == "boss") {
			Instantiate (ouchsound, transform.position, Quaternion.identity);
			health -= 50;
			isInvincible = true;
			timeInvincible = Time.time;
			if (health <= 0) {
				SceneManager.LoadScene (0);
				Destroy (gameObject);
			}
		}
		else if ((otherCollider.tag == "Enemy" || otherCollider.tag == "Ebullet") && !isInvincible && gameObject.GetComponent<playerPos>().pos == otherCollider.GetComponent<lanePos> ().pos) {
			Instantiate (ouchsound, transform.position, Quaternion.identity);
			health -= otherCollider.GetComponent<enemyDealt> ().damage;
			isInvincible = true;
			timeInvincible = Time.time;
			if (health <= 0) {
				SceneManager.LoadScene (0);
				Destroy (gameObject);
			}
		}
		else if (otherCollider.tag == "hp") {
			health += 10;
			Destroy (otherCollider.gameObject);
		}
	}
}
