using System.ComponentModel;

namespace ULearn.ModelViews
{
    public enum ActionInvocationTypeEnum
    {
        [Description("Email Confirmation")]
        EmailConfirmation = 1,
        [Description("Reset Password")]
        ResetPassword = 2
    }
}
