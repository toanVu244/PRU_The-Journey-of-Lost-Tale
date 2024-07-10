using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MovingBarSystem : MonoBehaviour
{
    public Transform movingBar;         
    public Transform hitZone;           
    public TextMeshProUGUI scoreText;              

    private float score = 0;            

    void Update()
    {
        float sliderValue = GetComponent<Slider>().value;
        float maxX = GetComponent<RectTransform>().rect.width - movingBar.GetComponent<RectTransform>().rect.width;
        float newX = sliderValue * maxX;
        Vector3 newPosition = new Vector3(newX, movingBar.position.y, movingBar.position.z);
        movingBar.position = newPosition;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsInHitZone())
            {
                score++;
                scoreText.text = "Score: " + score;
            }
        }
    }

    bool IsInHitZone()
    {
        Vector3 hitZoneCenter = hitZone.position;
        Vector3 hitZoneSize = hitZone.GetComponent<RectTransform>().rect.size;

        Vector3 barPosition = movingBar.position;
        Vector3 barSize = movingBar.GetComponent<RectTransform>().rect.size;

        if (barPosition.x >= hitZoneCenter.x - hitZoneSize.x / 2 &&
            barPosition.x <= hitZoneCenter.x + hitZoneSize.x / 2 &&
            barPosition.y >= hitZoneCenter.y - hitZoneSize.y / 2 &&
            barPosition.y <= hitZoneCenter.y + hitZoneSize.y / 2)
        {
            return true;
        }
        return false;
    }
}
