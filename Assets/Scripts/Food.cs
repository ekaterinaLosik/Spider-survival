using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
     AudioSource eatSound;
    Collider _collider;
    Renderer rend;
    

    void Start()
    {
        rend = GetComponent<Renderer>();
        _collider = GetComponent<Collider>();
      eatSound = GameObject.Find("eatSound").GetComponent<AudioSource>();

    }
    private void OnTriggerStay(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                Survival.health += 10f;
                if (Survival.health > Survival.maxHealth)
                    Survival.health = Survival.maxHealth;

                rend.enabled = false;
                _collider.enabled = false;
                eatSound.Play();
                StartCoroutine(WaitAndRespawn());
            }
        }
    }
    IEnumerator WaitAndRespawn()
    {
        yield return new WaitForSeconds(60);
        rend.enabled = true;
        _collider.enabled = true;

    }
}
