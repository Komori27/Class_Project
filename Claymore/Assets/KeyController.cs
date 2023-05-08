using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    public GameObject doorToUnlock;
    public GameObject[] objectsToDisable;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (GameObject obj in objectsToDisable)
            {
                obj.SetActive(false);
            }
            doorToUnlock.GetComponent<Door>().Unlock();
            Destroy(gameObject);

            // Disable the Door_Animated game object.
            GameObject.Find("Door").GetComponent<Door>().doorAnimated.SetActive(false);
        }
    }
}
