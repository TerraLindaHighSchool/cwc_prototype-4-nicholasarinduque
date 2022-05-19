using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalPoint;
    private float powerupStrength = 15.0f;
    public float speed = 5.0f;
    public bool hasPowerup = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
        void Update()
        {
            float forwardInput = Input.GetAxis("Vertical");

            playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed);
        }
    
    private void OnTriggerEnter(Collider other)
    {	
		if(other.CompareTag("powerup"))
		{
				hasPowerup = true;
				Destroy(other.gameObject);
		}
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
    }
    private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.CompareTag("Enemy") && hasPowerup)
		{
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.postion;

            enemyRigidbody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Inpules);
		    Debug.Log("Collided with: " + collison.gameObject.name + " with powerup set to " + hasPowerup);
		}
	}
}