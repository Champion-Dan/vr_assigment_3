using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public int maxDamage = 100;
    private int currentDamage = 0;
    private bool gameEnded = false;

    public void TakeDamage(int damage)
    {
        if (gameEnded) return;

        currentDamage += damage;
        if (currentDamage >= maxDamage)
        {
            EndGame("Game Over! You took too much damage!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameEnded) return;

        if (other.CompareTag("EnemyHitBox"))
        {
            EndGame("Game Over! You were caught by an enemy!");
        }

        if (other.CompareTag("EndGoal"))
        {
            EndGame("Congratulations! You've reached the end goal!");
        }
    }

    private void EndGame(string message)
    {
        if (gameEnded) return;

        gameEnded = true;
        StartCoroutine(EndGameCoroutine(message));
    }

    private IEnumerator EndGameCoroutine(string message)
    {
        Debug.Log(message);
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("startScreen");
    }
}
