using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreList : MonoBehaviour {


    public List<int> scoreList = new List<int>();
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void add(int x)
    {
        scoreList.Add(x);
        sort();
    }
    public void sort()
    {
        List<int> temp = new List<int>();
        temp = scoreList;
        scoreList.Clear();

        temp.Sort();
        int highest=0;
        foreach(int x in temp)
        {
            if(x > highest)
            {
               highest = x;
            }
        }
        scoreList = temp;
    }
}
