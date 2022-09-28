/*< !--
    Author:    Cole Hanlon
Partner:   Tyler Harkness
Date: 9 / 27 / 2022
Course:    CS 4540, University of Utah, School of Computing
Copyright: CS 4540 and Cole Hanlon, Tyler Harkness - This work may not be copied for use in Academic Coursework.

    I, Cole Hanlon & Tyler Harkness, certify that I wrote this code from scratch and did not copy it in part or whole from
  another source.Any references used in the completion of the assignment are cited in my README file.

  File Contents

      This is the email sender class, provides the framework so users can confirm their emails and reset passwords.
-->*/﻿
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using TAApplication.Areas.Identity.Services;

namespace TAApplication.Areas.Identity.Services;

public class EmailSender : IEmailSender
{
    private readonly ILogger _logger;

    public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor,
                       ILogger<EmailSender> logger)
    {
        Options = optionsAccessor.Value;
        _logger = logger;
    }

    public AuthMessageSenderOptions Options { get; } //Set with Secret Manager.

    public async Task SendEmailAsync(string toEmail, string subject, string message)
    {
        if (string.IsNullOrEmpty(Options.SendGridKey))
        {
            throw new Exception("Null SendGridKey");
        }
        await Execute(Options.SendGridKey, subject, message, toEmail);
    }

    public async Task Execute(string apiKey, string subject, string message, string toEmail)
    {
        var client = new SendGridClient(apiKey);
        var msg = new SendGridMessage()
        {
            From = new EmailAddress("u1240204@utah.edu", "Password Recovery"),
            Subject = subject,
            PlainTextContent = message,
            HtmlContent = message
        };
        msg.AddTo(new EmailAddress(toEmail));

        // Disable click tracking.
        // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
        msg.SetClickTracking(false, false);
        var response = await client.SendEmailAsync(msg);
        _logger.LogInformation(response.IsSuccessStatusCode
                               ? $"Email to {toEmail} queued successfully!"
                               : $"Failure Email to {toEmail}");
    }
}
