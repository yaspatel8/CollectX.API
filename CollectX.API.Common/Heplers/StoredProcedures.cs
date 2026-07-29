using System;
using System.Collections.Generic;
using System.Text;

namespace CollectX.API.Common.Heplers
{
    public class StoredProcedures
    {
        #region Account
        public const string SP_UserLogin = "SP_UserLogin";
        public const string SP_ChangePassword = "SP_ChangePassword";
        public const string SP_GetUserDetails = "SP_GetUserDetails";
        #endregion

        #region Binders
        public const string SP_BindersSave = "SP_BindersSave";
        public const string SP_BinderDelete = "SP_BinderDelete";
        #endregion

        #region Colors
        public const string SP_ColorsGetAll = "SP_ColorsGetAll";
        #endregion

        #region Pokets
        public const string SP_PocketsGetAll = "SP_PocketsGetAll";
        #endregion

        #region Sets
        public const string SP_SetsGetAll = "SP_SetsGetAll";
        #endregion
    }
}
