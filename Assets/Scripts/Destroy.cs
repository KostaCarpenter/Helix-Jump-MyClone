using TMPro;
using UnityEngine;

public class Destroy : MonoBehaviour
{

    private int score;
    [SerializeField] TMP_Text scoreText;
    private Player player;
    [SerializeField] AudioSource BreakPlatform;


    private void Start()
    {
        player = GetComponent<Player>();        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bonus")
        {
            BreakPlatform.Play();
            Destroy(other.gameObject);
            player.setScore(1);
            
        }
      
        
    }
    private void Update()
    {
        scoreText.text = player.getScore().ToString();

    }

}
