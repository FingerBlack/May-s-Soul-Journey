using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NextPage5 : MonoBehaviour
{
    // Start is called before the first frame update
    public int debug;
    //public Button StarGameButton;
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnClick(){
        GameObject.Find("PageControl").GetComponent<PageControl>().Page5.SetActive(false);
        GameObject.Find("PageControl").GetComponent<PageControl>().HelpPage.SetActive(true);
    }
}
