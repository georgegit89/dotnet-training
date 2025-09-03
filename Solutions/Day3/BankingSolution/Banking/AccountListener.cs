namespace Banking.Handlers;

public static class AccountListener
{
   public static void BlockAccount()
   {
      Console.WriteLine($"Account has been blocked.");
   }

   public static void SendEmail()
   {
      Console.WriteLine($"Email has been sent to the account holderr regarding the activity.");
   }
}