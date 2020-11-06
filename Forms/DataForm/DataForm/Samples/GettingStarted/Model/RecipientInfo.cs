#region Copyright
// <copyright file="RecipientInfo.cs" company="Syncfusion"> 
//  Copyright (c) Syncfusion Inc. 2001 - 2020. All rights reserved.
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Re-distribution in any form is strictly
//  prohibited. Any infringement will be prosecuted under applicable laws. 
// </copyright> 
#endregion

namespace SampleBrowser.SfDataForm
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using Syncfusion.XForms.DataForm;
    using Xamarin.Forms.Internals;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Describes the possible account type.
    /// </summary>
    [Preserve(AllMembers = true)]
    public enum AccountType
    {
        /// <summary>
        /// Represents savings account type.
        /// </summary>
        Savings,

        /// <summary>
        /// Represents current account type.
        /// </summary>
        Current,

        /// <summary>
        /// Represents overdraft account type.
        /// </summary>
        Overdraft,

        /// <summary>
        /// Represents cashcredit account type.
        /// </summary>
        CashCredit,

        /// <summary>
        /// Represents loan account type.
        /// </summary>
        LoanAccount,

        /// <summary>
        /// Represents NRE account type.
        /// </summary>
        NRE,

        /// <summary>
        /// Represents cardpayment type.
        /// </summary>
        CardPayment
    }

    /// <summary>
    /// Represents the recipient information of the data form getting started sample.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class RecipientInfo : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        #region Fields       

        /// <summary>
        /// Represents the account number of the recipient information.
        /// </summary>
        private string accountNumber;

        /// <summary>
        /// Represents the second account number of the recipient information.
        /// </summary>
        private string accountNumber1;

        /// <summary>
        /// Represents the email id of the recipient information.
        /// </summary>
        private string email;

        /// <summary>
        /// Represents the amount of the recipient information.
        /// </summary>
        private double? amount = null;

        /// <summary>
        /// Represents the name of the recipient information.
        /// </summary>
        private string name;

        /// <summary>
        /// Represents the swift of the recipient information.
        /// </summary>
        private string swift;

        /// <summary>
        /// Represents the terms and conditions of the recipient information.
        /// </summary>
        private bool agree;

        /// <summary>
        /// Represents the password of the recipient information.
        /// </summary>
        private string password;

        /// <summary>
        /// Represents the account type of the recipient information.
        /// </summary>
        private AccountType accountType;

        /// <summary>
        /// Represents the immutable email regular expression.
        /// </summary>
        private Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

        /// <summary>
        /// Represents a collection of keys and values.
        /// </summary>
        private Dictionary<string, List<string>> propErrors = new Dictionary<string, List<string>>();

        /// <summary>
        /// Represents a immutable regular expression.
        /// </summary>
        private Regex swiftRegex = new Regex("^[A-Z]{6}[A-Z0-9]{2}([A-Z0-9]{3})?$");
        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="RecipientInfo"/> class.
        /// </summary>
        public RecipientInfo()
        {
        }

        /// <summary>
        /// Represents the method that will handle when a property is changed on a component.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Represents the method that will handle when a Errors are changed.
        /// </summary>
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        #endregion

        #region Public Properties  

        /// <summary>
        /// Gets a value indicating whether recipient information contains errors.
        /// </summary>
        ////[Display(AutoGenerateField = false)]
        public bool HasErrors
        {
            get
            {
                var propErrorsCount = this.propErrors.Values.FirstOrDefault(r => r.Count > 0);
                if (propErrorsCount != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Gets or sets the account number field.
        /// </summary>
        [Display(ShortName = "Account number")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter account number.")]
        public string AccountNumber
        {
            get
            {
                return this.accountNumber;
            }

            set
            {
                if (value != this.AccountNumber)
                {
                    this.accountNumber = value;
                    this.RaisePropertyChanged("AccountNumber");
                    this.RaiseErrorChanged("AccountNumber");
                }
            }
        }

        /// <summary>
        /// Gets or sets the first account number field.
        /// </summary>
        [Display(ShortName = "Re-enter account number")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please re-enter account number.")]
        public string AccountNumber1
        {
            get
            {
                return this.accountNumber1;
            }

            set
            {
                if (value != this.AccountNumber1)
                {
                    this.accountNumber1 = value;
                    this.RaisePropertyChanged("AccountNumber1");
                    this.RaiseErrorChanged("AccountNumber1");
                }
            }
        }

        /// <summary>
        /// Gets or sets the SWIFT field.
        /// </summary>
        [Display(Order = 0, ShortName = "SWIFT code", Prompt = "Enter 8 or 11 upper case letters")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the SWIFT code.")]
        [DisplayOptions(ValidMessage = "Name length is enough")]
        public string SWIFT
        {
            get
            {
                return this.swift;
            }

            set
            {
                this.swift = value;
                this.RaisePropertyChanged("SWIFT");
                this.RaiseErrorChanged("SWIFT");
            }
        }

        /// <summary>
        /// Gets or sets the name field.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the name.")]
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
                this.RaisePropertyChanged("Name");
                this.RaiseErrorChanged("Name");
            }
        }

        /// <summary>
        /// Gets or sets the email field.
        /// </summary>
        [Display(ShortName = "Email")]
        [EmailAddress(ErrorMessage = "Please enter a valid e-mail id.")]
        public string Email
        {
            get
            {
                return this.email;
            }

            set
            {
                this.email = value;
                this.RaisePropertyChanged("Email");
                this.RaiseErrorChanged("Email");
            }
        }

        /// <summary>
        /// Gets or sets the ammount field.
        /// </summary>
        [Display(ShortName = "Amount")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the amount.")]
        public double? Amount
        {
            get
            {
                return this.amount;
            }

            set
            {
                this.amount = value;
                this.RaisePropertyChanged("Amount");
                this.RaiseErrorChanged("Amount");
            }
        }

        /// <summary>
        /// Gets or sets the password field.
        /// </summary>
        [Display(ShortName = "Transaction password", Prompt = "Enter password")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the password.")]
        [DataType(DataType.Password)]
        public string Password
        {
            get
            {
                return this.password;
            }

            set
            {
                this.password = value;
                this.RaisePropertyChanged("Password");
                this.RaiseErrorChanged("Password");
            }
        }

        /// <summary>
        /// Gets or sets the account type field.
        /// </summary>
        [Display(ShortName = "Account type")]
        public AccountType AccountType
        {
            get
            {
                return this.accountType;
            }
            set
            {
                this.accountType = value;
                this.RaisePropertyChanged("AccountType");
                this.RaiseErrorChanged("AccountType");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether terms and conditions of the recipient information is agreed.
        /// </summary>
        [DisplayOptions(ShowLabel = false)]
        public bool Agree
        {
            get
            {
                return this.agree;
            }

            set
            {
                this.agree = value;
                this.RaisePropertyChanged("Agree");
                this.RaiseErrorChanged("Agree");
            }
        }

        #endregion

        /// <summary>
        /// Gets the errors by validating the properties of the recipient informatio.
        /// </summary>
        /// <param name="propertyName">Property name of the recipient information.</param>
        /// <returns>Returns the errors if property name is not null.</returns>
        public IEnumerable GetErrors(string propertyName)
        {
            if (propertyName == null)
            {
                return null;
            }

            List<string> errors = new List<string>();
            if (propertyName == "AccountNumber")
            {
                if (!string.IsNullOrEmpty(this.AccountNumber))
                {
                    this.propErrors.Remove("AccountNumber");
                    var accountNumberLength = this.AccountNumber.ToString().Length;
                    if (accountNumberLength > 10 || accountNumberLength < 5)
                    {
                        if (!this.propErrors.TryGetValue(propertyName, out errors))
                        {
                            errors = new List<string>();
                            errors.Add("Length should be between 5 and 10.");
                            this.propErrors.Add("AccountNumber", errors);
                        }
                    }
                    else if (this.propErrors.TryGetValue(propertyName, out errors))
                    {
                        errors.Clear();
                        this.propErrors.Remove(propertyName);
                    }
                }
                else if (this.propErrors.TryGetValue(propertyName, out errors))
                {
                    errors.Clear();
                    this.propErrors.Remove(propertyName);
                }
            }
            else if (propertyName == "AccountNumber1")
            {
                if (!string.IsNullOrEmpty(this.AccountNumber1))
                {
                    var accountNumberLength = this.AccountNumber1.ToString().Length;
                    var error = string.Empty;
                    if (this.AccountNumber1 != this.AccountNumber)
                    {
                        error = "Account numbers don't match.";
                    }
                    else if (accountNumberLength > 10 || accountNumberLength < 5)
                    {
                        error = "Length should be between 5 and 10.";
                    }
                    else if (this.propErrors.TryGetValue(propertyName, out errors))
                    {
                        errors.Clear();
                        this.propErrors.Remove(propertyName);
                    }

                    if (!this.propErrors.TryGetValue(propertyName, out errors) && !string.IsNullOrEmpty(error))
                    {
                        errors = new List<string>();
                        errors.Add(error);
                        this.propErrors.Add("AccountNumber1", errors);
                    }
                }
                else if (this.propErrors.TryGetValue(propertyName, out errors))
                {
                    errors.Clear();
                    this.propErrors.Remove(propertyName);
                }
            }
            else if (propertyName == "Amount")
            {
                if (this.Amount <= 0)
                {
                    if (!this.propErrors.TryGetValue(propertyName, out errors))
                    {
                        errors = new List<string>();
                        errors.Add("Amount should be greater than 0.");
                        this.propErrors.Add("Amount", errors);
                    }
                }
                else if (this.propErrors.TryGetValue(propertyName, out errors))
                {
                    errors.Clear();
                    this.propErrors.Remove(propertyName);
                }
            }
            else if (propertyName == "SWIFT")
            {
                if (string.IsNullOrEmpty(this.SWIFT))
                {
                    return string.Empty;
                }

                if (!this.swiftRegex.IsMatch(this.SWIFT))
                {
                    if (!this.propErrors.TryGetValue(propertyName, out errors))
                    {
                        errors = new List<string>();
                        errors.Add("SWIFT code should be 8 or 11 upper case letters.");
                        this.propErrors.Add("SWIFT", errors);
                    }
                }
                else if (this.propErrors.TryGetValue(propertyName, out errors))
                {
                    errors.Clear();
                    this.propErrors.Remove(propertyName);
                }
            }
            else if (propertyName == "Password")
            {
                if (string.IsNullOrEmpty(this.Password))
                {
                    return string.Empty;
                }

                var error = string.Empty;

                if (this.Password != "password")
                {
                    error = "Password is incorrect.";
                }

                if (!this.propErrors.TryGetValue(propertyName, out errors) && !string.IsNullOrEmpty(error))
                {
                    errors = new List<string>();
                    errors.Add(error);
                    this.propErrors.Add("Password", errors);
                }
                else if (this.propErrors.TryGetValue(propertyName, out errors))
                {
                    errors.Clear();
                    this.propErrors.Remove(propertyName);
                }
            }
            else if (propertyName == "Agree")
            {
                var error = string.Empty;

                if (this.Agree != true)
                {
                    error = "Please check the checkbox to agree to the Terms & Conditions.";
                }

                if (!this.propErrors.TryGetValue(propertyName, out errors))
                {
                    errors = new List<string>();
                    errors.Add(error);
                    this.propErrors.Add("Agree", errors);
                }
                else if (this.propErrors.TryGetValue(propertyName, out errors))
                {
                    errors.Clear();
                    this.propErrors.Remove(propertyName);
                }
            }

            if (this.propErrors.TryGetValue(propertyName, out errors))
            {
                return errors;
            }

            return null;
        }

        /// <summary>
        /// Occurs when propery value is changed.
        /// </summary>
        /// <param name="propName">Property name</param>
        private void RaisePropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        /// <summary>
        /// Occurs when error value is changed.
        /// </summary>
        /// <param name="propName">Property name</param>
        private void RaiseErrorChanged(string propName)
        {
            if (this.ErrorsChanged != null)
            {
                this.ErrorsChanged(this, new DataErrorsChangedEventArgs(propName));
            }
        }
    }
}