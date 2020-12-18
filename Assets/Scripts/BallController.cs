using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BallController : MonoBehaviour
{
    public AudioClip Hit;
    public AudioClip Goal;
    private Vector3 startPosition;
    private Rigidbody body;
    private AudioSource audioSource;
    void Start()
    {
        startPosition = transform.position;
        body = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Border") || other.gameObject.CompareTag("Player"))
        {
            audioSource.PlayOneShot(Hit);
        }
        if (other.gameObject.CompareTag("TheGoal1"))
        {
            audioSource.PlayOneShot(Goal);
            body.velocity = Vector3.zero;
            transform.position = startPosition;
            GameManager.instance.IncCounter2();
        }
        if (other.gameObject.CompareTag("TheGoal2"))
        {
            audioSource.PlayOneShot(Goal);
            body.velocity = Vector3.zero;
            transform.position = startPosition;
            GameManager.instance.IncCounter1();
        }
    }
    void OnTriggerExit(Collider other)
    {
        Debug.Log(other.gameObject);
        if (other.CompareTag("Table"))
        {
            transform.position = startPosition;
        }
    }
}
