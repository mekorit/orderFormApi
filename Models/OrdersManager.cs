using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Web;

namespace API.Models
{
    public class OrdersManager
    {
        public static bool Send(string address, string subject, string body, string ccAddress = "", string attachmentUrl = "", string page = "", string attachmentUrl2 = "", StringBuilder attachmentICS3 = null, string Host = "", string listAttachmentUrl = "", string fromAddressEmail = "", string fromAddressPassword = "")
        {
            return SendMailAction(address, subject, body, ccAddress, attachmentUrl, page, attachmentUrl2, attachmentICS3, Host, listAttachmentUrl, fromAddressEmail, fromAddressPassword);
        }

        private static bool SendMailAction(string toAddress, string subject, string body, string ccAddress, string attachmentUrl, string page = "", string attachmentUrl2 = "", StringBuilder attachmentICS3 = null, string Host = "", string listAttachmentUrl = "", string fromAddressEmail = "", string fromAddressPassword = "")
        {
            bool result = false;
            try
            {

                string fromAddress = "";
                if (fromAddressEmail != "")
                    fromAddress = fromAddressEmail;
                else
                    fromAddress = "m035493883@gmail.com";

                SmtpClient smtp = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    UseDefaultCredentials = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(fromAddressEmail == "" ? "m035493883@gmail.com" : fromAddressEmail, fromAddressPassword == "" ? "wzdnrtetdqdcbuhs" : fromAddressPassword),
                    EnableSsl = true,
                };
                smtp.Timeout = int.MaxValue;

                MailMessage message = new MailMessage();
                message.Body = body;
                message.Subject = subject;
                message.BodyEncoding = Encoding.UTF8;
                message.IsBodyHtml = true;

                foreach (var address in toAddress.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    message.To.Add(address);
                }


                //message.Bcc.Add("c0504152343@gmail.com");


                message.From = new MailAddress(fromAddress, "mekorit");

                if (attachmentUrl != "")
                {
                    message.Attachments.Add(new Attachment(attachmentUrl));
                }

                if (attachmentUrl2 != "")
                {
                    message.Attachments.Add(new Attachment(attachmentUrl2));
                }
                if (listAttachmentUrl.ThGetTrimedString() != "")
                {
                    string[] list = listAttachmentUrl.Split(';');
                    foreach (var attachment in list)
                    {
                        if (attachment != "")
                            message.Attachments.Add(new Attachment(attachment));
                    }
                }
                if (attachmentICS3 != null)
                {

                    System.Net.Mime.ContentType contype = new System.Net.Mime.ContentType("text/calendar");
                    contype.Parameters.Add("method", "REQUEST");
                    contype.Parameters.Add("name", "Meeting.ics");
                    AlternateView avCal = AlternateView.CreateAlternateViewFromString(attachmentICS3.ToString(), contype);
                    message.AlternateViews.Add(avCal);
                }

                for (int i = 0; i < 5; i++)
                {
                    try
                    {
                        smtp.Send(message);
                        break;
                    }
                    catch (Exception ex)
                    {
                        if (i == 4) result = false;
                    }
                }
                result = true;
            }
            catch (Exception ex)
            {

            }

            return result;
        }
    }
}