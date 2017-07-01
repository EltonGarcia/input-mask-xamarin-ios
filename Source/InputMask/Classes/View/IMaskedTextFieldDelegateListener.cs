using UIKit;

namespace InputMask.Classes.View
{
    public interface IMaskedTextFieldDelegateListener : IUITextFieldDelegate
    {
        void TextField(IUITextInput textField, bool complete, string value);
    }
}