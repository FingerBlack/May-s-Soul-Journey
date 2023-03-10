using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBehavior : MonoBehaviour
{

    public GameObject resourcePrefab;
    public GameObject root;
    public float spawnRange = 10f;
    public float spawnGap;
    public int numPerSpawn = 10;
    public int minBlockPerSide = 10;
    public int blockSizeIncreaseRate = 2;


    private float lowBound ;
    private float highBound ;
    private float resourceBlockLength = 0;
    public int level;
    public List<int> nodeLevels=new List<int>{20,30,50,100,200};
    public List<int> numberLevels=new List<int>{ 10, 10, 10,10,10,10};
    public List<int> sizeLevels=new List<int>{ 2, 2, 2,2,3,3};
    public List<int> rangeLevels=new List<int>{ 1, 4, 5,6,7,8};
    public List<int> rangeSizeLevels=new List<int>{ 2, 3, 4,6,8,9};
    public List<int> resourceLimit=new List<int>{ 1000, 5000, 8000,20000,30000,60000};
    public float TimePeirod;
    public float TimeCount;
    public int ResourceTotal;
    //public float TimeCount;
    // Start is called before the first frame update
    void Start()
    {
        nodeLevels=new List<int>{20,30,50,100,200};
        numberLevels=new List<int>{ 10, 13, 15,17,19,20};
        sizeLevels=new List<int>{ 2, 2, 2,2,2,2};
        rangeLevels=new List<int>{ 2, 4, 5,6,7,8};
        rangeSizeLevels=new List<int>{ 2, 3, 4,6,8,9};
        resourceLimit=new List<int>{ 1000, 5000, 8000,20000,30000,60000}; 
        spawnGap = 2f;

        TimePeirod=10f;
        TimeCount=10f;
        resourceBlockLength = resourcePrefab.transform.localScale.x;
        level=0;
    }

    // Update is called once per frame
    void Update()
    {   
        if(!GameObject.Find("OverAll").GetComponent<Overall>().ifstart){
            return;
        }
        ResourceTotal=GameObject.Find("Resources").transform.childCount;
        TimeCount+=Time.deltaTime;
        for(int i=0;i<nodeLevels.Count ;i++){
            
            if(GameObject.Find("Roots").GetComponent<RootGrowup>().Total>nodeLevels[i]){
                level=i;
            }
        }
        
        
        lowBound=rangeLevels[level];
        highBound=lowBound+rangeSizeLevels[level];
        if (GameObject.Find("Resources").transform.childCount<resourceLimit[level]&&TimeCount>TimePeirod)
        {
            // spawn n obj per hollow
            TimeCount=0f;
            //GameObject.Find("Roots").GetComponent<RootGrowup>().resourcesCount+=20;
            numPerSpawn=numberLevels[level];
            minBlockPerSide=2*sizeLevels[level];
            int n=numPerSpawn;
            while (n > 0)
            {
                float x = 0;
                float y = 0;
                //float dist = 0;

                // check if in hollow
                float angle=Random.Range(0f,360f);
                x=Random.Range(lowBound,highBound)*Mathf.Sin(angle);
                y=Random.Range(lowBound,highBound)*Mathf.Cos(angle);
                // while (dist <= lowBound || dist >= highBound)
                // {
                //     x = Random.Range((highBound + spawnGap) * -1, highBound + spawnGap);
                //     y = Random.Range((highBound + spawnGap) * -1, highBound + spawnGap);
                //     dist = Mathf.Sqrt(x * x + y * y);
                // }

                //spawn resourse
                //GameObject Resource = GameObject.Find("/Resource");
                int totalnumber= minBlockPerSide*minBlockPerSide;
                while(totalnumber>0){
                    float angle2=Random.Range(0f,2*Mathf.PI);
                    GameObject obj = Instantiate(resourcePrefab, root.transform.position + new Vector3(x+Random.Range(0,2*resourceBlockLength)*Mathf.Sin(angle2),y+Random.Range(0,2*resourceBlockLength)*Mathf.Cos(angle2), 0), Quaternion.identity,GameObject.Find("/Resources").transform) as GameObject;
                    totalnumber-=1;
                }
                // for(int i = 0; i < minBlockPerSide; i++)
                // {
                //     for (int j = 0; j < minBlockPerSide; j++)
                //     {
                //         GameObject obj = Instantiate(resourcePrefab, root.transform.position + new Vector3(x+i* resourceBlockLength/2f, y+j* resourceBlockLength/2f, 0), Quaternion.identity,GameObject.Find("/Resources").transform) as GameObject;
                    
                //     }
                // }
                //GameObject obj = Instantiate(resorsePrefeb, roots.transform.position + new Vector3(x, y, 0), Quaternion.identity) as GameObject;


                //Debug.Log("spawned at: " + x + " " + y);
                n--;
            }

           
            // enlarge hollow
            
            //level+=1;
            //minBlockPerSide=numberLevels[level]*3;


        }
    }
}