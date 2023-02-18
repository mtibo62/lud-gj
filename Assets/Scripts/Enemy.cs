using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyPathing path;

    private float speed = 5.0f;

    private EnemyState state = EnemyState.None;

    private int currentDestination;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (state == EnemyState.Moving)
        {
            Move();
        }
        else if(state == EnemyState.Attacking)
        {
            Attack();
        }
        
    }

    private void Move()
    {
        if(currentDestination == path.pathNodes.Count - 1 && transform.position == path.pathNodes[currentDestination].position)
        {
            state = EnemyState.Waiting;
        }
        else if(currentDestination <= path.pathNodes.Count - 1 && transform.position == path.pathNodes[currentDestination].position)
        {
            
            currentDestination++;
        }

        var step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, path.pathNodes[currentDestination].position, step);

        
    }

    private void Attack()
    {

    }

    public void Init(EnemyPathing setPath)
    {
        path = setPath;

        currentDestination = 0;

        state = EnemyState.Moving;
    }

    private void SetNode(Transform newtarget)
    {
       
    }

    public enum EnemyState
    {
        None,
        Moving, 
        Waiting,
        Attacking,

    }
}
