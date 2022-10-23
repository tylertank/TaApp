/**
 * Author:    Cole Hanlon
 * Partner:   Tyler Harkness
 * Date:      9/27/2022
 * Course:    CS 4540, University of Utah, School of Computing
 * Copyright: CS 4540 and Cole Hanlon, Tyler Harkness - This work may not be copied for use in Academic Coursework.
 *
 * I, Cole Hanlon & Tyler harkness, certify that I have made modifications to this code based on course
 * guidance. The base code has been provided through tutorials from Microsoft Corporation. 
 *
 * File Contents
 *
 *   Defines an email sending object, and executes sending of emails. Provided by Microsoft.
 */

using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using TAApplication.Areas.Identity.Services;

namespace TAApplication.Areas.Identity.Services;

/// <summary>
/// Defines object to send emails
/// </summary>
public class EmailSender : IEmailSender
{
    private readonly ILogger _logger;
    private IConfiguration _config;

    public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor,
                       ILogger<EmailSender> logger, IConfiguration configuration)
    {
        Options = optionsAccessor.Value;
        _logger = logger;
        _config = configuration;
    }

    public AuthMessageSenderOptions Options { get; } //Set with Secret Manager.

    public async Task SendEmailAsync(string toEmail, string subject, string message)
    {
        if (string.IsNullOrEmpty(Options.SendGridKey))
        {
            throw new Exception("Null SendGridKey");
        }
        await Execute(_config.GetValue<string>("SendGrid:Key"), subject, message, toEmail);
    }

    /// <summary>
    /// Generates email message using api key and utah.edu address
    /// </summary>
    /// <param name="apiKey"></param>
    /// <param name="subject"></param>
    /// <param name="message"></param>
    /// <param name="toEmail"></param>
    /// <returns></returns>
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
