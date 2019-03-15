using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager tutorialManager;

    [SerializeField] Text tutorialText;
    [SerializeField] TutoPart tutoPart;

    public bool goalPassed;
    public bool whatToDoPassed;
    public bool dragAndDropPassed;
    public bool resolvePassed;
    public bool rotationPassed;

    void Awake()
    {
        tutorialManager = this;
    }

    public void ShowGoalText()
    {
        if (tutoPart == TutoPart.None || tutorialText == null)
            return;
        Debug.Log("allé ");

        if (tutoPart == TutoPart.First)
        {
            if (!goalPassed)
            {
                tutorialText.text = "Le but est de faire en sorte que la balle bleue rejoigne le réceptacle de la même couleur. Appuyez sur play pour qu'elle commence à bouger.";
                goalPassed = true;
            }
            else if (!dragAndDropPassed)
            {
                ShowDragAndDropText();
                dragAndDropPassed = true;
            }
        }
        else if (tutoPart == TutoPart.Second)
        {
            Debug.Log("allé la");
            if (!goalPassed)
            {
                tutorialText.text = "Une fois placé, un objet peut être pivoté pour modifier sa fonction";
                goalPassed = true;
            }
        }
    }

    public void ShowWhatToDoText()
    {
        if (tutoPart == TutoPart.None || tutorialText == null)
            return;

        if (tutoPart == TutoPart.First)
        {
            if (!whatToDoPassed)
            {
                tutorialText.text = "La caméra se place alors en vue de côté. Pour atteindre le réceptacle, il faut placer des objets.";
                whatToDoPassed = true;
            }
            else
            {
                //tutorialText.text = "A vous d'expérimenter les différentes formes pour mieux les comprendre !";
            }
        }
        
    }

    public void ShowDragAndDropText()
    {
        if (tutoPart == TutoPart.None || tutorialText == null)
            return;

        if (tutoPart == TutoPart.First)
        {
            if (!dragAndDropPassed)
            {
                tutorialText.text = "Pour placer un objet, maintenez le clic sur l'une des 3 icônes et glissez-la sur un emplacement grisé.";
                dragAndDropPassed = true;
            }
        }
    }

    public void ShowSelectText()
    {
        if (tutoPart == TutoPart.None || tutorialText == null)
            return;

        goalPassed = true;
        whatToDoPassed = true;
        dragAndDropPassed = true;

        if (tutoPart == TutoPart.First)
        {
            if (!resolvePassed)
            {
                //tutorialText.text = "Une fois l'objet placé, vous pouvez faire un cliquer-glisser pour le replacer ailleurs, ou cliquer dessus pour le faire pivoter.";
                tutorialText.text = "Il ne reste plus qu'à laisser la balle tomber pour passer le niveau !";
                resolvePassed = true;
            }
        }
        else if (tutoPart == TutoPart.Second)
        {
            if (!resolvePassed)
            {
                tutorialText.text = "Vous pouvez faire un cliquer-glisser sur l'objet pour le replacer ailleurs, ou cliquer dessus pour le faire pivoter.";
                resolvePassed = true;
            }
        }
    }

    public void ShowRotationText()
    {
        if (tutoPart != TutoPart.Second || tutorialText == null)
            return;

        if (!rotationPassed)
        {
            tutorialText.text = "En fonction de la forme faisant face à la caméra de côté, l'objet aura un comportement différent avec la balle. lancez pour essayer !";
            rotationPassed = true;
        }
    }
}

public enum TutoPart
{
    None, First, Second
}