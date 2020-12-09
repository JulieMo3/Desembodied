using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    public GameObject textDisplay;
    public int durationPeriode = 3;
    public bool takingAway = false;
    public ParticleSystem fogFirst;
    public ParticleSystem fogSecond;
    public ParticleSystem fogThird;
    public ParticleSystem fogFourth;
    public ParticleSystem fogFith;
    public Material skyDay;
    public Material skyNight;
    public Material skyAube;
    public Light light;

 
    int fullTime;
    //int maxParticles = 3000;

    [System.Obsolete]
    private void Start()
    {
        fullTime = durationPeriode * 3;
        RenderSettings.skybox = skyDay;
        textDisplay.GetComponent<Text>().text = "00:" + fullTime;
        fogFirst.GetComponent<ParticleSystem>();
        fogSecond.GetComponent<ParticleSystem>();
        fogThird.GetComponent<ParticleSystem>();
        fogFourth.GetComponent<ParticleSystem>();
        fogFith.GetComponent<ParticleSystem>();
        fogFirst.gameObject.SetActive(false);
        fogSecond.gameObject.SetActive(false);
        fogThird.gameObject.SetActive(false);
        fogFourth.gameObject.SetActive(false);
        fogFith.gameObject.SetActive(false);

    }

    private void Update()
    {
        if (takingAway == false && fullTime > 0)
        {
            StartCoroutine(TimerTake());
        }
    }

    IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        fullTime -= 1;
        textDisplay.GetComponent<Text>().text = "00:" + fullTime;
        if(fullTime/ durationPeriode >= 2)
        {
            RenderSettings.skybox = skyDay;
            Debug.Log("jour");
            light.intensity = 1f;
            fogFirst.gameObject.SetActive(false);
            fogSecond.gameObject.SetActive(false);
            fogThird.gameObject.SetActive(false);
            fogFourth.gameObject.SetActive(false);
            fogFith.gameObject.SetActive(false);
        }
        else if(fullTime / durationPeriode >= 1)
        {
            RenderSettings.skybox = skyNight;
            Debug.Log("nuit");
            light.intensity = 0.05f;
            fogFirst.gameObject.SetActive(true);
            fogSecond.gameObject.SetActive(true);
            fogThird.gameObject.SetActive(true);
            fogFourth.gameObject.SetActive(true);
            fogFith.gameObject.SetActive(true);

        }
        else
        {
            RenderSettings.skybox = skyAube;
            light.intensity = 0.2f;
            Debug.Log("aube");
            fogFirst.gameObject.SetActive(false);
            fogSecond.gameObject.SetActive(false);
            fogThird.gameObject.SetActive(false);
            fogFourth.gameObject.SetActive(false);
            fogFith.gameObject.SetActive(false);
        }
        takingAway = false;

    }
}
