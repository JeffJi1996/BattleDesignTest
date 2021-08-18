using UnityEngine;
using UnityEngine.SceneManagement;

namespace LogoSceneFX {

public class LogoSceneSelect : MonoBehaviour
{
	public bool GUIHide = false;
	public bool GUIHide2 = false;
	public bool GUIHide3 = false;
	
    public void LoadLogo01()
    {
        SceneManager.LoadScene("Logo01");
    }
    public void LoadLogo02()
    {
        SceneManager.LoadScene("Logo02");
    }
	public void LoadLogo03()
    {
        SceneManager.LoadScene("Logo03");
    }
	public void LoadLogo04()
    {
        SceneManager.LoadScene("Logo04");
    }
	public void LoadLogo05()
    {
        SceneManager.LoadScene("Logo05");
    }
	public void LoadLogo06()
    {
        SceneManager.LoadScene("Logo06");
    }
	public void LoadLogo07()
    {
        SceneManager.LoadScene("Logo07");
    }
	public void LoadLogo08()
    {
        SceneManager.LoadScene("Logo08");
    }
	public void LoadLogo09()
    {
        SceneManager.LoadScene("Logo09");
    }
	public void LoadLogo10()
    {
        SceneManager.LoadScene("Logo10");
    }
	public void LoadLogo11()
    {
        SceneManager.LoadScene("Logo11");
    }
	public void LoadLogo12()
    {
        SceneManager.LoadScene("Logo12");
    }
	public void LoadLogo13()
    {
        SceneManager.LoadScene("Logo13");
    }
	public void LoadLogo14()
    {
        SceneManager.LoadScene("Logo14");
    }
	public void LoadLogo15()
    {
        SceneManager.LoadScene("Logo15");
    }
	public void LoadLogoFadeIn01()
    {
        SceneManager.LoadScene("LogoFadeIn01");
    }
    public void LoadLogoFadeIn02()
    {
        SceneManager.LoadScene("LogoFadeIn02");
    }
	public void LoadLogoFadeIn03()
    {
        SceneManager.LoadScene("LogoFadeIn03");
    }
	public void LoadLogoFadeIn04()
    {
        SceneManager.LoadScene("LogoFadeIn04");
    }
	public void LoadLogoFadeIn05()
    {
        SceneManager.LoadScene("LogoFadeIn05");
    }
	public void LoadLogoFadeIn06()
    {
        SceneManager.LoadScene("LogoFadeIn06");
    }
	public void LoadLogoFadeIn07()
    {
        SceneManager.LoadScene("LogoFadeIn07");
    }
	public void LoadLogoFadeIn08()
    {
        SceneManager.LoadScene("LogoFadeIn08");
    }
	public void LoadLogoFadeIn09()
    {
        SceneManager.LoadScene("LogoFadeIn09");
    }
	public void LoadLogoFadeIn10()
    {
        SceneManager.LoadScene("LogoFadeIn10");
    }
	public void LoadLogoFadeIn11()
    {
        SceneManager.LoadScene("LogoFadeIn11");
    }
	public void LoadLogoFadeIn12()
    {
        SceneManager.LoadScene("LogoFadeIn12");
    }
	public void LoadLogoFadeIn13()
    {
        SceneManager.LoadScene("LogoFadeIn13");
    }
	public void LoadLogoFadeIn14()
    {
        SceneManager.LoadScene("LogoFadeIn14");
    }
	public void LoadLogoFadeIn15()
    {
        SceneManager.LoadScene("LogoFadeIn15");
    }
	void Update ()
	 {
 
     if(Input.GetKeyDown(KeyCode.J))
	 {
         GUIHide = !GUIHide;
     
         if (GUIHide)
		 {
             GameObject.Find("CanvasSceneSelect").GetComponent<Canvas> ().enabled = false;
         }
		 else
		 {
             GameObject.Find("CanvasSceneSelect").GetComponent<Canvas> ().enabled = true;
         }
     }
	      if(Input.GetKeyDown(KeyCode.K))
	 {
         GUIHide2 = !GUIHide2;
     
         if (GUIHide2)
		 {
             GameObject.Find("Canvas").GetComponent<Canvas> ().enabled = false;
         }
		 else
		 {
             GameObject.Find("Canvas").GetComponent<Canvas> ().enabled = true;
         }
     }
		if(Input.GetKeyDown(KeyCode.L))
	 {
         GUIHide3 = !GUIHide3;
     
         if (GUIHide3)
		 {
             GameObject.Find("CanvasTips").GetComponent<Canvas> ().enabled = false;
         }
		 else
		 {
             GameObject.Find("CanvasTips").GetComponent<Canvas> ().enabled = true;
         }
     }
}
}
}