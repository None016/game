using TMPro;
using UnityEngine;

public class thoughts : MonoBehaviour
{
    public GameObject suicide;
    public GameObject notNow;
    public GameObject notNow2;

    public float time_text1;

    public void getSuicide()
    {
        hideAllText();
        suicide.SetActive(true);
        Invoke("hideSuicide", time_text1);
    }

    private void hideSuicide()
    {
        suicide.SetActive(false);
    }

    public void getnotNow1()
    {
        hideAllText();
        notNow.SetActive(true);
        Invoke("hidenotNow1", time_text1);
    }

    private void hidenotNow1()
    {
        notNow.SetActive(false);
        getnotNow2();
    }

    private void getnotNow2()
    {
        hideAllText();
        notNow2.SetActive(true);
        Invoke("hidenotNow2", time_text1);
    }

    private void hidenotNow2()
    {
        notNow2.SetActive(false);
    }



    private void hideAllText()
    {
        suicide.SetActive(false);
        notNow.SetActive(false);
        notNow2.SetActive(false);
    }
}
