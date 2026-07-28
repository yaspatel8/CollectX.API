using System;
using System.Collections.Generic;
using System.Text;

namespace CollectX.API.Common.Heplers
{
    public class ErrorMessages
    {
        #region General
        public const string SomethingWentWrong = "Something went wrong. Please try again later.";
        public const string NoParametersPassed = "No parameters passed.";
        public const string Success = "Success";
        public const string ValidationFailed = "Validation Failed";
        #endregion

        #region Account
        public const string AccessTokenExpired = "Access token expired, please refresh.";
        public const string TokenRefreshSuccess = "Token refreshed successfully.";
        public const string InvalidCredential = "Invalid email or password.";
        public const string EmailNotExists = "Email does not exists.";
        public const string UserInactive = "Your account is inactive. Please contact administrator.";
        public const string AuthenticationCodeSentSuccess = "Authentication code sent successfully. Please check your inbox.";
        public const string LinkNotValid = "Link is not valid. Please request a new one to reset your password.";
        public const string ChangePasswordSuccess = "Password changed successfully.";
        public const string MissingRefreshToken = "Missing refresh token.";
        public const string InvalidRefreshToken = "Invalid or expired refresh token.";
        public const string OtpVerificationFailed = "OTP verification failed.";
        public const string OtpExpired = "OTP has expired.";
        public const string OtpVerifiedSuccessBulkEmail = "OTP verified successfully. You may proceed with bulk email send.";
        public const string ConfirmPassword = "Password and confirmation password does not match.";
        public const string PasswordValidationConfirm = "Confirm password is required.";
        public const string PasswordValidation = "Both password and confirm password are required.";
        public const string PasswordFieldValidation = "One or more fields are required.";
        public const string PasswordCheck = "Please enter valid old Password.";
        public const string PasswordMatch = "New password can't be same as old password.";
        public const string StrongPassword = "Please enter strong password.";
        public const string LoginSuccess = "Logged in successfully.";
        public const string Unauthorized = "You are not authorized to perform this action.";
        public const string ChangePasswordSessionExpired = "Change password session has expired. Please start again.";
        public const string SessionRevokedSuccess = "Session revoked successfully.";
        public const string SessionNotFound = "Session not found.";
        public const string CannotRevokeCurrentSession = "You cannot revoke your current session.";
        #endregion

        #region User
        public const string UserAddedSuccess = "User added successfully.";
        public const string UserUpdatedSuccess = "User updated successfully.";
        public const string UserDeletedSuccess = "User deleted successfully.";
        public const string UserActivatedSuccess = "User activated successfully.";
        public const string UserDeactivatedSuccess = "User deactivated successfully.";
        public const string UserNotFound = "User not found.";
        public const string EmailAlreadyExists = "Email already exists.";
        public const string PrimaryUserProtected = "Primary user cannot be deleted or deactivated.";
        public const string UserAlreadyActive = "User is already active.";
        public const string UserAlreadyInactive = "User is already inactive.";
        #endregion
    }
}
