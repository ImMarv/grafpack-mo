using System.Windows.Forms;

namespace grafpack_2202368.Handles
{
    interface IInteractionHandler
    {
        void OnMouseDown(MouseEventArgs e);
        void OnMouseMove(MouseEventArgs e);
        void OnMouseUp(MouseEventArgs e);
    }
}
