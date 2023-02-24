using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ADDHP : MonoBehaviour
{
    public Slider hpSlider;
    public Slider pb;
    private float _pressTime;
    private bool down = false;
    private bool done = false;
    public EventTrigger eventTrigger;

    private void Start()
    {
        gameObject.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f;
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener((data) =>
        {
            _pressTime = 0;
            down = true;
            pb.value = 0;
        });
        eventTrigger.triggers.Add(entry);
        entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerUp;
        entry.callback.AddListener((data) =>
        {
            done = false;
            down = false;
            StopCoroutine("AddHP");
            _pressTime = 0;
            pb.gameObject.SetActive(false);
        });
        eventTrigger.triggers.Add(entry);
    }


    private void Update()
    {
        if (down)
        {
            _pressTime += Time.deltaTime;
            if (_pressTime > 0.2f)
            {
                if (!done)
                {
                    pb.gameObject.SetActive(true);
                    StartCoroutine("AddHP");
                    done = true;
                }

                pb.value += Time.deltaTime;
                if (pb.value == pb.maxValue)
                {
                    pb.value = 0;
                }
            }
        }
    }

    IEnumerator AddHP()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            hpSlider.value += 10;
            print(hpSlider.value);
        }
    }
}