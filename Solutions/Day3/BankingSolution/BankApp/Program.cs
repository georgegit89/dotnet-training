using Banking;
using Banking.Handlers;

Accounts account = new Accounts();
account.underBalance += AccountListener.BlockAccount;
account.underBalance += AccountListener.SendEmail;

account.Balance = 5000;
account.withdraw(6000);
