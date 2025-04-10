using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogo : MonoBehaviour
{
    public TextAsset dialog;
    public Text txt;
    public float cooldown;

    public Animator anim;
    private int selected;
    private string str;


    private void Start()
    {
        anim.GetComponent<Animator>();
    }

    public void showDialog()
    {
        anim.SetTrigger("open");
        selected = 0;
        str = dialog.text.Split('\n')[selected];
        loadLetters();
    }

    public void loadLetters()
    {
        txt.text = "";
        char[] chars = str.ToCharArray();
        for(int i = 0; i < chars.Length; i++)
        {
            StartCoroutine(getLetter(chars[i],i));
        }
    }

    public void nextDialog()
    {
        if (selected +1 >= dialog.text.Split('\n').Length )
        {
            endDilog();
        }
        else
        {
            selected++;
            str = dialog.text.Split('\n')[selected];
            loadLetters();
        }
    }

    public void endDilog()
    {
        anim.SetTrigger("close");
        str = "";
        txt.text = "";
    }
    IEnumerator getLetter(char l, int x)
    {
        yield return new WaitForSeconds(cooldown *x);
        txt.text += l.ToString();
    }
}
