using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Facebook.Unity;
using System;

public class GameControlScript : MonoBehaviour {

    public GameObject timeIsUp, timeLeft, score, buttonL, buttonR, plasticTrash, paperTrash, glassTrash, organicTrash, indiffTrash, endPanel, messagePanel, restartPanel;
    private bool closed;
    int randomText;
    public Text testo, scoreNumber;
    string[]  plasticTexts, paperTexts, glassTexts, organicTexts, indiffTexts, plasticLinks,paperLinks,glassLinks,organicLinks,indiffLinks;
    String link;
    //public Text CoinText;
    private int moneta = 0;

    // Use this for initialization
    void Start () {
        plasticTexts = new string[] { "Con 10 flaconi di plastica si produce una sedia, con 800 lattine si produce una bicicletta.",
         "La plastica non è inquinante in quanto tale. Lo diventa quando viene abbandonata nella natura o nell'ambiente anziché essere smaltita in modo corretto.",
         "Una ricerca ha calcolato che i benefici che il nostro Paese può avere dal riciclare la plastica si calcolano nell'ordine dei miliardi di euro.",
         "Ogni anno in Italia si raccoglie in plastica differenziata 7 volte il volume della piramide di Cheope in Egitto e 2 volte il peso dell'Empire State Building di New York" };
        paperTexts = new string[] { "Ogni anno in Italia con la sola raccolta differenziata di carta e cartone si risparmiano in emissioni nocive l'equivalente del blocco totale del traffico per ben 6 giorni e 6 notti.",
         "Per fare una tonnellata di carta dalla cellulosa vergine servono 440.000 litri di acqua e che per fare una tonnellata di carta da cellulosa riciclata bastano 1800 litri d’acqua.",
         "Grazie alle politiche di protezione ambientale e al riciclo di carta e legno, le foreste europee sono in aumento perché l'Europa è all'avanguardia nella gestione forestale sostenibile." };
        glassTexts = new string[] { "Con 1 kg di rottame di vetro recuperato si ottiene 1 Kg di nuovi contenitori in vetro riciclati, all’infinito e senza alcuna perdita.",
        "Il riciclo del vetro in Italia, nel 2008, ha permesso di ridurre l’estrazione di materie prime tradizionali, pari al volume occupato dalla Piramide egizia più importante, quella di Cheope.", 
        };
        organicTexts = new string[] { "I rifiuti organici sono composti da sostanze di origine vegetale e animale che giornalmente occupano circa un terzo dei rifiuti solidi urbani.",
        "Delle 428.711 ton. di rifiuti raccolte nel 2010, il 48,73% è differenziato. Il rimanente diventa soprattutto CDR (Combustibile derivato dai rifiuti) che viene trasformato in impianti e utilizzato insieme al carbone nelle centrali dell’Enel. In questo modo i cittadini ricavano energia dai loro rifiuti.",
        "Utilizzare nel contenitore dell’organico sacchetti biodegradabili o buste di carta pane. Non utilizzare sacchetti in plastica." };
        indiffTexts = new string[] { "In 20 anni il Consorzio Conai e Consorzi di Filiera hanno avviato a riciclo 50 milioni di di tonnellate di rifiuti di imballaggi evitando così l’apertura di 130 discariche e l’emissione di 40 milioni di tonnellate di CO2.",
        "In Svezia nasce il primo centro commerciale del riuso e del riciclo.",
        "Bruciare i rifiuti sviluppa sostanze tossiche che non solo causano irritazioni e problemi alle vie respiratorie, ma possono anche risultare cancerogeni." };
        plasticLinks = new string[] { "http://recycletheworld.altervista.org/curiosita-sulla-plastica/",
        "http://recycletheworld.altervista.org/9-2/",
        "http://recycletheworld.altervista.org/curiosita-sulla-plastica-2/",
        "http://recycletheworld.altervista.org/curiosita-sulla-plastica-3/?doing_wp_cron=1557749962.8319580554962158203125"};
        paperLinks = new string[] { "http://recycletheworld.altervista.org/curiosita-sulla-carta/?doing_wp_cron=1557750765.3974220752716064453125",
        "http://recycletheworld.altervista.org/curiosita-sulla-carta-2/",
        "http://recycletheworld.altervista.org/curiosita-sulla-carta-3/" };
        glassLinks = new string[] { "http://recycletheworld.altervista.org/curiosita-sul-vetro/?doing_wp_cron=1557751474.1524140834808349609375",
        "http://recycletheworld.altervista.org/curiosita-sul-vetro-2/" };
        organicLinks = new string[] { "http://recycletheworld.altervista.org/curiosita-sullorganico/",
        "http://recycletheworld.altervista.org/curiosita-sullorganico-2/",
        "http://recycletheworld.altervista.org/curiosita-sullorganico-3/"};
        indiffLinks = new string[] {"http://recycletheworld.altervista.org/curiosita-sul-vetro-3/",
        "http://recycletheworld.altervista.org/curiosita-sullindifferenziato-2/",
        "http://recycletheworld.altervista.org/curiosita-sullindifferenziato/" };
        closed = false;
       
        RandomText();
    }
	
