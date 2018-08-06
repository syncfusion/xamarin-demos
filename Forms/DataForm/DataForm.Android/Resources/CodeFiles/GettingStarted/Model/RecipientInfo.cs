#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Collections;
using Xamarin.Forms.Internals;
using Syncfusion.XForms.DataForm;

namespace SampleBrowser.SfDataForm
{
    [Preserve(AllMembers = true)]
    public enum AccountType
    {
        Savings,
        Current,
        Overdraft,
        CashCredit,
        LoanAccount,
        NRE,
        CardPayment
    }
    [Preserve(AllMembers = true)]
    public class RecipientInfo : INotifyPropertyChanged, INotifyDataErrorInfo
    {

        #region Fields       

        private string accountNumber;
        private string accountNumber1;

        private string email;
        private double? amount = null;
        private string name;
        private string swift;
		private string password;
        private AccountType accountType;
        Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        Dictionary<string, List<string>> propErrors = new Dictionary<string, List<string>>();
        Regex swiftRegex = new Regex("^[A-Z]{6}[A-Z0-9]{2}([A-Z0-9]{3})?$");
        #endregion

        #region Constructor

        public RecipientInfo()
        {

        }

        #endregion

        #region Public Properties  

        [Display(ShortName = "Account number")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter account number.")]
        public string AccountNumber
        {
            get { return this.accountNumber; }
            set
            {
                if (value != AccountNumber)
                {
                    this.accountNumber = value;
                    this.RaisePropertyChanged("AccountNumber");
                    this.RaiseErrorChanged("AccountNumber");
                }
            }
        }
        
        [Display(ShortName = "Re-enter account number")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please re-enter account number.")]
        public string AccountNumber1
        {
            get { return this.accountNumber1; }
            set
            {
                if (value != AccountNumber1)
                {
                    this.accountNumber1 = value;
                    RaisePropertyChanged("AccountNumber1");
                    this.RaiseErrorChanged("AccountNumber1");
                }
            }
        }

        [Display(ShortName = "Account type")]
        public AccountType AccountType
        {
            get { return accountType; }
            set
            {
                accountType = value;
                RaisePropertyChanged("AccountType");
                this.RaiseErrorChanged("AccountType");
            }
        }

        [Display(Order = 0, ShortName = "SWIFT code", Prompt = "Enter 8 or 11 upper case letters")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the SWIFT code.")]
        public string SWIFT
        {
            get { return this.swift; }
            set
            {
                this.swift = value;
                RaisePropertyChanged("SWIFT");
                this.RaiseErrorChanged("SWIFT");
            }
        }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the name.")]
        public string Name
        {
            get { return this.name; }
            set
            {
                this.name = value;
                RaisePropertyChanged("Name");
                this.RaiseErrorChanged("Name");
            }
        }

        [Display(ShortName = "Email")]
        [EmailAddress(ErrorMessage = "Please enter a valid e-mail id.")]
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                this.RaisePropertyChanged("Email");
                this.RaiseErrorChanged("Email");
            }
        }

        [Display(ShortName = "Amount")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the amount.")]
        public double? Amount
        {
            get
            {
                return amount;
            }
            set
            {
                amount = value;
                RaisePropertyChanged("Amount");
                this.RaiseErrorChanged("Amount");
            }
        }

		[Display(ShortName = "Transaction password", Prompt = "Enter password")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the password.")]
		[DataType(DataType.Password)]
		public string Password
		{
			get { return this.password; }
			set
			{
				this.password = value;
				RaisePropertyChanged("Password");
				this.RaiseErrorChanged("Password");
			}
		}

        #endregion


        public IEnumerable GetErrors(string propertyName)
        {
            if (propertyName == null)
                return null;

            List<string> errors = new List<string>();
			if (propertyName == "AccountNumber")
			{
				if (!string.IsNullOrEmpty(AccountNumber))
				{
					propErrors.Remove("AccountNumber");
					var accountNumberLength = AccountNumber.ToString().Length;
					if (accountNumberLength > 10 || accountNumberLength < 5)
					{
						if (!propErrors.TryGetValue(propertyName, out errors))
						{
							errors = new List<string>();
							errors.Add("Length should be between 5 and 10.");
							propErrors.Add("AccountNumber", errors);
						}
					}
					else if (propErrors.TryGetValue(propertyName, out errors))
					{
						errors.Clear();
						propErrors.Remove(propertyName);
					}
				}
				else if (propErrors.TryGetValue(propertyName, out errors))
				{
					errors.Clear();
					propErrors.Remove(propertyName);
				}
			}
			else if (propertyName == "AccountNumber1")
			{
				if (!string.IsNullOrEmpty(AccountNumber1))
				{
					var accountNumberLength = AccountNumber1.ToString().Length;
					var error = string.Empty;
					if (AccountNumber1 != AccountNumber)
						error = "Account numbers don't match.";
					else if (accountNumberLength > 10 || accountNumberLength < 5)
						error = "Length should be between 5 and 10.";
					else if (propErrors.TryGetValue(propertyName, out errors))
					{
						errors.Clear();
						propErrors.Remove(propertyName);
					}
					if (!propErrors.TryGetValue(propertyName, out errors) && !string.IsNullOrEmpty(error))
					{
						errors = new List<string>();
						errors.Add(error);
						propErrors.Add("AccountNumber1", errors);
					}
				}
				else if (propErrors.TryGetValue(propertyName, out errors))
				{
					errors.Clear();
					propErrors.Remove(propertyName);
				}
			}
			else if (propertyName == "Amount")
			{
				if (Amount <= 0)
				{
					if (!propErrors.TryGetValue(propertyName, out errors))
					{
						errors = new List<string>();
						errors.Add("Amount should be greater than 0.");
						propErrors.Add("Amount", errors);
					}
				}
				else if (propErrors.TryGetValue(propertyName, out errors))
				{
					errors.Clear();
					propErrors.Remove(propertyName);
				}
			}
			else if (propertyName == "SWIFT")
			{
				if (string.IsNullOrEmpty(this.SWIFT))
					return string.Empty;
				if (!swiftRegex.IsMatch(this.SWIFT))
				{
					if (!propErrors.TryGetValue(propertyName, out errors))
					{
						errors = new List<string>();
						errors.Add("SWIFT code should be 8 or 11 upper case letters.");
						propErrors.Add("SWIFT", errors);
					}
				}
				else if (propErrors.TryGetValue(propertyName, out errors))
				{
					errors.Clear();
					propErrors.Remove(propertyName);
				}
			}
			else if (propertyName == "Password")
			{
				if (string.IsNullOrEmpty(this.Password))
					return string.Empty;
			
				var error = string.Empty;

				if (Password != "password")
					error = "Password is incorrect.";

				if (!propErrors.TryGetValue(propertyName, out errors) && !string.IsNullOrEmpty(error))
				{
					errors = new List<string>();
					errors.Add(error);
					propErrors.Add("Password", errors);
				}
				else if (propErrors.TryGetValue(propertyName, out errors))
				{
					errors.Clear();
					propErrors.Remove(propertyName);
				}
			}

            if (propErrors.TryGetValue(propertyName, out errors))
                return errors;
            return null;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        //[Display(AutoGenerateField = false)]
        public bool HasErrors
        {
            get
            {
                var propErrorsCount = propErrors.Values.FirstOrDefault(r => r.Count > 0);
                if (propErrorsCount != null)
                    return true;
                else
                    return false;
            }
        }

        private void RaisePropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        private void RaiseErrorChanged(string propName)
        {
            if (this.ErrorsChanged != null)
                this.ErrorsChanged(this, new DataErrorsChangedEventArgs(propName));
        }
    }
}