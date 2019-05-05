using UnityEngine;

public interface IMovement
{
    void MoveZ(float vertical);
    void MoveX(float horizontal);
    void RotateY(float mouseY);
    void RotateX(float mouseX);
}