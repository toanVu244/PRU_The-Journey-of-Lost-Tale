using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using TMPro;
using UnityEngine;

public class RoomTranfer : MonoBehaviour
{
    public Vector3 cameraChange;
    public Vector3 playerChange;
    private CameraFollow cam;
/*    public bool needText;*/
    public string placeName;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<CameraFollow>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cam.minPosition += cameraChange;
            cam.maxPosition += cameraChange;
            collision.transform.position += playerChange;
/*            if (needText)
            {
                StartCoroutine(placeNamCo());
            }*/
        }
    }

    /*public IEnumerator placeNamCo()
    {
        text.SetActive(true);
        placeText.text = placeName;
        yield return new WaitForSeconds(2f);
        text.SetActive(false);
    }*/
}
