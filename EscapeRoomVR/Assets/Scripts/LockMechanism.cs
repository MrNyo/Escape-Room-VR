using Tilia.Interactions.Interactables.Interactables;
using UnityEngine;

public class LockMechanism : MonoBehaviour
{
    [SerializeField] private GameObject key;
    private Collider _lockTrigger;

    private void Start()
    {
        _lockTrigger = GetComponent<BoxCollider>();
    }

    /**
     * When the key enters the trigger zone it gets replaced by a static key so it can't be grabbed and
     * a Event gets triggered
     */
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            Instantiate(key, transform.position, Quaternion.Euler(-90,90,0), transform);
            other.gameObject.GetComponent<InteractableFacade>().Ungrab();
            Destroy(other.gameObject);
            _lockTrigger.enabled = false;
            GameEvents.current.KeyEnter();
        }
    }
}