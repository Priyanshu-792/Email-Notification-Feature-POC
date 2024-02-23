# Email Notification Feature Implementation
<video src="https://github.com/Priyanshu-792/Email-Notification-Feature-POC/assets/85648078/8e9973a2-cc7f-4951-8b32-65a825d8ea26"></video>
## Introduction

This feature enables the application to send automated emails to users based on specific conditions such as registration confirmation or password reset requests. The process involves researching and selecting an email delivery service or SMTP server, developing the trigger mechanism, creating email templates, testing, documenting, and presenting the feature to the team. The focus is on functionality, scalability, code quality, documentation, and effective presentation of the feature's benefits.

## Email Delivery Service or SMTP Server

For this project, the chosen email delivery service is MailKit, an open-source cross-platform library widely used in .NET applications for email-related tasks due to its flexibility, performance, and extensive functionality. MailKit is utilized alongside the Google SMTP server to automate the process of sending emails for registration confirmation and password reset.

### Configuration Process

1. Install MailKit from Manage NuGet Packages to the .NET system.
2. Sending Email:
   - Connect to the Google SMTP server securely over TLS/STARTTLS.
   - Authenticate with the SMTP server using provided credentials.
   - Send the email message to the recipient's email address via the SMTP server.

### Step-by-Step Configuration of Gmail SMTP

1. Log in to Your Gmail Account.
2. Enable Less Secure Apps.
3. Generate an App-Specific Password (Optional, if 2FA enabled).
4. Update SMTP Configuration in Your Application.

## Email Template Creation and Modification

### Creating a MimeMessage Object

1. Initialize a new MimeMessage object.
   - Example: `var email = new MimeMessage();`

### Setting Sender and Recipient

2. Add sender and recipient addresses to the MimeMessage object.
   - Example: `email.From.Add(MailboxAddress.Parse(_config["EmailUsername"])); email.To.Add(MailboxAddress.Parse(toEmail));`

### Setting Email Subject

3. Assign a subject to the email.
   - Example: `email.Subject = "Registration Successful!";`

### Setting Email Body

4. Create a TextPart object with the desired format (HTML or plain text).
   - Assign the content to the TextPart object.
   - Assign the TextPart object to the MimeMessage's Body property.

## Integrating New Triggers for Email Notifications

### Registration Notification Triggers

1. Form Submission and Password Matching.
2. Registration Process.
3. Email Confirmation Trigger.
4. User Feedback and Error Handling.

### Password Reset Notification Triggers

1. Form Submission and Validation.
2. Reset Password API Endpoint.
3. Sending Password Reset Email.

## Frontend and Backend Technologies

### Frontend in Angular

Demo registration page and password reset page created for frontend.

### Backend in .NET

Backend implemented in .NET for handling registration confirmation, password reset requests, and triggering email notifications.

