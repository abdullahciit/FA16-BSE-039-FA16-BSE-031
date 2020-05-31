using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    Vector3 playerPos;
    public float speed;
    public float damageToPlayer;
    public AudioSource audioo;

    private void Start() {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        Destroy(gameObject, 3f);
        audioo = GetComponent<AudioSource>();
    }

    private void Update() {
        transform.position = Vector3.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.tag == "Player") {
            collision.gameObject.GetComponent<HealthManager>().ApplyDamage(damageToPlayer);
            audioo.Play();
            StartCoroutine("Off");
        }
    }

    IEnumerator Off() {
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}