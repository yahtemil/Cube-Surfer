using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBox : MonoBehaviour
{
    PlayerController _playerController;
    GamesManager _gamesManager;

    public bool calcontrol;
    // Start is called before the first frame update
    void Start()
    {
        _gamesManager = FindObjectOfType<GamesManager>();
        _playerController = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AddBox"))
        {
            if (other.gameObject.GetComponent<BoxInfo>().onclick == true)
            {
                return;
            }
            other.GetComponent<BoxInfo>().onclick = true;
            Destroy(other.gameObject);
            _playerController.boxCount += 1;
            BoxCallculation();
        }
        if (other.CompareTag("Gold"))
        {
            if (other.gameObject.GetComponent<BoxInfo>().onclick == true)
            {
                return;
            }
            other.GetComponent<BoxInfo>().onclick = true;
            Destroy(other.gameObject);

            Instantiate(_playerController.goldPrefab, Camera.main.WorldToScreenPoint(transform.position), _playerController.panel.transform.rotation, _playerController.panel.transform);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Barrier"))
        {
            if (other.gameObject.GetComponent<BoxInfo>().onclick == true)
            {
                return;
            }
            other.gameObject.GetComponent<BoxInfo>().onclick = true;
            gameObject.transform.parent = _playerController.Kills.transform;
            if (calcontrol==false)
            {
                _playerController.boxCount -= 1;
            }
            calcontrol = true;
            if (_playerController.boxCount <= 0)
            {
                _playerController.GameControl = false;
                _gamesManager.losepanel.SetActive(true);
            }

            gameObject.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Barrier"))
        {
            calcontrol = false;
        }
    }

    public void BoxCallculation()
    {
        GameObject y = Instantiate(_playerController.boxPrefab, _playerController.gameObject.transform);
        //y.transform.position = _playerController.boxTransform;
    }
}
