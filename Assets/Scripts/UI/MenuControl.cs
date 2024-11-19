using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    [SerializeField] private List<Transform> Items;
    [SerializeField] private GameObject GameOverUI;

    private void Start()
    {
        for (int i = 0; i <  Items.Count; i++)
        {
            Items[i].localScale = Vector3.zero;
        }

        StartCoroutine(Menu());
    }

    IEnumerator Menu()
    {
        for (int i = 0; i < Items.Count; i++)
        {
            yield return new WaitForSeconds(.15f);
            Items[i].DOScale(1.5f, 0.25f);
            yield return new WaitForSeconds(.15f);
            Items[i].DOScale(1f, 0.25f);
        }
        
    }

    public void ShowGameOver()
    {
       // GameOverUI.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
    public void menuGame()
    {
        SceneManager.LoadScene("InicioGame");
    }
}
