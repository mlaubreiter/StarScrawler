using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingScript : MonoBehaviour
{
    public Vector2 speed = new Vector2(2, 2);
    public Vector3 direction = new Vector3(-1, 0, 0);
    public bool isLinkedToCamera = false;
    public bool isLooping = false;
    private List<SpriteRenderer> backgroundPart;

    private void Start()
    {
        if (isLooping)
        {
            backgroundPart = new List<SpriteRenderer>();
           
            for(int i = 0; i< transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                SpriteRenderer r = child.GetComponent<SpriteRenderer>();

                if(r!= null)
                {
                    backgroundPart.Add(r);
                }
            }

            backgroundPart = backgroundPart.OrderBy( t => t.transform.position.x).ToList();
            
        }
    }

    void Update()
    {
        Vector3 movement = new Vector3(speed.x * direction.x, speed.y * direction.y, 0);

        movement *= Time.deltaTime;
        transform.Translate(movement);

        if (isLinkedToCamera)
        {
            Camera.main.transform.Translate(movement);
        }

        if (isLooping)
        {
            SpriteRenderer firstChild = backgroundPart.FirstOrDefault();

            if (firstChild != null)
            {
                if (firstChild.transform.position.x < Camera.main.transform.position.x)
                {
                    if (firstChild.IsVisibleFrom(Camera.main) == false)
                    {
                        SpriteRenderer lastChild = backgroundPart.LastOrDefault();

                        Vector3 lastPosition = lastChild.transform.position;
                        Vector3 lastSize = (lastChild.bounds.max - lastChild.bounds.min);

                        if(gameObject.name == "BackgroundSpace")
                        {
                            firstChild.transform.position = new Vector3(lastPosition.x + lastSize.x, firstChild.transform.position.y, firstChild.transform.position.z);
                        }
                        if(gameObject.name == "Background" || gameObject.name == "Middleground")
                        {
                            firstChild.transform.position = new Vector3(lastPosition.x + Camera.main.aspect * Camera.main.orthographicSize * 1.3f, firstChild.transform.position.y, firstChild.transform.position.z);
                            firstChild.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
                        }


                        backgroundPart.Remove(firstChild);
                        backgroundPart.Add(firstChild);
                    }
                }
            }
        }
    }
}
