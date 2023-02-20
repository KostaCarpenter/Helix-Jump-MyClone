using Assets.Scripts;
using System;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Player : MonoBehaviour
{
    public float BounceSpeed;
    public Rigidbody Rigidbody;
    public Game Game;
    private int Score;
    private const string ScoreKey = "Score";
    [SerializeField] AudioSource ballBounce;
    public ParticleSystem BallDawn;
    public ParticleSystem DestroyPlatform;
    public ParticleSystem Win;

    private void Awake()
    {
        Score = PlayerPrefs.GetInt(ScoreKey, 0);
    }

    public void setScore(int score)
    {
        Score += score;
        PlayerPrefs.SetInt(ScoreKey, Score);
    }

    public int getScore()
    {
        return Score;
    }




    public Platform CurrentPlatform;

    public void Bounce()
    {
        Rigidbody.velocity = new Vector3(0, BounceSpeed, 0);
        ballBounce.Play();
        BallDawn.Play();
        DestroyPlatform.Play();
    }

    public void Die()
    {
        Game.OnPlayerDied();
        Rigidbody.velocity = Vector3.zero;
    }

    public void ReachFinish()
    {
        Game.OnPlayerReachFinish();
        Rigidbody.velocity = Vector3.zero;
        Win.Play();
    }
}
