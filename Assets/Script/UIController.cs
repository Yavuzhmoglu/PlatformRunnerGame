using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{

   public GameObject[] Characters;
    public PlayerController Player;
    public int[] DistanceList;
    public string[] NameList;
    public Text[] List;
    int temp;
    string tempName;
    
    void Start()
    {
        Characters=GameObject.FindGameObjectsWithTag("Enemy");

   
       
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.gameObject.GetComponent<PlayerController>().Win)
        {
            return;
        }
       
        DistanceList[0] = Player.gameObject.GetComponent<PlayerController>().distance;
        NameList[0]= Player.gameObject.name;
       
        for (int i = 1; i < Characters.Length; i++)
        {
            DistanceList[i] = Characters[i].gameObject.GetComponent<AIController>().distance;
            NameList[i] = Characters[i].gameObject.name;
        }
        for (int i = 0; i < DistanceList.Length - 1; i++)
        {
            for (int j = i; j < DistanceList.Length; j++)
            {

                if (DistanceList[i] > DistanceList[j])
                {
                    temp = DistanceList[j];
                    tempName = NameList[j];

                    DistanceList[j] = DistanceList[i];
                    NameList[j] = NameList[i];

                    DistanceList[i] = temp;
                    NameList[i] = tempName;
                }

            }
            for (int k = 0; k < List.Length; k++)
            {
                List[k].text =(k+1).ToString()+"- "+NameList[k]+" "+DistanceList[k].ToString() ;

            }
           

        }


    }
    public void NextScene(string SceneName)
    {

        SceneManager.LoadScene(SceneName);
    }
}
