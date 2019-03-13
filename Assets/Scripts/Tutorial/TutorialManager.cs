using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager tutorialManager;

    [SerializeField] Text tutorialText;
    [SerializeField] bool playTutorial;

    bool goalPassed;
    bool whatToDoPassed;
    bool dragAndDropPassed;
    bool selectPassed;
    bool rotationPassed;

    void Awake()
    {
        tutorialManager = this;
    }

    public void ShowGoalText()
    {
        if (!playTutorial || tutorialText == null)
            return;

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

    public void ShowWhatToDoText()
    {
        if (!playTutorial || tutorialText == null)
            return;

        if (!whatToDoPassed)
        {
            tutorialText.text = "La caméra se place alors en vue de côté. Pour atteindre le réceptacle, il faut placer des objets.";
            whatToDoPassed = true;
        }
        else
        {
            tutorialText.text = "A vous d'expérimenter les différentes formes pour mieux les comprendre !";
        }
    }

    public void ShowDragAndDropText()
    {
        if (!playTutorial || tutorialText == null)
            return;

        if (!dragAndDropPassed)
        {
            tutorialText.text = "Pour placer un objet, maintenez le clic sur l'une des 3 icônes et glissez-la sur un emplacement grisé.";
            dragAndDropPassed = true;
        }
    }

    public void ShowSelectText()
    {
        if (!playTutorial || tutorialText == null)
            return;

        goalPassed = true;
        whatToDoPassed = true;
        dragAndDropPassed = true;

        if (!selectPassed)
        {
            tutorialText.text = "Une fois l'objet placé, vous pouvez faire un cliquer-glisser pour le replacer ailleurs, ou cliquer dessus pour le faire pivoter.";
            selectPassed = true;
        }
    }

    public void ShowRotationText()
    {
        if (!playTutorial || tutorialText == null)
            return;

        if (!rotationPassed)
        {
            tutorialText.text = "En fonction de la forme faisant face à la caméra de côté, l'objet aura un comportement différent avec la balle. lancez pour essayer !";
            rotationPassed = true;
        }
    }
}
