﻿using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.CurrentAccount.Application.Exceptions
{
    public class CustomValidationException : Exception
    {
        public CustomValidationException() : base("One or more validation failures have occurred.")
        {
            Errors = new List<string>();
        }
        public List<string> Errors { get; }
        public CustomValidationException(IEnumerable<ValidationFailure> failures)
            : this()
        {
            foreach (var failure in failures)
            {
                Errors.Add(failure.ErrorMessage);
            }
        }

    }
}
