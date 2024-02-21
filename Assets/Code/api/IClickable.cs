using UnityEngine.EventSystems;

/*
 An interface modelling an object that can be clicked. Players and suitable
terrain tiles should implement this interface.
 */
public interface IClickable : IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerExitHandler
{
    void OnClick();
}

