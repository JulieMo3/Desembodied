using UnityEngine;
using UnityEngine.UI;
public class InteractableObjects : MonoBehaviour
{
    public float radius = 3f; // how close to interact
    
    public GameObject instrcution;
    bool isFocused = false;
    bool hasInteracted = false;
    Transform player;
    private void Start()
    {
        instrcution.gameObject.SetActive(false);
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E) && !hasInteracted && player!=null) {
            //Check distance between this object and the player
            float distance = Vector3.Distance(player.position, transform.position);
            //interaction possible
            if(distance <= radius)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }

    public virtual void Interact()
    {
        //overwritten methode depends on the object or enemy
        Debug.Log("interactive with " + transform.name);
    }
    private void OnDrawGizmosSelected()
    {
       /* if(transform == null)
        {
            interactableTransform=transform;
        }*/
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if(other.gameObject.tag == "Player")

        {
            Debug.Log("Yes player Enter");
            instrcution.gameObject.SetActive(true);
            isFocused = true;
            player = other.gameObject.transform;
            hasInteracted = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Yes player Out");
        instrcution.gameObject.SetActive(false);
        isFocused = false;
        player = null;
        hasInteracted = false;
    }

   /* public void OnFocused( Transform playerTransform)
    {
        isFocused = true;
        player = playerTransform;
        hasInteracted = false;
    }*/

   /* public void OnDefocused()
    {
        isFocused = false;
        player = null;
        hasInteracted = false;
    }*/
}
