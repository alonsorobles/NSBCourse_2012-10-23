namespace HelloWorldServer
{
    public interface ISaySomething
    {
        string InResponseTo(string request);
    }

    public class SaySomething: ISaySomething
    {
        public string InResponseTo(string request)
        {
            return "Hello World!";
        }
    }
}