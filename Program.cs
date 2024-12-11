namespace FactoryMethod
{
    class FactoryMethod
    {
        static void Main(string[] args)
        {

            SenderFactory emailFactory = new EmailSenderFactory();
            ISender emailSender = emailFactory.CreateSender();
            emailSender.Send("Greetings via Email!");

            SenderFactory smsFactory = new SmsSenderFactory();
            ISender smsSender = smsFactory.CreateSender();
            smsSender.Send("Greetings via SMS!");

            Console.ReadLine();
        }
    }

    interface ISender
    {
        void Send(string message);
    }


    class EmailSender : ISender
    {
        public void Send(string message)
        {
            Console.WriteLine($"EmailSender: Dispatching email with content: {message}");
        }
    }


    class SmsSender : ISender
    {
        public void Send(string message)
        {
            Console.WriteLine($"SmsSender: Transmitting SMS with content: {message}");
        }
    }


    abstract class SenderFactory
    {
        public abstract ISender CreateSender();
    }


    class EmailSenderFactory : SenderFactory
    {
        public override ISender CreateSender()
        {
            return new EmailSender();
        }
    }

    class SmsSenderFactory : SenderFactory
    {
        public override ISender CreateSender()
        {
            return new SmsSender();
        }
    }
}
