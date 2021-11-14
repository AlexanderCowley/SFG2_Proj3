using UnityEngine.UI;
using UnityEngine;

public class PlayerController : CombatCharacterController
{
    [SerializeField] GameObject _canvasObj;

    private void Awake()
    {
        _canvasObj.SetActive(false);
        print(_canvasObj);
    }
    public override void EnableInput()
    {
        print(_canvasObj);
        _canvasObj.SetActive(true);
    }

    public override void DisableInput()
    {
        _canvasObj.SetActive(false);
    }
}