using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChange : MonoBehaviour
{
    public SpriteRenderer perso1SR;
    public SpriteRenderer perso2SR;

    public PlayerBehavior scriptBehave1;
    public PlayerBehavior scriptBehave2;

    public FixedJoint2D Anchor1;
    public FixedJoint2D Anchor2;

    public Transform posPlayer1;
    public Transform posPlayer2;
    

    public int chosenPlayer = 0;
    public int lastSoloPlayed = 1;

    public bool HaveToGetTogether = false;
    public bool confirm1 = false;
    public bool confirm2 = false;

    public float chrono = 0f;
    public float timer = 0f;

    public float maxdelay = 2f;
    // Start is called before the first frame update
    void Start()
    {
        chosenPlayer = 0;
        scriptBehave2.enabled = false;

        Anchor2.enabled = false;

        

    }


    // Update is called once per frame
    void Update()
    {

        chrono += Time.deltaTime;
        

        if (Input.GetKeyDown(KeyCode.Tab))
        {

            if (chrono > maxdelay)
            {
                chrono = 0f;


                

            }
            else
            {
                

                chosenPlayer += 1;

                if (chosenPlayer >= 3)
                {
                    chosenPlayer = 0;
                }

                if (chosenPlayer == 0)
                {
                    Debug.Log("Les deux persos sont selectionnés");
                    perso1SR.color = new Color(1f, 1f, 1f, 1f);
                    perso2SR.color = new Color(1f, 1f, 1f, 1f);
                    chrono = 0f;
                    timer = 0f;
                    HaveToGetTogether = true;
                    

                    
                    

                    



                }
                else if (chosenPlayer == 1)
                {
                    Debug.Log("vous controlez le perso  1");
                    Anchor2.enabled = false;

                    perso1SR.color = new Color(1f, 1f, 1f, 1f);
                    perso2SR.color = new Color(0.47f, 0.47f, 0.47f);

                    scriptBehave2.enabled = false;
                    scriptBehave1.enabled = true;

                    chrono = 0f;
                    confirm1 = true;




                }
                else if (chosenPlayer == 2)
                {
                    Debug.Log("Vous controlez le perso 2");
                    Anchor2.enabled = false;

                    perso1SR.color = new Color(0.47f, 0.47f, 0.47f);
                    perso2SR.color = new Color(1f, 1f, 1f, 1F);

                    scriptBehave1.enabled = false;
                    scriptBehave2.enabled = true;

                    chrono = 0; 
                    confirm2 = true;
                }

            }









        }
        if (chrono > maxdelay )
        {
            if (HaveToGetTogether == true && chosenPlayer == 0)
            {


                Debug.Log("vous avez choisis de controler les deux persos ensembles");


                Anchor2.enabled = true;

                Debug.Log("tp de " + lastSoloPlayed);

                HaveToGetTogether = false;


                if (lastSoloPlayed == 1)
                {
                    posPlayer1.transform.position = posPlayer2.position;
                }
                else if (lastSoloPlayed == 2)
                {
                    posPlayer2.transform.position = posPlayer1.position;
                }
            }
            if(confirm1 == true){
                lastSoloPlayed = 1;
                confirm1 = false;
            }
            if(confirm2 == true)
            {
                lastSoloPlayed = 2;
                confirm2 = false;
            }
        }
       

       





        

    }



}
