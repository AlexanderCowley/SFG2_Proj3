using UnityEngine.UI;
using UnityEngine;

public class PlayerController : CombatCharacterController
{
    [SerializeField] GameObject _canvasObj;
    [SerializeField] GameObject _selectCanvas;
    private void Awake()
    {
        _canvasObj.SetActive(false);
        _selectCanvas.SetActive(false);
    }
    public override void EnableInput() => _canvasObj.SetActive(true);

    public void EnableSelectCanvas() => _selectCanvas.SetActive(true);

    public void DisableSelectCanvas() => _selectCanvas.SetActive(false);

    public override void DisableInput() => _canvasObj.SetActive(false);
}