using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text notitext;
    public static UIManager instance;

    private void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowNotiText(string s)
    {
        notitext.text = s;
    }
}