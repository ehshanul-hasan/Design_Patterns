using System;
using System.Collections.Generic;

namespace Design_Patterns.SOLID
{

    //Clients should not be forced to implement any methods they don’t use.
    //Rather than one fat interface, numerous little interfaces are preferred based on groups of
    //methods with each interface serving one submodule.
    //Here in stead of putting all the method in a single interface, methods has ben put under seperate interface.

    public class InterfaceSegregation
    {
        public readonly IMobileNotification _mobileNotification;
        public readonly IEmailNotification _emaileNotification;
        public InterfaceSegregation(IMobileNotification mobileNotification, IEmailNotification emaileNotification)
        {
            _mobileNotification = mobileNotification;
            _emaileNotification = emaileNotification;
        }
        public string SendMessageByMobileNetwork()
        {
            var response = string.Empty;
            response = $"{response} {_mobileNotification.TextNotification("Message")}.";
            response = $"{response} {_mobileNotification.VoiceNotification("Message")}.";
            return response;
        }

        public string SendMessageByEmail()
        {
            return _emaileNotification.EmailNotification("Message");
        }

    }

    public class MobileNotification : IMobileNotification
    {
        public string TextNotification(string MessageContent)
        {
            return $"Sending Text Notification: {MessageContent}";
        }

        public string VoiceNotification(string MessageContent)
        {
            return $"Sending Voice Notification: {MessageContent}";
        }
    }

    public class EmaileNotification : IEmailNotification
    {
        public string EmailNotification(string MessageContent)
        {
            return $"Sending Email Notification: {MessageContent}";
        }
    }
    public interface IMobileNotification
    {
        string TextNotification(string MessageContent);
        string VoiceNotification(string MessageContent);
    }

    public interface IEmailNotification
    {
        string EmailNotification(string MessageContent);
    }

}
