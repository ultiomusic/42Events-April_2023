using	System.Net;
using	System.Net.Mail;

namespace	SendMail
{
	class Program
	{
		static string smtpAdress = "smtp.office365.com";
		static int portNumber = 587;
		static bool enableSSL = true;
		static string emailFromAddress = "adantas.dev.test@hotmail.com";
		static string password = "Senhab0b4123";
		static string emailToAdress = "ninjabicakci@gmail.com";
		static string subject = "test";
		static string body = "Hello good evening I'm glad it works :)";
		static void Main(string[] args)
		{
			SendEmail();
		}
		public static void SendEmail()
		{
			using(MailMessage mail = new MailMessage())
			{
				mail.From = new MailAddress(emailFromAddress);
				mail.To.Add(emailToAdress);
				mail.Subject = subject;
				mail.Body = body;
				mail.IsBodyHtml = true;
				using (SmtpClient smtp = new SmtpClient(smtpAdress, portNumber))
				{
					smtp.Credentials = new NetworkCredential(emailFromAddress, password);
					smtp.EnableSsl = enableSSL;
					smtp.Send(mail);
				}
			}
		}
	}
}
