using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    public int lifePoints = 1;

    public int current_life;

    public bool isDead = false;

    //public int score = 0;

    public Transform startPoint;

    public Transform player;

    //public DeathMenu DM;

    public GameObject Shadow;

    private void Update()
    {
        //float time = Time.time - startTime;

        //Run out of life -> Dies
        if(current_life <= 0)
        {
            isDead = true;
        }

        //Show Death Screen
        if(isDead)
        {
            //Use this line if you are using a Death screen
            //DM.GetComponent<DeathMenu>().ToggleEndMenu(score,time);
            Reset();
        }
    }
    
    void Start()
    {
        player.transform.position = startPoint.transform.position;
        current_life = lifePoints;
    }

    public void Damage()
    {
        current_life--;
    }

    private void Reset()
    {
        //player.position = startPoint;
        current_life = lifePoints;
        player.position = startPoint.transform.position;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        Shadow.GetComponent<Shadow>().Deactivate();
        isDead = false;

        //Destroy bullets
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Enemy Bullet");
        if(bullets != null)
        {
            foreach(GameObject bullet in bullets)
            {
                Destroy(bullet);
            }
        }
    }
}