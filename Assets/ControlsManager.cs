using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlsManager : MonoBehaviour
{

    [SerializeField] GameObject _effects;
    public void MainMenu()
    {
        SceneManager.LoadScene(1);
    }

    private void Start()
    {
        StartCoroutine(BlinkEffect());
    }

    private void Update()
    {
        
    }

    IEnumerator  BlinkEffect()
    {
        for (int i = 0; i < 10000; i++)
        {
            _effects.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            _effects.SetActive(true);
            yield return new WaitForSeconds(0.5f);

            i++;
        }
       

        yield return null;
    }
}
