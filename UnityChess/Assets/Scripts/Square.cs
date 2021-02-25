using UnityEngine;

public class Square : MonoBehaviour
{
    [SerializeField]
    private string _name;
    public string Name => _name;

    public void SetName(int x, int y)
    {
        string xx = char.ConvertFromUtf32(97 + x);
        string yy = (y + 1).ToString();

        _name = xx + yy;
    }

}