	// Update is called once per frame
	void Update () {
		
        if(TimeLeftScript.timeLeft <= 0)
        {
            Time.timeScale = 0;
            timeLeft.gameObject.SetActive(false);
            score.gameObject.SetActive(false);
            /*timeIsUp.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            share.gameObject.SetActive(true);
            exit.gameObject.SetActive(true);
            buttonL.gameObject.SetActive(false);
            buttonR.gameObject.SetActive(false);
            testo.gameObject.SetActive(true);*/

            if (!closed) {
                scoreNumber.text = ScoreScript.scoreValue.ToString();
                endPanel.gameObject.SetActive(true);
                restartPanel.gameObject.SetActive(false);
                messagePanel.gameObject.SetActive(true);
                closed = true;
            }
           



        }
	}

    public void restartScene()
    {

        timeIsUp.gameObject.SetActive(false);
        //restartButton.gameObject.SetActive(false);
       //exit.gameObject.SetActive(false);
        //share.gameObject.SetActive(false);
        Time.timeScale = 1;
        TimeLeftScript.timeLeft = 10f;
        SceneManager.LoadScene("SampleScene");
        ScoreScript.scoreValue = 0;
        buttonL.gameObject.SetActive(true);
        buttonR.gameObject.SetActive(true);
        testo.gameObject.SetActive(false);


    }

    public void exitScene()
    {
        SceneManager.LoadScene("Menu");
        timeIsUp.gameObject.SetActive(false);
        //restartButton.gameObject.SetActive(false);
        //exit.gameObject.SetActive(false);
        //share.gameObject.SetActive(false);
        Time.timeScale = 1;
        TimeLeftScript.timeLeft = 10f;
        ScoreScript.scoreValue = 0;
        buttonL.gameObject.SetActive(true);
        buttonR.gameObject.SetActive(true);
        
    }

    public void RandomText()
    {
        if (plasticTrash.gameObject.active) {
            randomText = UnityEngine.Random.Range(0, plasticTexts.Length);
            testo.text = plasticTexts[randomText];
            link = plasticLinks[randomText];
        }
        if (paperTrash.gameObject.active)
        {
            randomText = UnityEngine.Random.Range(0, paperTexts.Length);
            testo.text = paperTexts[randomText];
            link = paperLinks[randomText];
        }
        if (glassTrash.gameObject.active)
        {
            randomText = UnityEngine.Random.Range(0, glassTexts.Length);
            testo.text = glassTexts[randomText];
            link = glassLinks[randomText];
        }
        if (organicTrash.gameObject.active)
        {
            randomText = UnityEngine.Random.Range(0, organicTexts.Length);
            testo.text = organicTexts[randomText];
            link = organicLinks[randomText];
        }
        if (indiffTrash.gameObject.active)
        {
            randomText = UnityEngine.Random.Range(0, indiffTexts.Length);
            testo.text = indiffTexts[randomText];
            link = indiffLinks[randomText];
        }



    }
    public void close() {
        messagePanel.gameObject.SetActive(false);
        restartPanel.gameObject.SetActive(true);
    }

    public void Share()
    {
        FB.ShareLink(
        new System.Uri(link),
    callback: ShareCallback
);
        Debug.Log(link);
        test();

    }
    private void ShareCallback(IShareResult result)
    {
        if (result.Cancelled || !String.IsNullOrEmpty(result.Error))
        {
            Debug.Log("ShareLink Error: " + result.Error);
        }
        else if (!String.IsNullOrEmpty(result.PostId))
        {
            // Print post identifier of the shared content
            Debug.Log(result.PostId);
        }
        else
        {
            // Share succeeded without postID
            Debug.Log("ShareLink success!");
        }
    }

    public void FacebookGameRequest()
    {
        FB.AppRequest("Hey! Come and play this awesome game!", title: "Recycle The World");
    }

    public void test()
    {
        moneta = PlayerPrefs.GetInt("moneta");
        moneta++;
        PlayerPrefs.SetInt("moneta", moneta);
     

    }
}
