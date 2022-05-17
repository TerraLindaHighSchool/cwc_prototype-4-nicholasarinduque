using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets
{
    public class PlayerController : MonoBehaviour
    {
        private Rigidbody playerRb;
        private GameObject focalPoint;
        public float speed = 5.0f;
        public bool hasPowerup;

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
            hasPowerup = true;
            Destroy(other.gameObject);
        }
    }
}