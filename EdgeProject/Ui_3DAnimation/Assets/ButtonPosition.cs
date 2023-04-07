using UnityEngine;
using UnityEngine.UI;

public class ButtonPosition : MonoBehaviour
{
    public GameObject preesedstate;
    public void OnButtonPressed()
    {
        Vector3 buttonPosition = transform.position;
        Debug.Log("Button position: " + buttonPosition);
        preesedstate.transform.position = new Vector3(buttonPosition.x+124,buttonPosition.y,buttonPosition.z);
    }
}
