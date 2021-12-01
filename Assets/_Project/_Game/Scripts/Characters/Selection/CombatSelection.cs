using System.Linq;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;

public class CombatSelection : MonoBehaviour
{
    [SerializeField] InputController _input;
    PlayerController _controller;
    [SerializeField] List<EnemyController> _characters = new List<EnemyController>();
    [SerializeField] Button _selectionBtn;
    [SerializeField] ActionAttack _actionAttack;

    [SerializeField] GameObject _currentTarget;
    int _prevIndex;

    private void Awake()
    {
        _controller = GetComponent<PlayerController>();
    }

    public void InitCombatList(List<GameObject> characters)
    {
        for (int i = 0; i < characters.Count; i++)
        {
            if (characters[i].GetComponent<EnemyController>() == null)
                continue;

            _characters.Add(characters[i].GetComponent<EnemyController>());
        }
    }

    public void InitInput(InputController inputController) => _input = inputController;
    public void InitSelectionMode()
    {
        _input.PressedLeft += SwitchTargetLeft;
        _input.PressedRight += SwitchTargetRight;

        _controller.DisableInput();
        _controller.EnableSelectCanvas();

        _selectionBtn.onClick.AddListener(Select);

        GetCombatTarget(0);
    }

    void GetCombatTarget(int index)
    {
        if (index < 0)
            index = _characters.Count - 1;
        if (index > _characters.Count - 1)
            index = 0;
        _currentTarget = _characters[index].gameObject;
        _prevIndex = index;
    }

    void SwitchTargetRight()
    {
        GetCombatTarget(_prevIndex + 1);
    }

    void SwitchTargetLeft()
    {
        GetCombatTarget(_prevIndex - 1);
    }

    void Select()
    {
        _actionAttack.GetSelectionTarget(_currentTarget.GetComponent<IDamagable>());
        _characters.Clear();
        ExitSelection();
    }

    void ExitSelection()
    {
        _input.PressedLeft -= SwitchTargetLeft;
        _input.PressedRight -= SwitchTargetRight;
        _selectionBtn.onClick.RemoveListener(Select);
        _characters.Clear();
        _controller.DisableSelectCanvas();
    }
}