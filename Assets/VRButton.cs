using UnityEngine;

public class VRButton : MonoBehaviour
{
    private float deadTime = 1f;
    private bool deadTimeActive = false;

    public UnityEvent onPressed, onReleased;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Button" && !deadTimeActive)
        {
            onPressed.Invoke();
            Debug.Log("I have been pressed");

        }
    }
}
