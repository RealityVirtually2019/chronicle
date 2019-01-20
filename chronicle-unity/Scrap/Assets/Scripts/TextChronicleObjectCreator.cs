using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextChronicleObjectCreator : MonoBehaviour {

    public GameObject ChronicleObjectTemplate;
    public int maxLineLength = 8;

    public ChronicleObject Create(string text)
    {
        GameObject newObj = (GameObject)Instantiate(ChronicleObjectTemplate);
        TextMesh textMesh = newObj.GetComponentInChildren<TextMesh>();
        textMesh.text = ResolveTextSize(text, maxLineLength);
        return newObj.GetComponent<ChronicleObject>();
    }

	// Use this for initialization
	//void Start () {
 //       Create();
	//}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Wrap text by line height
    private string ResolveTextSize(string input, int lineLength)
    {

        // Split string by char " "         
        string[] words = input.Split(" "[0]);

        // Prepare result
        string result = "";

        // Temp line string
        string line = "";

        // for each all words        
        foreach (string s in words)
        {
            // Append current word into line
            string temp = line + " " + s;

            // If line length is bigger than lineLength
            if (temp.Length > lineLength)
            {

                // Append current line into result
                result += line + "\n";
                // Remain word append into new line
                line = s;
            }
            // Append current word into current line
            else
            {
                line = temp;
            }
        }

        // Append last line into result        
        result += line;

        // Remove first " " char
        return result.Substring(1, result.Length - 1);
    }
}
