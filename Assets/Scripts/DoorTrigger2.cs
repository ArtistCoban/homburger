using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTrigger2 : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    private bool isLoading = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isLoading && other.CompareTag("Player"))
        {
            PlayerInventory inv = other.GetComponent<PlayerInventory>();
            if (inv != null && inv.etAlindi)
            {
                isLoading = true;
                LoadNextLevel();
            }
        }
    }
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
