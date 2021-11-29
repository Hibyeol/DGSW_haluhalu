using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginManager : MonoBehaviour
{

    public InputField id_Input;
    public Text id_Text;

    public GameObject subbox;
    public Text subintext;
    public Animator subani;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IdInputText()
    {
        id_Text.text = id_Input.text;
    }
}
