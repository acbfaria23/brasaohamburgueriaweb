﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularForms.Helpers
{
    public class ServiceResult
    {
        private bool _succeeded;
        private List<String> _errors;
        private dynamic _data;

        public ServiceResult()
        {

        }

        public ServiceResult(bool succeeded, List<String> errors, dynamic data)
        {
            this._succeeded = succeeded;
            this._errors = errors;
            this._data = data;
        }

        public bool Succeeded
        {
            get 
            {
                return _succeeded;
            }
            set
            {
                _succeeded = value;
            }
        }

        public List<String> Errors
        {
            get
            {
                return _errors;
            }
            set
            {
                _errors = value;
            }
        }

        public dynamic data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
            }
        }
    }
}