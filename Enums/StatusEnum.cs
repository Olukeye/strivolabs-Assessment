using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace strivolabs_Assessment.Enums
{
    public enum StatusEnum
    {/// <summary>
     ///Display successful Message e.t toast or modal
     /// </summary>
        Success = 200,
        /// <summary>
        ///Display message to show the request failed or Why it faile
        /// </summary>
        Failed = 201,
        /// <summary>
        ///Display message e.g Record Not Found or No Data
        /// </summary>
        NoRecordFound = 204,
        /// <summary>
        /// Display message to show the validation is wrong due to parameters or logic
        /// </summary>
        Validation = 203,
        /// <summary>
        /// Display generic message to show what went wrong
        /// </summary>
        Message = 205,
        /// <summary>
        /// Error Messages
        /// </summary>
        ServerError = 500,
        SystemError = 999,
        Unauthorised = 401
    }



}