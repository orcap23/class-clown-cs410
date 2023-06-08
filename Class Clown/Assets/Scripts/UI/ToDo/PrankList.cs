using System;
using UnityEngine;
using TMPro;
public class PrankList : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text[] PrankText;
    public TextAsset pranksfile;
    public TextAsset escapefile;
    public string[] pranks;
    public string[] escapes;
    public int pranksdone = 0;
    void Start()
    {
        pranksdone = 0;
        char[] delims = new[] { '\r', '\n' };
        string allescapes = escapefile.text;
        string allpranks = pranksfile.text;
        pranks = allpranks.Split(delims,System.StringSplitOptions.RemoveEmptyEntries);
        escapes = allescapes.Split(delims, System.StringSplitOptions.RemoveEmptyEntries);
        Debug.Log(pranks[0]);
        int numpranks = pranks.Length;
        if (numpranks > PrankText.Length)
        {
            string[] used = new string[PrankText.Length];
            for (int i = 0; i < PrankText.Length; i++)
            {
                int index = 0;
                while (Array.Exists(used, element => element == pranks[index]))
                {
                    index = UnityEngine.Random.Range(0, numpranks);
                }
                used[i] = pranks[index];
                PrankText[i].text = pranks[index];
                PrankText[i].color = Color.black;
            }
        }
        else
        {
            int j = 0;
            while (j < numpranks)
            {
                PrankText[j].text = pranks[j];
                PrankText[j].color = Color.black;
                j++;
            }
        }
    }
}
