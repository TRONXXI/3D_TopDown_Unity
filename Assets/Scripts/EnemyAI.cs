using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is used for enemy to move to the adjacent tile of player

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 2f;
    private Transform player;
    public Animator animator;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // For Finding player using tags
        StartCoroutine(FollowPlayer());
    }

    IEnumerator FollowPlayer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f); // This makes enemy to move 1 unit per second
            MoveTowardsPlayer();
        }
    }

    void MoveTowardsPlayer()
    {
        // For moving towards player we have to take both x and y distance between enemy an player
        float distanceX = Mathf.Abs(transform.position.x - player.position.x);
        float distanceZ = Mathf.Abs(transform.position.z - player.position.z);

        // Stop moving if enemy is 1 unity far from player
        if (distanceX <= 1f && distanceZ <= 1f)
        { 
            animator.SetFloat("Speed", 0f);//animation idle
            return;
        }

        // Give direction difference between player and enemy so enemy can move towards player
        Vector3 direction = (player.position - transform.position).normalized;
        direction = new Vector3(Mathf.Round(direction.x), 0, Mathf.Round(direction.z));//This is used so enemy moves exactly 1 unit to the player

        Vector3 targetPos = transform.position + direction; //Gives direction and next position to move

        //This is to make enemy walk only on tile and not fall, raycast starts from targetpos which is enemy's next position.
        if (!Physics.Raycast(targetPos + Vector3.up, Vector3.down, 1f)) return;
        animator.SetFloat("Speed", 1f);//animation walk
        StartCoroutine(MoveToPosition(targetPos));//coroutine for movetoposition
    }

    //This help to slowly move enemy to player and not snap quickly
    IEnumerator MoveToPosition(Vector3 target)
    {
        while (Vector3.Distance(transform.position, target) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = target;
    }

   
}
