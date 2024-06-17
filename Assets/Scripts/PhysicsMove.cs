using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsMove : MonoBehaviour
{
    [SerializeField] private GameObject nullGrab;
    private GameObject PO;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        NullObjectToMousePos();
        ClickToRaycast();
    }
    void ClickToRaycast()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                //Debug.Log("Raycast is hitting");
                if (hit.collider.gameObject.CompareTag("PuzzleObject"))
                {
                    PO = hit.collider.gameObject;
                    if (PO.GetComponent<PuzzleObject>().GetGrabbale())
                    {
                        
                        PO.transform.parent = nullGrab.transform;
                        PO.transform.localPosition = Vector3.zero;
                        PO.GetComponent<Rigidbody>().useGravity = false;
                    }
                }
            }
        }
        else
        {
            if (PO == null)
            {
                return;
            }
            else
            {
                PO.GetComponent<Rigidbody>().useGravity = true;
                PO.transform.parent = null;
            }
        }
    }
    void NullObjectToMousePos()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        nullGrab.transform.position = new Vector3(pos.x, 3, pos.z);
        //Debug.Log(pos);
    }
}
