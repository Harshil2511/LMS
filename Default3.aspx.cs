using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //MailMessage mail = new MailMessage("himanshukalra@vardhman.com", "himanshukalra@vardhman.com");
        //SmtpClient client = new SmtpClient();
       
        //client.EnableSsl = false;
        //client.Port = 25;
        //NetworkCredential NetworkCred = new NetworkCredential("himanshukalra@vardhman.com", "pass@1234");
        //client.DeliveryMethod = SmtpDeliveryMethod.Network;
        //client.UseDefaultCredentials = false;
        //client.Host = "172.28.0.254";
        //mail.Subject = "this is a test email.";
        //mail.Body = "this is my test email body";
        //client.Send(mail);


        MailMessage mm = new MailMessage("himanshukalra@vardhman.com", "himanshukalra@vardhman.com");
        mm.Subject = "Book Issued";
        mm.Body = "Book Issued to";
        mm.IsBodyHtml = true;
        SmtpClient smtp = new SmtpClient();
        smtp.Host = "172.28.0.254";
        smtp.EnableSsl = true;
        NetworkCredential NetworkCred = new NetworkCredential("himanshukalra@vardhman.com", "pass@1234");
        smtp.UseDefaultCredentials = true;
        smtp.Credentials = NetworkCred;
        smtp.Port = 25;
        smtp.Send(mm);
    }
}