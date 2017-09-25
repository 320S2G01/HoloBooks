using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding.Serialization.JsonFx;

public class Book : MonoBehaviour {
    //link to BookTable in Azure easytables
    public string _WebsiteURL = "http://holobooks.azurewebsites.net/tables/books?zumo-api-version=2.0.0";
    public UnityEngine.GameObject[] books;
    public GameObject myPrefab;
    // Use this for initialization
    void Start () {
        //Reguest.GET makes a JSON string
        string jsonResponse = Request.GET(_WebsiteURL);
        //Just in case something went wrong with the request we check the reponse and exit if there is no response.
        if (string.IsNullOrEmpty(jsonResponse)) { return; }
        //creates an array of the table in C#
        BookDetails[] Details = JsonReader.Deserialize<BookDetails[]>(jsonResponse);
        //creates a new book
        var newBook = (GameObject)Instantiate(myPrefab);
        //sets the text for title to the title in the table
        newBook.transform.Find("Title").GetComponent<TextMesh>().text = Details[0].Title;
        //sets the text for the author to the author in the table
        newBook.transform.Find("Author").GetComponent<TextMesh>().text = Details[0].Author;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
