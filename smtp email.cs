        private void BtnSendMail_Click(object sender, EventArgs e)
        {
            MailMessage mail = new MailMessage(); //MailMessage mail = new MailMessage("you@yourcompany.com", "user@hotmail.com");
            mail.BodyEncoding = UTF8Encoding.UTF8;
            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            mail.To.Add(new MailAddress("design.allmark@gmail.com"));
            mail.From = new MailAddress("design.allmark@gmail.com");
            mail.Subject = "this is a test email.";
            mail.Body = "this is my test email body";
            mail.IsBodyHtml = true;

            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("design.allmark@gmail.com", "allmark@1409");

            client.Send(mail);
        }