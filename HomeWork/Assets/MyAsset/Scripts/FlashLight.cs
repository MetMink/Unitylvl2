using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class FlashLight : GameBase
{
    [SerializeField] private KeyCode control = KeyCode.F;
    [SerializeField] private float timeout = 120;
    [SerializeField] private Light _light;


    [SerializeField] private Color maxColor = Color.white;

    private float curTime = 0;
    private float curReloadTime = 5;

    
    void Start()
    {
        _light = GetComponent<Light>();
        _light.intensity = 8;
    }

    private void ActiveFlashlight(bool value)
    {
        _light.enabled = value;
    }
    public float BatteryCount { get; set; }
    void Update()
    {
        if (Input.GetKeyDown(control) && !_light.enabled)
        {
            ActiveFlashlight(true);
        }
        else if(Input.GetKeyDown(control) && _light.enabled)
        {
            ActiveFlashlight(false);
        }
        if (_light.enabled)
        {
            curTime += Time.deltaTime;
            if(curTime > timeout)
            {
                ActiveFlashlight(false);
            }
            else if(curTime!=0)
            {

            }
            BatteryCount = 100 - (curTime / timeout) * 100;
            if (BatteryCount < 90)
            {
                _light.intensity = 7;
            }
            if (BatteryCount < 80)
            {
                _light.intensity = 6;
            }
            if (BatteryCount < 70)
            {
                _light.intensity = 5;
            }
            if (BatteryCount < 60)
            {
                _light.intensity = 4;
            }
            if (BatteryCount < 50)
            {
                _light.intensity = 3;
            }
            if (BatteryCount < 40)
            {
                _light.intensity = 2;
            }
            if (BatteryCount < 30)
            {
                _light.intensity = 1;
            }
        }
        if (curTime >= timeout && _light.enabled == false)
        {
            curReloadTime -= Time.deltaTime;
            if(curReloadTime <= 0)
            {
                curReloadTime = 5;
                curTime = 0;
            }
        }
    }
}
