using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable 
{
    void Select(IInteractable i);
    event Action<IInteractable> OnSelection;
}
