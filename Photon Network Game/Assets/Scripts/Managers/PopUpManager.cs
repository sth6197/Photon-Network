using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum PopUpType
{
    TEXT,
    SIGNUP,
    PAUSE
}

public class PopUpManager : MonoBehaviour
{
    public static PopUpManager instance;

    [SerializeField] Transform parentTransform;

    private Dictionary<PopUpType, GameObject> dictionary = new Dictionary<PopUpType, GameObject>();

    public static PopUpManager Instance { get { return instance; } }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    public void Show(PopUpType popUpType, string content)
    {
        GameObject popup = null;

        if (dictionary.TryGetValue(popUpType, out popup))
        {
            popup.gameObject.SetActive(true);
        }
        else
        {
            popup = Instantiate(Resources.Load<GameObject>(popUpType.ToString()));

            popup.transform.SetParent(parentTransform);

            popup.GetComponent<RectTransform>().localPosition = new Vector2(0, 0);

            // popup.GetComponent<PopUp>().SetData(content);

            dictionary.Add(popUpType, popup);
        }
    }
}