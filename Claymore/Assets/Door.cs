using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] public GameObject doorAnimated;
    [SerializeField] public GameObject placeholderDoor;


    void Start()
    {
        doorAnimated.SetActive(false);
        placeholderDoor.SetActive(true);
    }

    public void Unlock()
    {
        doorAnimated.SetActive(true);
        placeholderDoor.SetActive(false);

    }
}
