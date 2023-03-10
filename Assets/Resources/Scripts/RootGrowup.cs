using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootGrowup : MonoBehaviour
{
    // Start is called before the first frame update
    public int Basic=100;
    public int originalToal=100;
    public int Total=0;
    public int resourcesCount=0;
    public int ElvesCount=0;
    public float originalLightScale;
    public Vector3 originalElvesScale;
    public Vector3 originalScale;
    public int  resourceslimit;
    //public int Count=0;
    public float Timepeorid=2f;
    public float TimeCount=0f;
    public float HP=255f;
    void Start()
    {
        Basic=10;
        Total=6;
        HP=255f;
        Timepeorid=2f;
        originalToal=10;
        GameObject elves=Resources.Load("Prefabs/Elf") as GameObject;
        originalElvesScale=elves.transform.localScale;
        originalScale=transform.localScale;
        originalLightScale=GameObject.Find("Roots/Light 2D").GetComponent<UnityEngine.Rendering.Universal.Light2D>().pointLightOuterRadius;
        resourcesCount=100;
        Timepeorid=2f;

    }

    // Update is called once per frame
    void Update()
    {    

        //TimeCount=0;
        //
 
         if(!GameObject.Find("OverAll").GetComponent<Overall>().ifstart){
            return;
        }
        TimeCount+=Time.deltaTime;
        if(TimeCount>Timepeorid){
            TimeCount=0;
            resourcesCount++;
        }
        float scale=(Basic+Total*0.2f)/originalToal;
        foreach (Transform cld in GameObject.Find("Roots/Elves").transform)
        {
            if(cld.gameObject.TryGetComponent<Elves>(out Elves a)){
                cld.transform.localScale=new Vector3(originalElvesScale.x/scale,originalElvesScale.y/scale,originalElvesScale.z);
            }
        }
        transform.localScale=new Vector3(originalScale.x*scale,originalScale.y*scale,originalScale.z);
        GameObject.Find("Roots/Light 2D").GetComponent<UnityEngine.Rendering.Universal.Light2D>().pointLightOuterRadius=originalLightScale*scale;
    }
}
