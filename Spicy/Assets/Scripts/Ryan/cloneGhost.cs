using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class cloneGhost : MonoBehaviour
{
    private GameObject ghost;
    private GameObject[] ghostList;
    private IEnumerator stress;
    //private IEnumerator stressChecker;
    float waitTime = 0.1f;
    //private int count;

    int framerate;
    int ghostCount = 5;
    Transform ithTarget;

    // Start is called before the first frame update
    void Start()
    {
        ghost = GameObject.Find("TestGhost");
        for(int i = 0; i < 5; i++)
        {
            Instantiate(ghost, new Vector2(0f, 1f), Quaternion.identity);
        }
        ghostList = GameObject.FindGameObjectsWithTag("Enemy");
        stress = MakeGhost();
        StartCoroutine(stress);
        //stressChecker = checkGhosts();
        //StartCoroutine(stressChecker);
    }

    // Update is called once per frame
    void Update()
    {
        framerate = (int)(1f / Time.smoothDeltaTime);
        //Conditional prints log at around 2800-2900 ghosts instantiated
        if(framerate <= 10)
        {
            Debug.Log("FPS Unplayable threshold found at count: " + ghostCount);
            //Debug.Log("FPS: " + framerate);
        }


        //Tried this error condition with thousands of ghosts (5000+). Did not print the else condition ever, even
        //though there were clearly path destinations that were not equal when inspecting scene view in runtime.
        for (int i = 0; i < 5; i++)
        {
            ithTarget = ghostList[i].GetComponent<AIDestinationSetter>().target;

            if (ithTarget.position == ghostList[0].GetComponent<AIDestinationSetter>().target.position)
            {
                //Debug.Log(ithTarget.position);
            }
            else
            {
                Debug.Log("Conflicting paths found.");
            }
            
        }
        
    }

    //This crashes Unity
    /*IEnumerator checkGhosts()
    {
        count = 1;
        while (true)
        {
            
            if(count % 200 == 0)
            {
                count = 1;
            } else
            {
                count++;
            }
        }
        
    }*/

    
    IEnumerator MakeGhost()
    {
        while (true)
        {
            Instantiate(ghost, new Vector2(0f, 1f), Quaternion.identity);
            ghostCount++;
            if (ghostCount % 100 == 0)
            {
                Debug.Log(ghostCount);
            }
            yield return new WaitForSeconds(waitTime);
        }
        
    }
    
}
