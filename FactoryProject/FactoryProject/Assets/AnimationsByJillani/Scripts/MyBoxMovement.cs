using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBoxMovement : MonoBehaviour
{
    public static MyBoxMovement instance;
    public GameObject endPoint;
    public Animator endPointRobotAnim;
    public Material simpleTxture;
    [HideInInspector]
     public GameObject currentObj;

 
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
       StartCoroutine( MoveBoxes());
        
    }
    public IEnumerator MoveBoxes()
    {

        yield return new WaitForSeconds(0.5f);

        Vector3 pos = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
        LeanTween.move(gameObject, pos, 1f);

       yield return new WaitForSeconds(0.5f);
        // StartCoroutine(MoveBoxes());
       // Invoke("Start",1);

    }

  
    public IEnumerator DisableTheBox()
    {
        yield return new WaitForSeconds(1f);
        if(currentObj !=null)
        {
           currentObj.transform.position = endPoint.transform.position;
            currentObj.GetComponent<MeshRenderer>().material = simpleTxture;

            currentObj.SetActive(false);
            endPointRobotAnim.SetTrigger("StartAnim");
            StartCoroutine(EnableGameObj());

        }
    }


    public IEnumerator EnableGameObj()
    {
        yield return new WaitForSeconds(3f);

        if (currentObj != null)
        {
            currentObj.SetActive(true);

        }
        StartCoroutine(MoveBoxes());
    }
    }
