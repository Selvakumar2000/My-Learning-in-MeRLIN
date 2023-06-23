﻿using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using MimeKit;
using System.Collections.Generic;
using System.Linq;

public class Message
{
    public List<MailboxAddress> To { get; set; }
    public string Subject { get; set; }
    public string Content { get; set; }
    public IFormFileCollection Attachements{ get; set; }


    public Message(IEnumerable<string> to, string subject, string content, IFormFileCollection attachments)
    {
        To = new List<MailboxAddress>();
        To.AddRange(to.Select(x => new MailboxAddress(x)));
        Subject = subject;
        Content = content;
        Attachements = (IFormFileCollection)attachments;
    }
}