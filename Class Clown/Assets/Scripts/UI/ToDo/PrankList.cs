using System.Collections;
using System.IO;
using System.Linq;
using System.Collections.Generic;
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
    void Start()
    {
        char[] delims = new[] { '\r', '\n' };
        string allescapes = escapefile.text;
        string allpranks = pranksfile.text;
        pranks = allpranks.Split(delims,System.StringSplitOptions.RemoveEmptyEntries);
        escapes = allescapes.Split(delims, System.StringSplitOptions.RemoveEmptyEntries);

        int numpranks = pranks.Length;
        int[] used = new int [PrankText.Length];
        for(int i = 0; i < PrankText.Length; i++)
        {
            int index = Random.Range(0, numpranks);
            while (used.Contains<int>(index))
            {
                index = Random.Range(0, numpranks);
            }
            used[i] = index;
            PrankText[i].text = pranks[index];
        }

    }
}
