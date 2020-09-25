using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    Rigidbody _rb;
    public int boxTotal;
    public int boxCount;
    public bool GameControl;

    bool callStart;

    public GameObject Char;
    public GameObject goldPrefab;
    public GameObject panel;
    public GameObject boxPrefab;
    public GameObject Kills;

    public Transform x;

    Vector2 _startPoint;
    Vector2 _endPoint;
    public Vector3 boxTransform;
    public Vector3 charTransform;

    float call;
    // Start is called before the first frame update
    void Start()
    {
        boxTransform = new Vector3(0f, 0.03f, 0f);
        charTransform = new Vector3(0f, 0.505f, 0f);

        boxCount = 1;
        boxTotal = 1;
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        InputMechanics();
    }

    public void InputMechanics()
    {
        if (GameControl == false)
        {
            _rb.velocity = Vector3.zero;
            return;
        }
        //_rb.velocity = Vector3.forward * 2f;

//#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
//#else
//            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
//#endif
        {
            callStart = true;
            _startPoint.x = Input.mousePosition.x;
            _startPoint.y = Input.mousePosition.y;
        }

//#if UNITY_EDITOR
        if (Input.GetMouseButtonUp(0))
//#else
//            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
//#endif
        {
            callStart = false;
        }

        if (callStart == true && GameControl == true)
        {
            _endPoint.x = Input.mousePosition.x;
            _endPoint.y = Input.mousePosition.y;
            call = _startPoint.x - _endPoint.x;
            if (call > 0)
            {
                _rb.velocity =  Vector3.forward *2f;
                transform.position = new Vector3(transform.position.x - 0.02f, transform.position.y,transform.position.z);
            }
            else if (call < 0)
            {
                _rb.velocity = Vector3.forward * 3f;
                transform.position = new Vector3(transform.position.x + 0.02f, transform.position.y, transform.position.z);
            }
        }
        else if (callStart == false && GameControl == true)
        {
            _rb.velocity = Vector3.forward * 3f;
        }

    }
}
