namespace Banking;

public class Accounts
{
   public decimal Balance { get; set; }
   public event AccountOperation underBalance;
   public void withdraw(decimal amount)
   {
      Balance -= amount;
      if (Balance < 1000)
      {
         underBalance?.Invoke();
      }
   }
}
